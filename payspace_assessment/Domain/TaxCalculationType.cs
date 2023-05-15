using Domain.Common;

namespace Domain
{
    public class TaxCalculationType : BaseEntity
    {
        public string? Type { get; set; }
        public virtual ICollection<PostalCode_TaxCalculationType> PostalCode_TaxCalculationTypes { get; set; }
        public virtual ICollection<TaxRate> Rates { get; set; }
    }
}
