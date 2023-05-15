using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.TaxCalculation.Commands.CreateCalculatedTax
{
    public class CreateCalculatedTaxCommandHandler : IRequestHandler<CreateCalculatedTaxCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly ICalculatedTaxRepository _calculatedTaxRepository;
        private readonly IPostalCode_TaxCalculationTypeRepository _postalCodeTaxCalculationTypeRepository;
        private readonly ITaxCalculationTypeRepository _taxCalculationTypeRepository;

        public CreateCalculatedTaxCommandHandler(IMapper mapper, IPostalCodeRepository postalCodeRepository,
            IPostalCode_TaxCalculationTypeRepository postalCode_TaxCalculationTypeRepository,
            ITaxCalculationTypeRepository taxCalculationTypeRepository, ICalculatedTaxRepository calculatedTaxRepository)
        {
            _mapper = mapper;
            _postalCodeRepository = postalCodeRepository;
            _postalCodeTaxCalculationTypeRepository = postalCode_TaxCalculationTypeRepository;
            _taxCalculationTypeRepository = taxCalculationTypeRepository;
            _calculatedTaxRepository = calculatedTaxRepository;
        }
        public async Task<Unit> Handle(CreateCalculatedTaxCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCalculatedTaxCommandValidator(_postalCodeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Postal Code or TaxAmount", validationResult);

            // Get Postal code Id
            var postalCode = await _postalCodeRepository.GetPostalCodeByCode(request.PostalCode);
            // Get Postal Code Tax Calculation Type
            var postalTaxCalcType = await _postalCodeTaxCalculationTypeRepository.GetByPostalCodeId(postalCode.Id);
            // Get PostalCode Tax Type Rates
            var taxCalcType = await _taxCalculationTypeRepository.GetByTaxCalculationTypeId(postalTaxCalcType.TaxCalculationTypeId);

            var taxTypeRates = await _postalCodeTaxCalculationTypeRepository.GetByTaxCalculationTypeIdAndAnnualIncome(request.Amount, taxCalcType);
            // Calculate Tax TaxAmount
            var taxAmount = taxTypeRates.Rate == 0 ? taxTypeRates.FlatValue : taxTypeRates.Rate * request.Amount;
            // Create Calculated Tax
            await _calculatedTaxRepository.CreateCalculatedTax(taxAmount,request.Amount, taxTypeRates.Rate);

            return Unit.Value;

        }

    }
}
