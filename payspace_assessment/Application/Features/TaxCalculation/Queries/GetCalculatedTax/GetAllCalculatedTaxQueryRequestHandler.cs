using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.TaxCalculation.Queries.GetCalculatedTax
{
    public class GetAllCalculatedTaxQueryRequestHandler : IRequestHandler<GetAllCalculatedTaxQuery, List<CalculatedTaxDto>>
    {
        private readonly ICalculatedTaxRepository _genericRepository;
        private readonly IMapper _mapper;
        public GetAllCalculatedTaxQueryRequestHandler(ICalculatedTaxRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<CalculatedTaxDto>> Handle(GetAllCalculatedTaxQuery request, CancellationToken cancellationToken)
        {

            var calculatedTax = await _genericRepository.GetAllCalculatedTax();
            return _mapper.Map<List<CalculatedTaxDto>>(calculatedTax);
        }
    }
}
