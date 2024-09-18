using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace CompanyMicroservice.Repository
{
	public class CompanyRepository : ICompanyRepository
	{
		private EconnectContext _context = new EconnectContext();
		public async Task AddCompanyAsync(Company company)
		{
			_context.Companies.Add(company);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCompanyAsync(int id)
		{
			var company = await _context.Companies.FindAsync(id);
			if (company != null)
			{
				_context.Companies.Remove(company);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Company>> GetCompanyAsync()
		{
			return await _context.Companies.ToListAsync();
		}

		public async Task<Company> GetCompanyByIdAsync(int id)
		{
			return await _context.Companies.FindAsync(id);
		}

		public async Task UpdateCompanyAsync(Company Company)
		{
			_context.Companies.Update(Company);
			await _context.SaveChangesAsync();
		}
	}
}
