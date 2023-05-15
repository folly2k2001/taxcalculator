using AutoMapper;
using TaxCalculationUI.Models;
using TaxCalculationUI.Models.CalculatedTax;

namespace TaxCalculationUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CreateCalculatedTaxViewModel, CreateCalculatedTaxCommand>().ReverseMap();

            CreateMap<UpdateCalculatedTaxCommand, CalculatedTaxDto>().ReverseMap();
        }
    }
}
