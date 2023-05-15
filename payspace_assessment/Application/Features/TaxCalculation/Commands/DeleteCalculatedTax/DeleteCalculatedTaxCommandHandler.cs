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

namespace Application.Features.TaxCalculation.Commands.DeleteCalculatedTax
{
    public class DeleteCalculatedTaxCommandHandler : IRequestHandler<DeleteCalculatedTaxCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICalculatedTaxRepository _calculatedTaxRepository;

        public DeleteCalculatedTaxCommandHandler(
            IMapper mapper,
            ICalculatedTaxRepository calculatedTaxRepository)
        {
            _mapper = mapper;
            this._calculatedTaxRepository = calculatedTaxRepository;
        }

        public async Task<Unit> Handle(DeleteCalculatedTaxCommand request, CancellationToken cancellationToken)
        {
            var calculatedTex = await _calculatedTaxRepository.GetByIdAsync(request.Id);

            if (calculatedTex == null)
                throw new NotFoundException(nameof(CalculatedTax), request.Id);

            await _calculatedTaxRepository.DeleteAsync(calculatedTex);
            return Unit.Value;
        }
    }
}
