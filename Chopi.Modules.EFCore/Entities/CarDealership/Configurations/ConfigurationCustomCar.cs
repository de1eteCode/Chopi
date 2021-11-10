using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{

    internal class ConfigurationCustomCar : IEntityTypeConfiguration<CustomCar>
    {
        public void Configure(EntityTypeBuilder<CustomCar> builder)
        {
            builder
                .ToTable("CustomCars");

            //builder
            //    .HasMany(e => e.Autoparts)
            //    .WithMany(e => e.CustomCars)
            //    .UsingEntity<CustomCarToAutopart>(
            //        j => j
            //            .HasOne(pe => pe.Autopart)
            //            .WithMany(pe => pe.AutopartCustomCar)
            //            .HasForeignKey(pe => pe.AutopartId)
            //            .OnDelete(DeleteBehavior.ClientSetNull),
            //        j => j
            //            .HasOne(pe => pe.CustomCar)
            //            .WithMany(pe => pe.CustomCarAutopart)
            //            .HasForeignKey(pe => pe.CustomCarId)
            //            .OnDelete(DeleteBehavior.ClientSetNull),
            //        j =>
            //        {
            //            j.HasKey(e => new { e.AutopartId, e.CustomCarId });
            //            j.ToTable("CustomCarToAutopart");
            //        }
            //    );
        }
    }

}
