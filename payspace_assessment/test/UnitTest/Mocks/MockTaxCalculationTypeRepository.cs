using Application.Contracts.Persistence;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mocks
{
    public class MockTaxCalculationTypeRepository
    {
        public static Mock<ITaxCalculationTypeRepository> GetMockTaxCalculationTypeRepository(int Id)
        {
            var taxCalcType = new List<TaxCalculationType>
            {
                 new TaxCalculationType
                {
                    Id = 1,
                    Type = "Progressive",
                    Rates = new[]
                    {
                        new TaxRate
                        {
                            Id = 1,
                            From = 0,
                            To = 8350,
                            Rate = 10.0 / 100.0,
                            FlatValue = 0,
                            isFlate = false,
                            CalculationTypeId = 1,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now
                        },
                         new TaxRate
                         {
                             Id = 2,
                             From = 8351,
                             To = 33950,
                             Rate = 15.0 / 100.0,
                             FlatValue = 0,
                             isFlate = false,
                             CalculationTypeId = 1,
                             DateCreated = DateTime.Now,
                             DateModified = DateTime.Now
                         },
                          new TaxRate
                          {
                              Id = 3,
                              From = 33951,
                              To = 82250,
                              Rate = 25.0 / 100.0,
                              FlatValue = 0,
                              isFlate = false,
                              CalculationTypeId = 1,
                              DateCreated = DateTime.Now,
                              DateModified = DateTime.Now
                          },
                           new TaxRate
                           {
                               Id = 4,
                               From = 82251,
                               To = 171550,
                               Rate = 28.0 / 100.0,
                               FlatValue = 0,
                               isFlate = false,
                               CalculationTypeId = 1,
                               DateCreated = DateTime.Now,
                               DateModified = DateTime.Now
                           },
                           new TaxRate
                           {
                               Id = 5,
                               From = 171551,
                               To = 372950,
                               Rate = 33.0 / 100.0,
                               FlatValue = 0,
                               isFlate = false,
                               CalculationTypeId = 1,
                               DateCreated = DateTime.Now,
                               DateModified = DateTime.Now
                           },
                           new TaxRate
                           {
                               Id = 6,
                               From = 372951,
                               To = double.MaxValue,
                               Rate = 35.0 / 100.0,
                               FlatValue = 0,
                               isFlate = false,
                               CalculationTypeId = 1,
                               DateCreated = DateTime.Now,
                               DateModified = DateTime.Now
                           }
                    },
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                 new TaxCalculationType
                 {
                     Id = 2,
                     Type = "Flat Value",
                     Rates = new[]
                    {
                        new TaxRate
                       {
                           Id = 7,
                           From = 200000,
                           To = double.MaxValue,
                           Rate = 0,
                           FlatValue = 10000,
                           isFlate = true,
                           CalculationTypeId = 2,
                           DateCreated = DateTime.Now,
                           DateModified = DateTime.Now
                       },
                       new TaxRate
                       {
                           Id = 8,
                           From = 0,
                           To = 200000 - 1,
                           Rate = 5.0 / 100.0,
                           FlatValue = 0,
                           isFlate = true,
                           CalculationTypeId = 2,
                           DateCreated = DateTime.Now,
                           DateModified = DateTime.Now
                       }
                    },
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                 new TaxCalculationType
                 {
                     Id = 3,
                     Type = "Flat Rate",
                     Rates = new[]
                    {
                        new TaxRate
                       {
                           Id = 9,
                           From = 0,
                           To = 0,
                           Rate = 17.5 / 100,
                           FlatValue = 0,
                           isFlate = true,
                           CalculationTypeId = 3,
                           DateCreated = DateTime.Now,
                           DateModified = DateTime.Now
                       }
                    },
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 }
            };

            var mockRepo = new Mock<ITaxCalculationTypeRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(taxCalcType);
            mockRepo.Setup(r => r.GetByTaxCalculationTypeId(Id)).ReturnsAsync(taxCalcType.Where(x => x.Id == Id).FirstOrDefault);


            return mockRepo;
        }
    }
}
