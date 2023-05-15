using MediatR;

namespace Application.Features.TaxCalculation.Commands.CreateCalculatedTax
{
    public class CreateCalculatedTaxCommand : IRequest<Unit>
    {
        public string PostalCode { get; set; }
        public double Amount { get; set; }
    }
}
