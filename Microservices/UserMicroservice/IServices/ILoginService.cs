using WebApi.Models;

namespace Entities.Models
{
    public interface ILoginService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Login GetById(int id);
        //Task<IEnumerable<Login>> GetLoginsAsync();
        //Task<Login> GetLoginByIdAsync(int id);
        //Task AddLoginAsync(Login login);
        //Task UpdateLoginAsync(Login login);
        //Task DeleteLoginAsync(int id);
    }
}
