using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationCompleteToAutopart : IEntityTypeConfiguration<CompleteToAutopart>
    {
        public void Configure(EntityTypeBuilder<CompleteToAutopart> builder)
        {
            builder
                .ToTable("CompleteAutopart");

            builder
                .HasKey(e => new { e.AutopartId, e.CompleteId });

            builder
                .HasOne(e => e.Autopart)
                .WithMany(e => e.Completes)
                .HasForeignKey(e => e.AutopartId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.Complete)
                .WithMany(e => e.Autoparts)
                .HasForeignKey(e => e.CompleteId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}