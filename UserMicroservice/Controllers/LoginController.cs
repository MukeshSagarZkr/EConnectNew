using ContactMicroservice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Repository;

namespace UserMicroservice.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginRepository _loginRepository;

		public LoginController(ILoginRepository loginRepository)
		{
			_loginRepository = loginRepository;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
		{
			return Ok(await _loginRepository.GetLoginsAsync());
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<Login>> GetLogin(int id)
		{
			var login = await _loginRepository.GetLoginByIdAsync(id);
			if (login == null)
			{
				return NotFound(new { message = "Login not found" });
			}
			return Ok(login);
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult> AddLogin([FromBody] Login login)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _loginRepository.AddLoginAsync(login);
			return CreatedAtAction(nameof(GetLogin), new { id = login.LoginId }, login);
		}

		[HttpPut("{id}")]
		[Authorize]
		public async Task<ActionResult> UpdateLogin(int id, [FromBody] Login login)
		{
			if (id != login.LoginId)
			{
				return BadRequest(new { message = "Login ID mismatch" });
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingLogin = await _loginRepository.GetLoginByIdAsync(id);
			if (existingLogin == null)
			{
				return NotFound(new { message = "Login not found" });
			}

			await _loginRepository.UpdateLoginAsync(login);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[Authorize]
		public async Task<ActionResult> DeleteLogin(int id)
		{
			var existingLogin = await _loginRepository.GetLoginByIdAsync(id);
			if (existingLogin == null)
			{
				return NotFound(new { message = "Login not found" });
			}

			await _loginRepository.DeleteLoginAsync(id);
			return NoContent();
		}
	}
}
