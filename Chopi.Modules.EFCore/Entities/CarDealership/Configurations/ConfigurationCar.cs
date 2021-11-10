using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationCar : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .ToTable("Cars");

            builder
                .Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Year)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(e => e.VIN)
                .HasColumnType("varchar(100)")
                .IsRequired(false); // т.к. например у японских авто нет vin

            builder
               .Property(e => e.Color)
               .HasColumnType("varchar(70)")
               .IsRequired();

            builder
               .Property(e => e.BasePrice)
               .HasColumnType("money")
               .IsRequired();

            builder
                .HasOne(e => e.Model)
                .WithMany()
                .HasForeignKey(e => e.ModelId);
        }
    }
}
