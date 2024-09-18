using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebApi.Models
{
	public class AuthenticateGetPrincipalRequest
	{
		[Required]
		public ClaimsPrincipal claimsPrincipal { get; set; }

		[Required]
		public string Id { get; set; }

		public AuthenticateGetPrincipalRequest(ClaimsPrincipal ClaimsPrincipal, string id)
		{
			claimsPrincipal = ClaimsPrincipal;
			Id = id;
		   
		}
	}
}