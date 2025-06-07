using TP3.Models;

namespace TP3.Services
{
    public interface IPropertyService
    {
        Task<List<Property>> GetAllAsync();
        Task<Property?> GetByIdAsync(int id);
        Task AddAsync(Property property);
        Task<bool> UpdateAsync(int id, Property updatedProperty);
        Task<bool> DeleteAsync(int id);
        Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string? cityName, string? propertyName);
    }
}
