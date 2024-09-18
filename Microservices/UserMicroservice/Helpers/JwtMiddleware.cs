using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Helpers
{
	public class JwtMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly AppSettings _appSettings;
		public HttpContext context2;
		public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
		{
			_next = next;
			_appSettings = appSettings.Value;
		}

		public async Task Invoke(HttpContext context, ILoginService userService)
		{

			context.Request.EnableBuffering();
			var body="";
			// Leave the body open so the next middleware can read it.
			using (var reader = new StreamReader(
				context.Request.Body,
				encoding: Encoding.UTF8,
				detectEncodingFromByteOrderMarks: false,
				bufferSize: 1024,
				leaveOpen: true))
			{
				body = await reader.ReadToEndAsync();
				context.Request.Body.Position = 0;
			}

			var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
			if (token != null)
				attachUserToContext(context, userService, token, body);

			await _next(context);
		}

		private void attachUserToContext(HttpContext context, ILoginService userService, string token,string body)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					// set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);


				var jwtToken = (JwtSecurityToken)validatedToken;
				var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
				var userName = jwtToken.Claims.First(x => x.Type == "name").Value;

				// attach user to context on successful jwt validation
				context.Items["User"] = userService.GetById(userId);
			}
			catch
			{
				// do nothing if jwt validation fails
				// user is not attached to context so request won't have access to secure routes
			}
		}
	}
}