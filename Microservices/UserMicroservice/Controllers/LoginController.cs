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


            // var json = new System.Web.Script.SerializationJavaScriptSerializer().Serialize(model);


            var response = _loginRepository.Authenticate(model);
			if (response == null)
			{
				return BadRequest(new { message = "Username or password is incorrect" });
			}
			else { return Ok(response); }

            //string remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            //string APIName = new Uri(Request.GetDisplayUrl()).ToString();

            /////check user already login


            //string userloginmassage = _userService.checkuserlogin(response.Id, model.RequestSource, model.forcefullylogin);
            //if (userloginmassage == "false")
            //{//,string DESIGNATION
            //    _userService.SaveLoginData(response.Username, response.Token, response.Id, model, remoteIpAddress, APIName, response.RefreshToken, response.Institutecd, response.designation);
            //    return Ok(response);
            //}
            //else
            //{
            //    return Ok(new { message = "User already login." });
            //}
        }

  //      [HttpGet]
		//[Authorize]
		//public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
		//{
		//	return Ok(await _loginRepository.GetLoginsAsync());
		//}

		//[HttpGet("{id}")]
		//[Authorize]
		//public async Task<ActionResult<Login>> GetLogin(int id)
		//{
		//	var login = await _loginRepository.GetLoginByIdAsync(id);
		//	if (login == null)
		//	{
		//		return NotFound(new { message = "Login not found" });
		//	}
		//	return Ok(login);
		//}

		//[HttpPost]
		//[Authorize]
		//public async Task<ActionResult> AddLogin([FromBody] Login logins)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	await _loginRepository.AddLoginAsync(logins);
		//	return CreatedAtAction(nameof(GetLogin), new { id = logins.LoginId }, logins);
		//}

		//[HttpPut("{id}")]
		//[Authorize]
		//public async Task<ActionResult> UpdateLogin(int id, [FromBody] Login login)
		//{
		//	if (id != login.LoginId)
		//	{
		//		return BadRequest(new { message = "Login ID mismatch" });
		//	}

		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	var existingLogin = await _loginRepository.GetLoginByIdAsync(id);
		//	if (existingLogin == null)
		//	{
		//		return NotFound(new { message = "Login not found" });
		//	}

		//	await _loginRepository.UpdateLoginAsync(login);
		//	return NoContent();
		//}

		//[HttpDelete("{id}")]
		//[Authorize]
		//public async Task<ActionResult> DeleteLogin(int id)
		//{
		//	var existingLogin = await _loginRepository.GetLoginByIdAsync(id);
		//	if (existingLogin == null)
		//	{
		//		return NotFound(new { message = "Login not found" });
		//	}

		//	await _loginRepository.DeleteLoginAsync(id);
		//	return NoContent();
		//}
	}
}
