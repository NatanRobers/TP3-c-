using Microsoft.EntityFrameworkCore;
using TP3.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using TP3.Data.Configurations;

namespace TP3.Data
{
 
        public class CityBreaksContext : DbContext
        {
            public CityBreaksContext(DbContextOptions<CityBreaksContext> options)
            : base(options) { }

             public DbSet<Country> Countries { get; set; }
             public DbSet<City> Cities { get; set; }
             public DbSet<Property> Properties { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
        }
        public async Task DeletePropertyAsync(int id)
        {
            var prop = await Properties.FindAsync(id);
            if (prop != null && prop.DeletedAt == null)
            {
                prop.DeletedAt = DateTime.UtcNow;
                await SaveChangesAsync();
            }
        }

    }


}
