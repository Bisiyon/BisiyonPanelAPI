using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Domain
{
    public class MeskenUye : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UyeId { get; set; }
        public int UyeDurumTipId { get; set; }
        public int MeskenId { get; set; }
        public int MalikHisse { get; set; } = 100;

        [ForeignKey(nameof(MeskenId))]
        public Mesken Mesken { get; set; }

        [ForeignKey(nameof(UyeId))]
        public Uye Uye { get; set; }

        [ForeignKey(nameof(UyeDurumTipId))]
        public UyeDurumTip UyeDurumTip { get; set; }

    }
}