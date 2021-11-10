using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationManufacturer : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder
                .ToTable("Manufacturers");

            builder
                .Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Brand)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(e => e.INN)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(e => e.Address)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(e => e.PhoneNumber)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder
                .HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId);
        }
    }
}
