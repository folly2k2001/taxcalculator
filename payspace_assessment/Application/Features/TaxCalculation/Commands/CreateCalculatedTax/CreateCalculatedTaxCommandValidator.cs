using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.TaxCalculation.Commands.CreateCalculatedTax
{
    public class CreateCalculatedTaxCommandValidator : AbstractValidator<CreateCalculatedTaxCommand>
    {
        private readonly IPostalCodeRepository _postalCodeRepository;

        public CreateCalculatedTaxCommandValidator(IPostalCodeRepository postalCodeRepository)
        {
            _postalCodeRepository = postalCodeRepository;
            RuleFor(p => p.PostalCode)
                .NotEmpty().NotNull().WithMessage("{PropertyName} is required")
                .MaximumLength(4).WithMessage("{PropertyName} should not exceed 4 characters")
                .MustAsync(PostalCodeMustExist).WithMessage("{PropertyName} does not exist.");
            RuleFor(p => p.Amount).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} cannot be less than 0");
        }

        private async Task<bool> PostalCodeMustExist(string postalCode, CancellationToken arg2)
        {
            var postalCodeResult = await _postalCodeRepository.GetPostalCodeByCode(postalCode);
            return postalCodeResult != null;
        }
    }
}
