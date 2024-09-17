using ContactMicroservice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Generators;

namespace ContactMicroservice.Repository
{
	public class LoginRepository : ILoginRepository
	{
		private readonly EconnectContext _context;
		private readonly IConfiguration _configuration;

		public LoginRepository(EconnectContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		public async Task<object> AuthenticateUser(string username, string password, string shortName)
		{
			var user = await _context.Logins
				.Where(p => p.Login1 == username && p.ShortName == shortName)
				.FirstOrDefaultAsync();

			if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password)) // Verifying hashed password
			{
				var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Login1),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};

				//var userRoles = await _context.UserRoles
				//    .Where(ur => ur.UserId == user.Id)
				//    .Select(ur => ur.Role.Name)
				//    .ToListAsync();

				//foreach (var userRole in userRoles)
				//{
				//    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
				//}

				var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

				var token = new JwtSecurityToken(
					issuer: _configuration["JWT:ValidIssuer"],
					audience: _configuration["JWT:ValidAudience"],
					expires: DateTime.Now.AddHours(3),
					claims: authClaims,
					signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
				);

				return new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token),
					expiration = token.ValidTo
				};
			}

			return null;
		}

	}
}
