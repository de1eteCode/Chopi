using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{

    internal class ConfigurationCustomCar : IEntityTypeConfiguration<CustomCar>
    {
        public void Configure(EntityTypeBuilder<CustomCar> builder)
        {
            builder
                .ToTable("CustomCars");

            builder
                .Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder
                .HasKey(e => e.Id);

            builder
                .HasMany(e => e.Autoparts)
                .WithMany(e => e.CustomCars)
                .UsingEntity<CustomCarToAutopart>(
                    j => j
                        .HasOne(pe => pe.Autopart)
                        .WithMany(pe => pe.AutopartCustomCar)
                        .HasForeignKey(pe => pe.AutopartId),
                    j => j
                        .HasOne(pe => pe.CustomCar)
                        .WithMany(pe => pe.CustomCarAutopart)
                        .HasForeignKey(pe => pe.CustomCarId)
                );
        }
    }

}
