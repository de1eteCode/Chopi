using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{

    internal class ConfigurationModelToAutopart : IEntityTypeConfiguration<ModelToAutopart>
    {
        public void Configure(EntityTypeBuilder<ModelToAutopart> builder)
        {
            builder
                .ToTable("ModelAutopart");

            builder
                .HasKey(e => new { e.AutopartId, e.ModelId });

            builder
                .HasOne(e => e.Autopart)
                .WithMany(e => e.Models)
                .HasForeignKey(e => e.AutopartId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.Model)
                .WithMany(e => e.SupportedAutoparts)
                .HasForeignKey(e => e.ModelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}