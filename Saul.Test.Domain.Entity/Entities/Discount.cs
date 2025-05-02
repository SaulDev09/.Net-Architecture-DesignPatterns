using Saul.Test.Domain.Common;
using Saul.Test.Domain.Enums;

namespace Saul.Test.Domain.Entities
{
    public class Discount : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Percent { get; set; }
        public DiscountStatus Status { get; set; }
    }
}
