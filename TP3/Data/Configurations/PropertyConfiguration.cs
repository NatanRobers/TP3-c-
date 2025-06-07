using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP3.Models;

namespace TP3.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Name)
                .HasMaxLength(150)
                .HasColumnName("PropertyName");

            builder.Property(p => p.PricePerNight)
                .HasColumnType("decimal(10,2)");
            builder.HasData(
             new Property { Id = 1, Name = "Copacabana Vista Mar", PricePerNight = 450.00m, CityId = 1 },
             new Property { Id = 2, Name = "Flat Paulista", PricePerNight = 300.00m, CityId = 2 },
             new Property { Id = 3, Name = "Times Square Apartment", PricePerNight = 600.00m, CityId = 3 }
);

        }
    }
}
