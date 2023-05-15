using Domain;

namespace Application.Contracts.Persistence
{
    public interface ICalculatedTaxRepository : IGenericRepository<CalculatedTax>
    {
        Task<List<CalculatedTax>> GetAllCalculatedTax();
        Task CreateCalculatedTax(double taxAmount, double AnnualIncome, double taxRate);
    }
}
