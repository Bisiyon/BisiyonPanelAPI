using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BisiyonPanelAPI.Domain
{
    public class MeskenTipi : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Tip { get; set; }
    }
}