using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    public class Personel : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public int PersonelTipId { get; set; }
        public string SicilNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string CinsiyetId { get; set; }
        public string TCKimlikNo { get; set; }
        public string DogumTarihi { get; set; }
        public string CepTelefonu { get; set; }
        public string Email { get; set; }
        public int IlId { get; set; }
        public int IlceId { get; set; }
        public DateTime? IseGirisTarihi { get; set; }
        public DateTime? IstenCikisTarihi { get; set; }
        public string Aciklama { get; set; }
        public string Adres { get; set; }
        [ForeignKey(nameof(IlId))]
        public Il Il { get; set; }
        [ForeignKey(nameof(IlceId))]
        public Ilce Ilce { get; set; }
        [ForeignKey(nameof(PersonelTipId))]
        public PersonelTip PersonelTip { get; set; }
    }
}
