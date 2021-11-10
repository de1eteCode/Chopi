using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationCompleteCar : IEntityTypeConfiguration<CompleteCar>
    {
        public void Configure(EntityTypeBuilder<CompleteCar> builder)
        {
            builder
                .ToTable("CompleteCars");

            builder
                .Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder
                .HasKey(e => e.Id);

            builder
                .HasOne(e => e.Complete)
                .WithMany()
                .HasForeignKey(e => e.CompleteId);
        }
    }

}
