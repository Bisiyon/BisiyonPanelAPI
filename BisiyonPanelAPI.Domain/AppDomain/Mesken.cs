using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    public class Mesken : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public int BlokId { get; set; }
        public int? MeskenTipId { get; set; }
        [StringLength(100)]
        public string Ad { get; set; }
        public int? Kat { get; set; }
        public int? DaireNo { get; set; }
        public int? M2 { get; set; }
        public int? ArsaPayi { get; set; }
        public int TahsisOran { get; set; } = 0;
        public int Oran1 { get; set; } = 100;
        public int Oran2 { get; set; } = 100;
        public int Oran3 { get; set; } = 100;
        public int Oran4 { get; set; } = 100;
        public int Oran5 { get; set; } = 100;
        public int Oran6 { get; set; } = 100;
        public int Oran7 { get; set; } = 100;
        public int Oran8 { get; set; } = 100;
        public int Oran9 { get; set; } = 100;
        public int? KisiSayisi { get; set; }
        public int? AidatGrupId { get; set; }
        public int? KatSayisi { get; set; }
        public int? GiderGrupId { get; set; }
        [ForeignKey(nameof(GiderGrupId))]
        public GiderGrup? GiderGrup { get; set; }

        public int? GiderId { get; set; }
        [ForeignKey(nameof(GiderId))]
        public Gider? Gider { get; set; }

        [ForeignKey(nameof(AidatGrupId))]
        public AidatGrup? AidatGrup { get; set; }

        [ForeignKey(nameof(MeskenTipId))]
        public MeskenTipi MeskenTipi { get; set; }

        [ForeignKey(nameof(BlokId))]
        public Blok Blok { get; set; }
        public ICollection<MeskenUye> MeskenUyes { get; set; } = new List<MeskenUye>();

    }
}