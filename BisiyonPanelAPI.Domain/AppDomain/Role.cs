using Microsoft.AspNetCore.Identity;

namespace BisiyonPanelAPI.Domain
{
    public class Role : IdentityRole<Guid>
    {
        public string? Description { get; set; }
        public bool IsEditable { get; set; }
    }
}