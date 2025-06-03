using System.ComponentModel.DataAnnotations;

namespace BisiyonPanelAPI.Domain
{
    public abstract class BaseEntity
    {
        [Timestamp]
        public byte[]? ConcurrencyToken { get; set; }
    }
}