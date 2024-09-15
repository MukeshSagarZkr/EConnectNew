using ContactMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using UserMicroservice.Repository;
using UsertMicroservice.Models;

namespace ContactMicroservice.Repository
{
	public class LoginRepository : ILoginRepository
	{
		private EconnectContext _context = new EconnectContext();
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
	}
}
