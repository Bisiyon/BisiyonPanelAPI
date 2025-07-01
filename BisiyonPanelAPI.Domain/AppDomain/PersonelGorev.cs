using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    /// <summary>
    /// Personellerin görev yerlerini temsil eden sınıf.
    /// Bu sınıf, personel görev yerlerinin temel özelliklerini içerir.
    /// </summary>
    public class PersonelGorev : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public string Adres { get; set; }
    }
}
