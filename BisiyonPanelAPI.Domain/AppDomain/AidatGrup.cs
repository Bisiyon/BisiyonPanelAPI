using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public class AidatGrup : BaseEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
      
    }
}