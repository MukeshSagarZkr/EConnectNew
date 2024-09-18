using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AuthenticateTokenRequest
    {
        [Required]
        public string token { get; set; }

        [Required]
        public string refreshToken { get; set; }
      

    }
}