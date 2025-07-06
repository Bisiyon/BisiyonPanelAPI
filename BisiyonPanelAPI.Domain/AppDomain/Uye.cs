using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Domain
{
    public class Uye : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UyeDurumTipId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string CinsiyetId { get; set; }
        public string TCKimlikNo { get; set; }
        public string DogumTarihi { get; set; }
        public string CepTelefonu { get; set; }
        public string CepTelefonu2 { get; set; }
        public string CepTelefonu3 { get; set; }
        public string CepTelefonu4 { get; set; }
        public string Email { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Email4 { get; set; }
        public int IlId { get; set; }
        public int IlceId { get; set; }
        public decimal? AcilisBakiyesi { get; set; }
        public string TebligatAdres { get; set; }
        public string Aciklama { get; set; }

        [ForeignKey(nameof(UyeDurumTipId))]
        public UyeDurumTip UyeDurumTip { get; set; }

        [ForeignKey(nameof(IlId))]
        public Il Il { get; set; }

        [ForeignKey(nameof(IlceId))]
        public Ilce Ilce { get; set; }
     
    }
}