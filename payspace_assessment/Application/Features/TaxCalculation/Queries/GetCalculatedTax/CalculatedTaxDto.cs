using Domain;

namespace Application.Features.TaxCalculation.Queries.GetCalculatedTax
{
    public class CalculatedTaxDto
    {
        public int Id { get; set; }
        public double TaxAmount { get; set; }
        public double AnnualIncome { get; set; }
        public double TaxRate { get; set; }

    }
}
