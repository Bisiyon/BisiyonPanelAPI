using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public abstract class BaseEntity
    {
        [Timestamp]
        public byte[]? ConcurrencyToken { get; set; }
        public bool IsActive { get; set; } = true;
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedNotes { get; set; }
    }
}