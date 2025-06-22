using System;

namespace BisiyonPanelAPI.Domain
{
    public class Demirbas : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int Miktar { get; set; }
        public string Turu { get; set; }
        public string Satici { get; set; }
        public string Serino { get; set; }
        public DateTime AlimTarihi { get; set; }
        public string Faturano { get; set; }
        public decimal Fiyati { get; set; }
        public decimal Kdv { get; set; }
        public decimal Tutar { get; set; }
        public DateTime GarantiBaslangicTarihi { get; set; }
        public DateTime GarantiBirisTarihi { get; set; }
    }
}
