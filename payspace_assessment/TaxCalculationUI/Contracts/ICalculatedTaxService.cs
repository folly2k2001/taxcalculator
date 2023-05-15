using TaxCalculationUI.Models.CalculatedTax;
using TaxCalculationUI.Services;

namespace TaxCalculationUI.Contracts
{
    public partial interface ICalculatedTaxService
    {
        Task<List<CalculatedTaxDto>> GetCalculatedTaxes();
        Task<CalculatedTaxDto> GetDetailCalculatedTaxes(int id);
        Task<HttpResponseMessage> CreateCalculatedTax(CreateCalculatedTaxViewModel calculatedTax);
        Task<HttpResponseMessage> UpdateCalculatedTax(CalculatedTaxDto calculatedTax);
        Task<HttpResponseMessage> DeleteCalculatedTax(int id);
    }
}
