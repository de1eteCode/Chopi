using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationAutopart : IEntityTypeConfiguration<Autopart>
    {
        public void Configure(EntityTypeBuilder<Autopart> builder)
        {
            builder
                .ToTable("Autoparts");

            builder
                .Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Article)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(e => e.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(e => e.Description)
                .HasColumnType("text")
                .IsRequired(false);

            builder
                .Property(e => e.Price)
                .HasColumnType("money")
                .IsRequired();

            builder
                .HasOne(e => e.Manufacturer)
                .WithMany()
                .HasForeignKey(e => e.Manufacturer.Id);
        }
    }
}
