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
    public class PostalCodeRepository : GenericRepository<PostalCode>, IPostalCodeRepository
    {
        public PostalCodeRepository(TaxCalculationDbContext context) : base(context)
        {
            
        }


        public async Task<PostalCode> GetPostalCodeByCode(string code)
        {
            var postalCode = await _context.PostalCodes.Where(p => p.Code == code).Include(q=>q.PostalCode_TaxCalculationTypes).FirstOrDefaultAsync();
            return postalCode;
        }

    }
}
