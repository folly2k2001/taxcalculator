using Application.Contracts.Persistence;
using Application.Features.TaxCalculation.Commands.CreateCalculatedTax;
using Application.MappingProfiles;
using AutoMapper;
using Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mocks;

namespace UnitTest.Features.CalculatedTax.Command
{
   
    public class CreateCalculatedTaxCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostalCodeRepository> _postalCodeRepository;
        private readonly Mock<ICalculatedTaxRepository> _calculatedTaxRepository;
        private readonly Mock<IPostalCode_TaxCalculationTypeRepository> _postalCodeTaxCalculationTypeRepository;
        private readonly Mock<ITaxCalculationTypeRepository> _taxCalculationTypeRepository;
        public CreateCalculatedTaxCommandTest()
        {
            _postalCodeRepository = MockPostalCodeRepository.GetMockPostalCodeRepository("7441");
            _taxCalculationTypeRepository = MockTaxCalculationTypeRepository.GetMockTaxCalculationTypeRepository(1);
            _calculatedTaxRepository = MockCalculatedTaxRepository.GetMockCalculatedTaxRepository();
            _postalCodeTaxCalculationTypeRepository = MockPostalCode_TaxCalculationTypeRepository.GetMockPostalCode_TaxCalculationTypeRepository(1);
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CalculatedTaxProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task CreateCalculatedTaxTest()
        {
         
            var handler = new CreateCalculatedTaxCommandHandler(_mapper, 
                                                                _postalCodeRepository.Object, 
                                                                _postalCodeTaxCalculationTypeRepository.Object,
                                                                _taxCalculationTypeRepository.Object,
                                                                _calculatedTaxRepository.Object);

            await handler.Handle(new CreateCalculatedTaxCommand() { Amount = 5000, PostalCode = "7441" }, CancellationToken.None);

            var calculatedTax = await _calculatedTaxRepository.Object.GetAsync();
            calculatedTax.Count.ShouldBe(1);
        }
    }
}
