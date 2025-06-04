using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BisiyonPanelAPI.Domain
{
    public class Arac : IEntity
    {
        [Key]
        public int Id { get; set; } 
        public int? UyeId { get; set; }

        [Required]
        [StringLength(15)]
        public string Plaka { get; set; }

        [StringLength(100)]
        public string Marka { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        [StringLength(100)]
        public string Renk { get; set; }

        [StringLength(250)]
        public string Aciklama { get; set; }

        [ForeignKey(nameof(UyeId))]
        public Uye Uye { get; set; } 
    }
}