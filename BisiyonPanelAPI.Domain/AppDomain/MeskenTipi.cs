using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public class MeskenTipi : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Tip { get; set; }

        [StringLength(3)]
        public string Kod { get; set; }

        [StringLength(12)]
        public string DataKey { get; set; }
        public string Renk { get; set; }
    }
}