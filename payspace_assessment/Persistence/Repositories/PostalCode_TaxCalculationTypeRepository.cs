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
    public class PostalCode_TaxCalculationTypeRepository : GenericRepository<PostalCode_TaxCalculationType>, IPostalCode_TaxCalculationTypeRepository
    {
        public PostalCode_TaxCalculationTypeRepository(TaxCalculationDbContext context) : base(context) 
        {
            
        }

        public async Task<PostalCode_TaxCalculationType> GetByPostalCodeId(int postalCodeId)
        {
            var postalcodeTaxcalcType = await _context.PostalCode_TaxCalculationType.Where(p=>p.PostalCodeId == postalCodeId).Include(q=>q.PostalCode).Include(q=>q.TaxCalculationType).FirstOrDefaultAsync();
            return postalcodeTaxcalcType;
        }

        public async Task<TaxRate> GetByTaxCalculationTypeIdAndAnnualIncome(double AnnualIncome, TaxCalculationType postalcodeTaxcalcType)
        {
            var TaxCalculationType_TaxRates = new TaxRate();
            var taxTypeRates = postalcodeTaxcalcType.Rates;
            switch (postalcodeTaxcalcType.Id)
            {
                case 1:
                    {
                        // Progressive rate
                        // Flat Value
                        TaxCalculationType_TaxRates = taxTypeRates.Where(t => AnnualIncome >= t.From && AnnualIncome <= t.To).FirstOrDefault();
                        break;
                    }
                case 2:
                    {
                        // Progressive rate
                        // Flat Value
                        TaxCalculationType_TaxRates = taxTypeRates.Where(t => AnnualIncome >= t.From  && AnnualIncome <= t.To ).FirstOrDefault();
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
