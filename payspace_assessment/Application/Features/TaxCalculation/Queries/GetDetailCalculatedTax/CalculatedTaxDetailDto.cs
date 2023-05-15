using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TaxCalculation.Queries.GetDetailCalculatedTax
{
    public class CalculatedTaxDetailDto
    {
        public int Id { get; set; }
        public double TaxAmount { get; set; }
        public double AnnualIncome { get; set; }
        public double TaxRate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
