using Application.Contracts.Persistence;
using FluentValidation;


namespace Application.Features.TaxCalculation.Commands.UpdateCalculatedTax
{
    public class UpdateCalculatedTaxDtoValidator : AbstractValidator<UpdateCalculatedTaxCommand>
    {
        private readonly ICalculatedTaxRepository _calculatedTaxRepository;
        public UpdateCalculatedTaxDtoValidator(ICalculatedTaxRepository calculatedTaxRepository)
        {
            _calculatedTaxRepository = calculatedTaxRepository;
            RuleFor(p => p.TaxRate).NotNull()
               .GreaterThan(0).WithMessage("{PropertyName} must greater than {ComparisonValue}");

            
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(CalculatedTaxMustExist)
                .WithMessage("{PropertyName} must be present");
        }

        private async Task<bool> CalculatedTaxMustExist(int id, CancellationToken arg2)
        {
            var calculatedTax = await _calculatedTaxRepository.GetByIdAsync(id);
            return calculatedTax != null;
        }
    }
}
