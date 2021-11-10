using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationModel : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder
                .ToTable("Models");

            builder
                .Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .HasOne(e => e.Manufacturer)
                .WithMany()
                .HasForeignKey(e => e.ManufacturerId);

            //builder
            //    .HasMany(e => e.SupportedAutoparts)
            //    .WithMany(e => e.Models)
            //    .UsingEntity<ModelToAutopart>(
            //        j => j
            //            .HasOne(pe => pe.Autopart)
            //            .WithMany(pe => pe.AutopartModel)
            //            .HasForeignKey(pe => pe.AutopartId)
            //            .OnDelete(DeleteBehavior.ClientSetNull),
            //        j => j
            //            .HasOne(pe => pe.Model)
            //            .WithMany(pe => pe.ModelAutopart)
            //            .HasForeignKey(pe => pe.ModelId)
            //            .OnDelete(DeleteBehavior.ClientSetNull),
            //        j =>
            //        {
            //            j.HasKey(e => new { e.ModelId, e.AutopartId });
            //            j.ToTable("ModelToAutopart");
            //        }
            //    );
        }
    }
}
