using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TaxCalculationTypeRepository : GenericRepository<TaxCalculationType>, ITaxCalculationTypeRepository
    {
        public TaxCalculationTypeRepository(TaxCalculationDbContext context) : base(context)
        {
            
        }
        public async Task<TaxCalculationType> GetByTaxCalculationTypeId(int taxCalculationTypeId)
        {

            return await _context.TaxCalculationType.Where(t=>t.Id == taxCalculationTypeId).Include(x=>x.PostalCode_TaxCalculationTypes).Include(t=>t.Rates).FirstOrDefaultAsync();
        }
    }
}
