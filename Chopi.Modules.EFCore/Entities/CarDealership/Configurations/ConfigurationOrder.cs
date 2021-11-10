using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.CarDealership.Configurations
{
    internal class ConfigurationOrder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Orders");

            builder
                .Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.CodeOrder)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder
                .Property(e => e.PaidPrice)
                .HasColumnType("money")
                .IsRequired();

            builder
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            builder
                .HasOne(e => e.Car)
                .WithOne()
                .HasForeignKey<Order>(e => e.CarId);
        }
    }

}
