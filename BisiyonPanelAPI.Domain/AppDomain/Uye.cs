using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonPanelAPI.Domain
{
    public class Uye : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int? MeskenId { get; set; }
        public int UyeDurumTipId { get; set; }

        [ForeignKey(nameof(UyeDurumTipId))]
        public UyeDurumTip UyeDurumTip { get; set; }

        [ForeignKey("MeskenId")]
        public Mesken Mesken { get; set; }
    }
}