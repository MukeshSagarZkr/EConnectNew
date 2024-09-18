using Entities.Models;

namespace CompanyMicroservice.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanyAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task AddCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);
    }
}
