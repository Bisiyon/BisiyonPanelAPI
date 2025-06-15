using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public class UyeDurumTip : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Ev Sahibi, Kiracı, Sakin, Hissedar
        /// </summary>
        [StringLength(50)]
        public string Durum { get; set; }
    }
}