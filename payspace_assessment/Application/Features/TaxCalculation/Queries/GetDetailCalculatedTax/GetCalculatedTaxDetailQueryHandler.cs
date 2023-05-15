using Application.Contracts.Persistence;
using Application.Features.TaxCalculation.Queries.GetCalculatedTax;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TaxCalculation.Queries.GetDetailCalculatedTax
{
    public class GetCalculatedTaxDetailQueryHandler : IRequestHandler<GetCalculatedTaxDetailQuery, CalculatedTaxDetailDto>
    {
        private readonly ICalculatedTaxRepository _genericRepository;
        private readonly IMapper _mapper;
        public GetCalculatedTaxDetailQueryHandler(ICalculatedTaxRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<CalculatedTaxDetailDto> Handle(GetCalculatedTaxDetailQuery request, CancellationToken cancellationToken)
        {

            var calculatedTax = await _genericRepository.GetByIdAsync(request.id);
            return _mapper.Map<CalculatedTaxDetailDto>(calculatedTax);
        }
    }
}
