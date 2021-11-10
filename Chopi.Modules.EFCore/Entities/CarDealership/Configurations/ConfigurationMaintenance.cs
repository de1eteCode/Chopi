using Chopi.Modules.EFCore.Entities.CarDealership.TO;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationMaintenance : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder
                .ToTable("Maintenances");

            builder
                .Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.DateOfRecording)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(e => e.DateOfWork)
                .HasColumnType("date")
                .IsRequired(false);

            builder
                .Property(e => e.DateOfEnded)
                .HasColumnType("date")
                .IsRequired(false);

            builder
                .HasOne(e => e.Status)
                .WithMany()
                .HasForeignKey(e => e.StatusId);

            builder
                .HasMany(e => e.Works)
                .WithMany(e => e.Maintenances)
                .UsingEntity<MaintenanceToWork>(
                    j => j
                        .HasOne(pe => pe.Work)
                        .WithMany(pe => pe.WorkMaintenance)
                        .HasForeignKey(pe => pe.WorkID),
                    j => j
                        .HasOne(pe => pe.Maintenance)
                        .WithMany(pe => pe.MaintenanceWork)
                        .HasForeignKey(pe => pe.MaintenanceID)
                );
        }
    }

}
