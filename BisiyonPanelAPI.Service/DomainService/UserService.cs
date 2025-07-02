using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BisiyonPanelAPI.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly BisiyonMainContext _mainContext;
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ITenantDbContextFactory _tenantDbContextFactory;
        private readonly ITenantServiceScopeFactory _tenantServiceScopeFactory;

        public UserService(IUnitOfWork unitOfWork
        , BisiyonMainContext mainContext
        , UserManager<User> userManager
        , IJwtTokenGenerator jwtTokenGenerator
        , ITenantDbContextFactory tenantDbContextFactory
        , ITenantServiceScopeFactory tenantServiceScopeFactory) : base(unitOfWork)
        {
            _mainContext = mainContext;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _tenantDbContextFactory = tenantDbContextFactory;
            _tenantServiceScopeFactory = tenantServiceScopeFactory;
        }

        public async Task<Result<LoginResponseView>> Login(LoginRequestView model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.SiteCode)) return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "Does not site code!" };
                MainSites? site = await _mainContext.Sites.FirstOrDefaultAsync(x => x.SiteCode == model.SiteCode);
                if (site is null) return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "Can not found site by site code!" };
                if (string.IsNullOrWhiteSpace(site.DatabaseInfo)) return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "Can not found database info by site code!" };
                using var scope = _tenantServiceScopeFactory.CreateScope(site.DatabaseInfo);

                BisiyonAppContext context = scope.ServiceProvider.GetRequiredService<BisiyonAppContext>();
                try
                {
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {

                }

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                try
                {
                    await AddSystemUser(userManager);
                }
                catch (Exception)
                {

                }

                User? user = await userManager.FindByEmailAsync(model.UserName);
                if (user is null)
                    user = await userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == model.UserName);

                if (user is not null)
                {
                    var hasher = new PasswordHasher<User>();
                    bool pwdCheck = await userManager.CheckPasswordAsync(user, model.Password);

                    if (pwdCheck)
                    {
                        GenerateAccessTokenResponse token = _jwtTokenGenerator.GenerateToken(user.Id, model.UserName, model.SiteCode);
                        return new Result<LoginResponseView>()
                        {
                            State = ResultState.Successfull,
                            Data = new LoginResponseView()
                            {
                                Token = token.BearerToken,
                                CreatedDate = DateTime.Now
                            }
                        };
                    }
                    else
                    {
                        return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "UserNameOrPasswordInCorrect" };
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "UserNameOrPasswordInCorrect" };
        }

        private async Task<Result<bool>> AddSystemUser(UserManager<User> userManager)
        {
            string email = "sysadmin@bisiyon.com";
            User? user = await userManager.FindByEmailAsync(email);
            if (user != null)
                return new Result<bool>() { State = ResultState.Successfull, Data = true };
            user = new User()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = true
            };

            IdentityResult result = await userManager.CreateAsync(user, "b1siY0n!");
            return new Result<bool>() { State = result.Succeeded ? ResultState.Successfull : ResultState.Fail, Data = result.Succeeded };
        }

    }
}