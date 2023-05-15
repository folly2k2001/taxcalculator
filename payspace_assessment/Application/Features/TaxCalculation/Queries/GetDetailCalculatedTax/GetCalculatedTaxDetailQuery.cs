using Application.Features.TaxCalculation.Queries.GetCalculatedTax;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TaxCalculation.Queries.GetDetailCalculatedTax
{
    public record GetCalculatedTaxDetailQuery(int id) : IRequest<CalculatedTaxDetailDto>;
}
