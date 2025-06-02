using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public class Blok : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string BlokAdi { get; set; }
        public int? ToplamKatSayisi { get; set; }
        public int? KatBaslangicKati { get; set; }
        public bool Asansor { get; set; }
        public bool Otopark { get; set; }
        public int? BinaYasi { get; set; }
        [StringLength(2000)]
        public string BlokOzellikleri { get; set; }
    }
}