using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    public class Ilce : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Ad { get; set; }
        public int IlId { get; set; }
        [ForeignKey(nameof(IlId))]
        public Il Il { get; set; }
    }
}