using Domain.Common;

namespace Domain
{
    public class PostalCode : BaseEntity
    {
        public string? Code { get; set; }
        public virtual ICollection<PostalCode_TaxCalculationType> PostalCode_TaxCalculationTypes { get; set; }
    }
}
