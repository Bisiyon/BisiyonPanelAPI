using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    public class AracHareket : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public int AracId { get; set; }
        /// <summary>
        /// Aracın giriş veya çıkış hareketi
        /// </summary>
        public int AracHereketTipId { get; set; }
        public DateTime Tarih { get; set; }

        [ForeignKey(nameof(AracId))]
        public Arac Arac { get; set; }

    }
}