using Microsoft.EntityFrameworkCore;
using TP3.Data;
using TP3.Models;

namespace TP3.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly CityBreaksContext _context;

        public PropertyService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<Property>> GetAllAsync()
        {
            return await _context.Properties
                .Include(p => p.City)
                    .ThenInclude(c => c.Country)
                .Where(p => p.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Property?> GetByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.City)
                    .ThenInclude(c => c.Country)
                .FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt == null);
        }

        public async Task AddAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, Property updatedProperty)
        {
            var existing = await _context.Properties.FindAsync(id);

            if (existing == null || existing.DeletedAt != null)
                return false;

            var success = await TryUpdateModelAsync(existing, updatedProperty);
            if (!success) return false;

            await _context.SaveChangesAsync();
            return true;
        }

        private Task<bool> TryUpdateModelAsync(Property existing, Property updated)
        {
            existing.Name = updated.Name;
            existing.PricePerNight = updated.PricePerNight;
            existing.CityId = updated.CityId;
            return Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null || property.DeletedAt != null)
                return false;

            property.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string? cityName, string? propertyName)
        {
            var query = _context.Properties
                .Include(p => p.City)
                    .ThenInclude(c => c.Country)
                .AsQueryable();

            query = query.Where(p => p.DeletedAt == null);

            if (!string.IsNullOrWhiteSpace(cityName))
            {
                query = query.Where(p => EF.Functions.Like(p.City.Name, $"%{cityName}%"));
            }

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{propertyName}%"));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight <= maxPrice);
            }

            return await query.ToListAsync();
        }
    }
}
