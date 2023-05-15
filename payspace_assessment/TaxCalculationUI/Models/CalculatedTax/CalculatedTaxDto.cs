using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TaxCalculationUI.Models.CalculatedTax
{
    public class CalculatedTaxDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tax Amount")]
        [DataType(DataType.Currency)]
        public double TaxAmount { get; set; }
        [Required]
        [Display(Name = "Annual Amount")]
        [DataType(DataType.Currency)]
        public double AnnualIncome { get; set; }
        [Required]
        [Display(Name = "Tax Rate")]
        [DataType(DataType.Currency)]
        public double TaxRate { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        [DataType(DataType.Text)]
        [MaxLength(5)]
        public string PostalCode { get; set; }
    }
}
