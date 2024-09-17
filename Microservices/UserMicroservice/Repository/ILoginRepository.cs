using UserMicroservice.Models;

namespace UserMicroservice.Repository
{
    public interface ILoginRepository
    {
        Task<IEnumerable<Login>> GetLoginsAsync();
        Task<Login> GetLoginByIdAsync(int id);
        Task AddLoginAsync(Login login);
        Task UpdateLoginAsync(Login login);
        Task DeleteLoginAsync(int id);
    }
}
