using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TaxCalculation.Commands.UpdateCalculatedTax
{
    public class UpdateCalculatedTaxCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public double TaxAmount { get; set; }
        public double AnnualIncome { get; set; }
        public double TaxRate { get; set; }
    }
}
