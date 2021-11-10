using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationComplete : IEntityTypeConfiguration<Complete>
    {
        public void Configure(EntityTypeBuilder<Complete> builder)
        {
            builder
                .ToTable("Completes");

            builder
                .Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            //builder
            //    .HasMany(e => e.Autoparts)
            //    .WithMany(e => e.Completes)
            //    .UsingEntity<CompleteToAutopart>(

            //        j => j
            //            .HasOne(pe => pe.Autopart)
            //            .WithMany(pe => pe.AutopartComplete)
            //            .HasForeignKey(pe => pe.AutopartId)
            //            .OnDelete(DeleteBehavior.ClientSetNull),
            //        j => j
            //            .HasOne(pe => pe.Complete)
            //            .WithMany(pe => pe.CompleteAutopart)
            //            .HasForeignKey(pe => pe.CompleteId)
            //            .OnDelete(DeleteBehavior.ClientSetNull),
            //        j =>
            //        {
            //            j.HasKey(e => new { e.AutopartId, e.CompleteId });
            //            j.ToTable("CompleteToAutopart");
            //        }
            //    );
        }
    }

}
