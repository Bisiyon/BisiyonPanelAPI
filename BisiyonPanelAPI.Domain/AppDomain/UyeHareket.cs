using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BisiyonPanelAPI.Domain
{
    public class UyeHareket : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UyeId { get; set; }
        public DateTime IslemTarih { get; set; }
        public int HareketTipId { get; set; }

        [ForeignKey("UyeId")]
        public Uye Uye { get; set; }
    }
}