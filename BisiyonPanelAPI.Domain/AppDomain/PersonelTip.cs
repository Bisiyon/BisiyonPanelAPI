using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    public class PersonelTip : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; } 
        public string Tip { get; set; }
 
    }
} 