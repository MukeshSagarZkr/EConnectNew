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
using Entities.Models;

namespace ContactMicroservice.Repository
{
	public class ContactRepository : ILoginRepository
	{
		private readonly EconnectContext _context;
		private readonly IConfiguration _configuration;

		public ContactRepository(EconnectContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		

	}
}
