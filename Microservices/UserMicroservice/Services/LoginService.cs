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
using WebApi.Models;
using System.Security.Cryptography;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using System.Data;

namespace UserMicroservice.Repository
{
	public class LoginService : ILoginService
	{
		private EconnectContext _context = new EconnectContext();
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<Login> _users = new List<Login>
        {

            // new User { Id = 1, FirstName = "Test", LastName = "User", Username = "1", Password = "P1" }

        };

        public LoginService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        public Login GetById(int id)
        {

            List<Login> userlist = new List<Login>();
            userlist = getuserdetailbyid(id.ToString());

            return userlist.FirstOrDefault(x => x.LoginId == id);
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {




            Login userlist = new Login();

            userlist = _context.Logins.Where(p => p.EmailAddress == model.Username && p.Password == model.Password).FirstOrDefault();
            //userlist = getuserdetailbyusername(model.Username);
            //if (userlist == null) return null;
            //_users = userlist;

            //var user = _users.SingleOrDefault(x => x.EmailAddress == model.Username && x.Password == model.Password);

            // return null if user not found
            if (userlist == null) return null;

            // authentication successful so generate jwt token

            var token = generateJwtToken(userlist, model.RequestSource);
            var refreshToken = GenerateRefreshToken();
            return new AuthenticateResponse(userlist, token, refreshToken);
        }

        private List<Login> getuserdetailbyid(string id)
        {
            List<Login> lstemployee = new List<Login>();
            //using (SqlConnection con = new SqlConnection(_appSettings.ConnStr))
            //{
            //    SqlCommand cmd = new SqlCommand("Select LOGINID ID,USERNAME FirstName , '' LastName, LOGINNAME  Username, PASSWD Password  from CREATEUSER  where  status='Y' and rownum<=10 and LOGINID='" + id + "'", con);
            //    cmd.CommandType = CommandType.Text;
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        User employee = new User();
            //        employee.Id = Convert.ToInt32(rdr["ID"]);
            //        employee.FirstName = rdr["FirstName"].ToString();
            //        employee.LastName = rdr["LastName"].ToString();
            //        employee.Username = rdr["Username"].ToString();
            //        employee.Password = rdr["Password"].ToString();
            //        lstemployee.Add(employee);
            //    }
            //    con.Close();
            //}
            return lstemployee;
        }

        private List<Login> getuserdetailbyusername(string username)
        {
            List<Login> lstemployee = new List<Login>();

            using (SqlConnection con = new SqlConnection(_appSettings.ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select *  from Login and EmailAddress='" + username + "'", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Login employee = new Login();
                    employee.LoginId = Convert.ToInt32(rdr["ID"]);
                    employee.EmailAddress = rdr["EmailAddress"].ToString();
                    employee.Password = rdr["Password"].ToString();
                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }


        // helper methods

        private string generateJwtToken(Login user, string RequestSource)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            ////time of token check from appsetting
            double tokenvalidityindays = 0;
            if (RequestSource == "web") { tokenvalidityindays = _appSettings.WebTokenValidity; }
            if (RequestSource == "mobile") { tokenvalidityindays = _appSettings.MobileTokenvalidity; }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.LoginId.ToString()), new Claim("name", user.EmailAddress.ToString()) }),
                //Expires = DateTime.UtcNow.AddDays(7),
                Expires = DateTime.UtcNow.AddDays(tokenvalidityindays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GenerateAccessToken(IEnumerable<Claim> claims, string RequestSource)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            double tokenvalidityindays = 0;
            if (RequestSource == "web") { tokenvalidityindays = _appSettings.WebTokenValidity; }
            if (RequestSource == "mobile") { tokenvalidityindays = _appSettings.MobileTokenvalidity; }
            var jwtToken = new JwtSecurityToken(issuer: "",
                     audience: "",
                     claims: claims,
                     // notBefore: DateTime.UtcNow,
                     expires: DateTime.UtcNow.AddDays(tokenvalidityindays),
                     signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                 );
            //var token = new JwtSecurityTokenHandler().CreateToken(jwtToken);
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }



        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public AuthenticateGetPrincipalRequest GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            string username = "";




            //var matches1 = from val in jwtSecurityToken.Claims.ToList() where val.Type == "exp" select val.Value;



            //foreach (var match1 in matches1)
            //{

            //  var username1 = match1;
            //}

            var matches = from val in jwtSecurityToken.Claims.ToList() where val.Type == "id" select val.Value;

            foreach (var match in matches)
            {

                username = match;
            }
            //    foreach (System.Security.Claims.Claim item in jwtSecurityToken.Claims.ToList())
            //{
            //    idTextBox = item.Value;

            //}

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            //    return username;
            return new AuthenticateGetPrincipalRequest(principal, username);
        }




    }
}
