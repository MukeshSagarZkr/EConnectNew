using Entities.Models;

namespace WebApi.Models
{
	public class AuthenticateResponse
	{
		public int Id { get; set; }
		//public string FirstName { get; set; }
		//public string LastName { get; set; }
		public string Username { get; set; }
		public string Token { get; set; }
		public string RefreshToken { get; set; }
		//public string Institutecd { get; set; }
		//public string designation { get; set; }
		public AuthenticateResponse(Login user, string token , string refreshToken)
		{
			Id = user.LoginId;
			//FirstName = user.;
			//LastName = user.LastName;
			//Username = user.Username;
			Token = token;
			RefreshToken = refreshToken;
			//Institutecd = user.Institutecd;
			//designation= user.designation;
		}
	}
}