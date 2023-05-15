using Domain;

namespace Application.Contracts.Persistence
{
    public interface IPostalCodeRepository : IGenericRepository<PostalCode>
    {
        Task<PostalCode> GetPostalCodeByCode(string code);
    }
}
