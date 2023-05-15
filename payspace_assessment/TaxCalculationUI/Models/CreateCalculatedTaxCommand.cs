namespace TaxCalculationUI.Models
{
    public class CreateCalculatedTaxCommand
    {
        public string PostalCode { get; set; }
        public double Amount { get; set; }
    }
}
