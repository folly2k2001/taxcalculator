using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TaxCalculation.Commands.UpdateCalculatedTax
{
    public class UpdateCalculatedTaxCommandHandler : IRequestHandler<UpdateCalculatedTaxCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICalculatedTaxRepository _calculatedTaxRepository;

        public UpdateCalculatedTaxCommandHandler(
            IMapper mapper,
            ICalculatedTaxRepository calculatedTaxRepository)
        {
            _mapper = mapper;
            this._calculatedTaxRepository = calculatedTaxRepository;
        }

        public async Task<Unit> Handle(UpdateCalculatedTaxCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCalculatedTaxDtoValidator(_calculatedTaxRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid", validationResult);

            var calculatedTax = await _calculatedTaxRepository.GetByIdAsync(request.Id);

            if (calculatedTax is null)
                throw new NotFoundException(nameof(CalculatedTax), request.Id);

            _mapper.Map(request, calculatedTax);

            await _calculatedTaxRepository.UpdateAsync(calculatedTax);
            return Unit.Value;
        }
    }
}
