using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BisiyonPanelAPI.Domain
{
    public class UyeDurumTip : IEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Ev Sahibi, Kiracı, Sakin 
        /// </summary>
        [StringLength(50)]
        public string Durum { get; set; }
    }
}