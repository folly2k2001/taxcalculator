using Domain.Common;

namespace Domain
{
    public class PostalCode_TaxCalculationType_TaxRates : BaseEntity
    {
        public PostalCode_TaxCalculationType PostalCode_TaxCalculationType { get; set; }
        public int PostalCode_TaxCalculationTypeId { get; set; }
        public TaxRate TaxRate { get; set; }
        public int TaxRateId { get; set; }
        public CalculatedTax CalculatedTax { get; set; }
    }
}
