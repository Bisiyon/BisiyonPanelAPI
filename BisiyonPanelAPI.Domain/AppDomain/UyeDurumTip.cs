using System.ComponentModel.DataAnnotations;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Common
{
    public class UyeDurumTip : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Ev Sahibi, Kiracı, Sakin
        /// </summary>
        [StringLength(50)]
        public string Durum { get; set; }
        public Enum_UyeDurumTip? EnumId { get; set; }
    }
}