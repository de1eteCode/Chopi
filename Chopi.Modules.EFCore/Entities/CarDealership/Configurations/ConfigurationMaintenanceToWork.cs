using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationMaintenanceToWork : IEntityTypeConfiguration<MaintenanceToWork>
    {
        public void Configure(EntityTypeBuilder<MaintenanceToWork> builder)
        {
            builder
                .ToTable("MaintenanceWork");

            builder
                .HasKey(e => new { e.MaintenanceId, e.WorkId });

            builder
                .HasOne(e => e.Work)
                .WithMany(e => e.Maintenances)
                .HasForeignKey(e => e.WorkId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.Maintenance)
                .WithMany(e => e.Works)
                .HasForeignKey(e => e.MaintenanceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}