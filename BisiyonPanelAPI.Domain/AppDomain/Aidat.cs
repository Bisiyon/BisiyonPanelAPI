using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public class Aidat : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Adi { get; set; }
        public int? ToplamArsaPayi { get; set; }
        public bool SabiteDahilMi { get; set; }
        public int? ToplamMesken { get; set; }
        public int? ArsaPayi { get; set; }
        public decimal? SabitTutar { get; set; }
        public decimal? ArsaPayiTutar { get; set; }
        public decimal? Tutar { get; set; }
    }
}