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
    public class MockPostalCodeRepository
    {
        public static Mock<IPostalCodeRepository> GetMockPostalCodeRepository(string postalCode)
        {
            var postalCodes = new List<PostalCode>
            {
                new PostalCode
                {
                    Id = 1,
                    Code = "7441",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                 new PostalCode
                 {
                     Id = 2,
                     Code = "A100",
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                  new PostalCode
                  {
                      Id = 3,
                      Code = "7000",
                      DateCreated = DateTime.Now,
                      DateModified = DateTime.Now
                  },
                   new PostalCode
                   {
                       Id = 4,
                       Code = "1000",
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now
                   }
            };

            var mockRepo = new Mock<IPostalCodeRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(postalCodes);
            mockRepo.Setup(r=>r.GetPostalCodeByCode(postalCode)).ReturnsAsync(postalCodes.Where(x=>x.Code == postalCode).FirstOrDefault);


            return mockRepo;
        }
    }
}
