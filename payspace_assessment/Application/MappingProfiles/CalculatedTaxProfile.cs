using Application.Features.TaxCalculation.Commands.CreateCalculatedTax;
using Application.Features.TaxCalculation.Commands.UpdateCalculatedTax;
using Application.Features.TaxCalculation.Queries.GetCalculatedTax;
using Application.Features.TaxCalculation.Queries.GetDetailCalculatedTax;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class CalculatedTaxProfile : Profile
    {
        public CalculatedTaxProfile()
        {

            CreateMap<CalculatedTaxDto, CalculatedTax>().ReverseMap(); ;
            CreateMap<CalculatedTax, CalculatedTaxDetailDto>();
            CreateMap<CreateCalculatedTaxCommand, CalculatedTax>();
            CreateMap<UpdateCalculatedTaxCommand, CalculatedTax>();
        }
    }
}
