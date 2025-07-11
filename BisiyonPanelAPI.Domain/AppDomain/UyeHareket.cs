using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    public class UyeHareket : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UyeId { get; set; }
        public int MeskenId { get; set; }
        public DateTime IslemTarih { get; set; }
        public int HareketTipId { get; set; }

        [ForeignKey(nameof(UyeId))]
        public Uye Uye { get; set; }

        [ForeignKey(nameof(MeskenId))]
        public Mesken Mesken { get; set; }

    }
}