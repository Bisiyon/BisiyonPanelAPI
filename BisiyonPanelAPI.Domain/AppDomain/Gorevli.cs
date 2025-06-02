using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public class Gorevli : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Ad { get; set; }
        [StringLength(50)]
        public string Soyad { get; set; }
        [StringLength(11)]
        public string TcKimlikNo { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
}