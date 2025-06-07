using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP3.Models;

namespace TP3.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CountryName)
                .HasMaxLength(100)
                .HasColumnName("Name");

            builder.Property(c => c.CountryCode)
                .HasMaxLength(10)
                .HasColumnName("Code");
            builder.HasData(
                 new Country { Id = 1, CountryCode = "BR", CountryName = "Brasil" },
                 new Country { Id = 2, CountryCode = "US", CountryName = "Estados Unidos" }
);
        }
    }
}
