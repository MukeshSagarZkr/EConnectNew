//using ContactMicroservice.Models;

using Microsoft.Extensions.Primitives;

namespace ContactMicroservice.Repository
{
    public interface ILoginRepository
    {
        Task<object> AuthenticateUser(string username, string password, string shortName);
    }
}
