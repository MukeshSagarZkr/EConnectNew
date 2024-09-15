using Microsoft.EntityFrameworkCore;
using PropertyMicroservice.Models;

namespace PropertyMicroservice.Repository
{
	public class PropertyRepository : IPropertyRepository
	{
		private EconnectContext _context = new EconnectContext();
		public async Task AddPropertyAsync(Property property)
		{
			_context.Properties.Add(property);
			await _context.SaveChangesAsync();
		}

		public async Task DeletePropertyAsync(int id)
		{
			var property = await _context.Properties.FindAsync(id);
			if (property != null)
			{
				_context.Properties.Remove(property);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Property>> GetPropertyAsync()
		{
			return await _context.Properties.ToListAsync();
		}

		public async Task<Property> GetPropertyByIdAsync(int id)
		{
			return await _context.Properties.FindAsync(id);
		}

		public async Task UpdatePropertyAsync(Property property)
		{
			_context.Properties.Update(property);
			await _context.SaveChangesAsync();
		}
	}
}
