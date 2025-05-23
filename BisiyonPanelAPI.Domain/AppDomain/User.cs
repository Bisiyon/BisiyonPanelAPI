using Microsoft.AspNetCore.Identity;

namespace BisiyonPanelAPI.Domain
{
    public class User : IdentityUser<Guid>, IEntity
    {

    }
}