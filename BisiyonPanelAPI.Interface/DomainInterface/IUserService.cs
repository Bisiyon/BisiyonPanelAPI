using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;

namespace BisiyonPanelAPI.Interface
{
    public interface IUserService : IServiceBase<User>
    {
        Task<Result<LoginResponseView>> Login(LoginRequestView model);
    }
}