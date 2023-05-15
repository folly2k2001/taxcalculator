using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TaxCalculationType_TaxRatesRepository : GenericRepository<PostalCode_TaxCalculationType_TaxRates>, ITaxCalculationType_TaxRatesRepository
    {
        public TaxCalculationType_TaxRatesRepository(TaxCalculationDbContext context) : base(context)
        {
            
        }

        public async Task<PostalCode_TaxCalculationType_TaxRates> GetByTaxCalculationTypeIdAndAnnualIncome(int taxCalculationTypeId, double AnnualIncome)
        {
            var TaxCalculationType_TaxRates = new PostalCode_TaxCalculationType_TaxRates();
            var taxTypeRates = await _context.PostalCode_TaxCalculationType_TaxRates.Where(t => t.PostalCode_TaxCalculationTypeId == taxCalculationTypeId).
                                                           Include(t => t.PostalCode_TaxCalculationType).Include(t => t.TaxRate).ToListAsync();
            switch (taxCalculationTypeId)
            {
                case 1:
                case 2:
                    {
                        // Progressive rate
                       
                        TaxCalculationType_TaxRates = taxTypeRates.Where(t => t.TaxRate.From >= AnnualIncome && t.TaxRate.To <= AnnualIncome).FirstOrDefault();
                        break;
                    }
                case 3:
                    {
                        // Flat rate
                        TaxCalculationType_TaxRates = taxTypeRates.FirstOrDefault();
                        break;
                    }

                default:
                    break;
            }
            return TaxCalculationType_TaxRates;
        }
    }
}
