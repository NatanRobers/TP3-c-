using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP3.Models;

namespace TP3.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnName("CityName");
            builder.HasData(
                 new City { Id = 1, Name = "Rio de Janeiro", CountryId = 1 },
                 new City { Id = 2, Name = "São Paulo", CountryId = 1 },
                 new City { Id = 3, Name = "New York", CountryId = 2 }
); 
        }
    }
}
