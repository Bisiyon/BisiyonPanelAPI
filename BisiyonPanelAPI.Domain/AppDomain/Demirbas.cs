using System;
using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public class Demirbas : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Miktar { get; set; }
        public string Turu { get; set; }
        public string Satici { get; set; }
        public string SeriNo { get; set; }
        public DateTime AlimTarihi { get; set; }
        public string FaturaNo { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Kdv { get; set; }
        public decimal Tutar { get; set; }
        public DateTime GarantiBaslangicTarihi { get; set; }
        public DateTime GarantiBitisTarihi { get; set; }
    }
}
