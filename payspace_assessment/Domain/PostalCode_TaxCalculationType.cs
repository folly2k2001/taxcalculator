using Domain.Common;

namespace Domain
{
    public class PostalCode_TaxCalculationType : BaseEntity
    {
        public virtual PostalCode PostalCode { get; set; }
        public int PostalCodeId { get; set; }
        public virtual TaxCalculationType TaxCalculationType { get; set; }
        public int TaxCalculationTypeId { get; set; }

    }
}
