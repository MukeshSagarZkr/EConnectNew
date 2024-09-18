using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
	public class AuthenticateRequest
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
		[Required]
		public string RequestSource { get; set; }
		//public string DeviceDetail { get; set; }
		//public string forcefullylogin { get; set; }

	}
}