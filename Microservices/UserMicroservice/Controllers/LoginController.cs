using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Repository;
using WebApi.Models;

namespace UserMicroservice.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _loginRepository;

		public LoginController(ILoginService loginRepository)
		{
			_loginRepository = loginRepository;
		}


		[HttpPost("authenticate")]
		public IActionResult Authenticate(AuthenticateRequest model)
		{
			var response = _loginRepository.Authenticate(model);
			if (response == null)
			{
				return BadRequest(new { message = "Username or password is incorrect" });
			}
			else
			{
				return Ok(response);
			}
		}
	}
}
