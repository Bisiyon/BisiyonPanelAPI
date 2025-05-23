using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BisiyonPanelAPI.Service
{
    public interface ITenantServiceScopeFactory
    {
        IServiceScope CreateScope(string siteCode);
    }

    public class TenantServiceScopeFactory : ITenantServiceScopeFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public TenantServiceScopeFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IServiceScope CreateScope(string cs)
        {
            var scope = _serviceProvider.CreateScope();

            var dbContextFactory = scope.ServiceProvider.GetRequiredService<ITenantDbContextFactory>();
            dbContextFactory.CreateDbContext(cs);

            return scope;
        }
    }


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
            if (string.IsNullOrWhiteSpace(model.SiteCode)) return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "Does not site code!" };
            MainSites? site = await _mainContext.Sites.FirstOrDefaultAsync(x => x.SiteCode == model.SiteCode);
            if (site is null) return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "Can not found site by site code!" };
            if (string.IsNullOrWhiteSpace(site.DatabaseInfo)) return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "Can not found database info by site code!" };
            BisiyonAppContext context = _tenantDbContextFactory.CreateDbContext(site.DatabaseInfo);
            // var userStore = new UserStore<User, Role, BisiyonAppContext, Guid>(context);
            // var userManager = new UserManager<User>(userStore, null, new PasswordHasher<User>(), null, null, null, null, null, null);

            using var scope = _tenantServiceScopeFactory.CreateScope(site.DatabaseInfo);
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            User? user = await userManager.FindByEmailAsync(model.UserName);
            if (user is null)
                user = await userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == model.UserName);

            if (user is not null)
            {
                var hasher = new PasswordHasher<User>();
                // var pwdCheck = hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
                bool pwdCheck = await userManager.CheckPasswordAsync(user, model.Password);

                // if (pwdCheck == PasswordVerificationResult.Success)
                if (pwdCheck)
                {
                    string token = _jwtTokenGenerator.GenerateToken(user.Id, model.UserName, model.SiteCode);
                    return new Result<LoginResponseView>()
                    {
                        State = ResultState.Successfull,
                        Data = new LoginResponseView()
                        {
                            Token = token,
                            CreatedDate = DateTime.Now
                        }
                    };
                }
                else
                {
                    return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "UserNameOrPasswordInCorrect" };
                }
            }
            return new Result<LoginResponseView>() { State = ResultState.Fail, Message = "UserNameOrPasswordInCorrect" };
        }

    }
}