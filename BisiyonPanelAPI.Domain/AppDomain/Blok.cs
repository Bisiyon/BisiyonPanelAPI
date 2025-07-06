using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    public class Blok : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Ad { get; set; }
        public int ToplamDaireSayisi { get; set; }
        public int ToplamKatSayisi { get; set; } 
        public int KatBaslangicKati { get; set; }
        public int? IlId { get; set; }
        public int? IlceId { get; set; }
        public string? MahalleKoyMezraMevki { get; set; }
        public string? CaddeSokak { get; set; }
        public string? Apartman { get; set; }
        public string? BinaNo { get; set; }
        public string? Aciklama { get; set; }

        [ForeignKey(nameof(IlId))]
        public Il? Il { get; set; }

        [ForeignKey(nameof(IlceId))]
        public Ilce? Ilce { get; set; }
        public ICollection<Mesken> Meskens { get; set; } = new List<Mesken>();


    }
}