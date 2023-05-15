using Domain.Common;

namespace Domain
{
    public class CalculatedTax : BaseEntity
    {
        public double TaxAmount { get; set; }
        public double AnnualIncome { get; set; }
        public double TaxRate { get; set; }

    }
}
