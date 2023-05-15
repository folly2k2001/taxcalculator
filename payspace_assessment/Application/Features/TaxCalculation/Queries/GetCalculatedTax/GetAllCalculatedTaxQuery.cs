using MediatR;

namespace Application.Features.TaxCalculation.Queries.GetCalculatedTax
{
    public class GetAllCalculatedTaxQuery : IRequest<List<CalculatedTaxDto>>
    {
    }
}
