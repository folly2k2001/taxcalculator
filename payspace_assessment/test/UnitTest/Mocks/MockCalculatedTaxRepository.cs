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
    public class MockCalculatedTaxRepository
    {
        public static Mock<ICalculatedTaxRepository> GetMockCalculatedTaxRepository()
        {
            var calculatedTax = new List<CalculatedTax>
            {
               
            };

            var mockRepo = new Mock<ICalculatedTaxRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(calculatedTax);


            return mockRepo;
        }
    }
}
