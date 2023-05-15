using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TaxCalculationUI.Models.CalculatedTax
{
    public class CreateCalculatedTaxViewModel
    {
        [Required]
        [Display(Name = "Postal Code")]
        [DataType(DataType.Text)]
        [MaxLength(5)]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Annual Amount")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
    }
}
