using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public class Il : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Ad { get; set; } 
    }
}