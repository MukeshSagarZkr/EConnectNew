using PropertyMicroservice.Models;

namespace PropertyMicroservice.Repository
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertyAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task AddPropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int id);
    }
}
