using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TaxCalculation.Commands.DeleteCalculatedTax
{
    public class DeleteCalculatedTaxCommand : IRequest
    {
        public int Id { get; set; }
    }
}
