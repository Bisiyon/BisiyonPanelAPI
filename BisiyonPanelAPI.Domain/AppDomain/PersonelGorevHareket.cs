using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    public class PersonelGorevHareket : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int PersonelGorevId { get; set; }
        public DateTime Tarih { get; set; }
        /// <summary>
        /// Enum_PersonelGorevHareketTip üzerinden tanımlanmış olan hareket tipini belirtir.
        /// </summary>
        public int GorevHareketTip { get; set; }

        [ForeignKey(nameof(PersonelId))]
        public Personel Personel { get; set; }

        [ForeignKey(nameof(PersonelGorevId))]
        public PersonelGorev PersonelGorev { get; set; }
    }
}
