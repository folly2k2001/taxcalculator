using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class CalculatedTaxRepository : GenericRepository<CalculatedTax>, ICalculatedTaxRepository
    {
        public CalculatedTaxRepository(TaxCalculationDbContext context) : base(context)
        {
            
        }
        public async Task CreateCalculatedTax(double taxAmount,double annualIncome, double taxRate)
        {
            var calculatedTax = new CalculatedTax() { TaxAmount = taxAmount,
                                                      TaxRate = taxRate, 
                                                      AnnualIncome = annualIncome
            };
            _context.CalculatedTaxes.Add(calculatedTax);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CalculatedTax>> GetAllCalculatedTax()
        {
            return await _context.CalculatedTaxes.ToListAsync();
        }
    }
}
