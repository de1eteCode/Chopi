using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationCustomCarToAutopart : IEntityTypeConfiguration<CustomCarToAutopart>
    {
        public void Configure(EntityTypeBuilder<CustomCarToAutopart> builder)
        {
            builder
                .ToTable("CustomCarAutopart");

            builder
                .HasKey(e => new { e.AutopartId, e.CustomCarId });

            builder
                .HasOne(e => e.Autopart)
                .WithMany(e => e.CustomCars)
                .HasForeignKey(e => e.AutopartId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.CustomCar)
                .WithMany(e => e.Autoparts)
                .HasForeignKey(e => e.CustomCarId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}