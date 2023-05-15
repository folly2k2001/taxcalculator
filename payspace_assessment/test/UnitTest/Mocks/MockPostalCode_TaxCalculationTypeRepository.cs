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
    public class MockPostalCode_TaxCalculationTypeRepository
    {
        public static Mock<IPostalCode_TaxCalculationTypeRepository> GetMockPostalCode_TaxCalculationTypeRepository(int postalCodeId)
        {
            var postalCodeTaxCalcType = new List<PostalCode_TaxCalculationType>
            {
               new PostalCode_TaxCalculationType
                    {
                        Id = 1,
                        TaxCalculationType = new TaxCalculationType
                        {
                            Id = 1,
                            Type = "Progressive",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now
                        },
                        PostalCodeId = 1,
                        PostalCode = new PostalCode
                        {
                            Id = 1,
                            Code = "7441",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now
                        },
                        TaxCalculationTypeId = 1,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                    new PostalCode_TaxCalculationType
                    {
                        Id = 2,
                        PostalCodeId = 2,
                        PostalCode = new PostalCode
                         {
                             Id = 2,
                             Code = "A100",
                             DateCreated = DateTime.Now,
                             DateModified = DateTime.Now
                         },
                        TaxCalculationType = new TaxCalculationType
                         {
                             Id = 2,
                             Type = "Flat Value",
                             DateCreated = DateTime.Now,
                             DateModified = DateTime.Now
                         },
                        TaxCalculationTypeId = 2,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                    new PostalCode_TaxCalculationType
                    {
                        Id = 3,
                        PostalCodeId = 3,
                         PostalCode = new PostalCode
                        {
                            Id = 3,
                            Code = "7000",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now
                        },
                        TaxCalculationType = new TaxCalculationType
                         {
                             Id = 3,
                             Type = "Flat Rate",
                             DateCreated = DateTime.Now,
                             DateModified = DateTime.Now
                         },
                        TaxCalculationTypeId = 3,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                    new PostalCode_TaxCalculationType
                    {
                        Id = 4,
                        PostalCodeId = 4,
                        TaxCalculationTypeId = 1,
                        PostalCode = new PostalCode
                       {
                           Id = 4,
                           Code = "1000",
                           DateCreated = DateTime.Now,
                           DateModified = DateTime.Now
                       },
                         TaxCalculationType = new TaxCalculationType
                        {
                            Id = 1,
                            Type = "Progressive",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now
                        },
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    }
            };

            var mockRepo = new Mock<IPostalCode_TaxCalculationTypeRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(postalCodeTaxCalcType);
            mockRepo.Setup(r => r.GetByPostalCodeId(postalCodeId)).ReturnsAsync(postalCodeTaxCalcType.Where(x=>x.PostalCodeId == postalCodeId).FirstOrDefault);


            return mockRepo;
        }
    }
}
