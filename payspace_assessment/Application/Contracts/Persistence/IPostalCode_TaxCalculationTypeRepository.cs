using Domain;

namespace Application.Contracts.Persistence
{
    public interface IPostalCode_TaxCalculationTypeRepository : IGenericRepository<PostalCode_TaxCalculationType>
    {
        Task<PostalCode_TaxCalculationType> GetByPostalCodeId(int postalCodeId);
        Task<TaxRate>  GetByTaxCalculationTypeIdAndAnnualIncome(double AnnualIncome, TaxCalculationType postalcodeTaxcalcType);
    }
}
