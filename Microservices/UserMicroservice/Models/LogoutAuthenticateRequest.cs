using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
	public class LogoutAuthenticateRequest
	{
		[Required]
		public int Id { get; set; }

	   // [Required]
	   //  public string RefreshToken { get; set; }
		[Required]
		public string RequestSource { get; set; }
	}
}