namespace TaxCalculationUI.Models
{
    public class UpdateCalculatedTaxCommand
    {
        public int Id { get; set; }
        public double TaxAmount { get; set; }
        public double AnnualIncome { get; set; }
        public double TaxRate { get; set; }
    }
}
