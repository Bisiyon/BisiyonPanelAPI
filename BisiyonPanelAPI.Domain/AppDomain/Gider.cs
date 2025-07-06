using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BisiyonPanelAPI.Domain
{
    public class Gider : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string GiderGrupAd { get; set; }

        public int GiderGrupId { get; set; }

        [ForeignKey(nameof(GiderGrupId))]
        public GiderGrup GiderGrup { get; set; }

    }
}