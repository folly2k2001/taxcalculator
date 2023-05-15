using Domain.Common;

namespace Domain
{
    public class TaxRate : BaseEntity
    {
        public double Rate { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public double FlatValue { get; set; }
        public bool isFlate { get; set; }
        public virtual TaxCalculationType CalculationType { get; set; }
        public int CalculationTypeId { get; set; }
        //public ICollection<PostalCode_TaxCalculationType_TaxRates> PostalCode_TaxCalculationType_TaxRates { get; set; }

    }
}
