using WebApi.Models;

namespace Entities.Models
{
	public interface ILoginService
	{
		AuthenticateResponse Authenticate(AuthenticateRequest model);
		Login GetById(int id);
	}
}
