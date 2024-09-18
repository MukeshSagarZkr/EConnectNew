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
using Entities.Models;

namespace UserMicroservice.Repository
{
	public class LoginRepository : ILoginRepository
	{
		private EconnectContext _context = new EconnectContext();
        private readonly IConfiguration _configuration;
        public async Task AddLoginAsync(Login login)
		{
			_context.Logins.Add(login);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteLoginAsync(int id)
		{
			var login = await _context.Logins.FindAsync(id);
			if (login != null)
			{
				_context.Logins.Remove(login);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Login> GetLoginByIdAsync(int id)
		{
			return await _context.Logins.FindAsync(id);
		}

		public async Task<IEnumerable<Login>> GetLoginsAsync()
		{
			return await _context.Logins.ToListAsync();
		}

		public async Task UpdateLoginAsync(Login login)
		{
			_context.Logins.Update(login);
			await _context.SaveChangesAsync();
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
