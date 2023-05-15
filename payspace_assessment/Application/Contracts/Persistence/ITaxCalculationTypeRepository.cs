using Domain;

namespace Application.Contracts.Persistence
{
    public interface ITaxCalculationTypeRepository : IGenericRepository<TaxCalculationType>
    {
        Task<TaxCalculationType> GetByTaxCalculationTypeId(int taxCalculationTypeId);
    }
}
