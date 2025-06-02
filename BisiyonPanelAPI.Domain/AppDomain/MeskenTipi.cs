using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public class MeskenTipi : IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Tip { get; set; }
    }
}