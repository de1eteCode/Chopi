using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.Identity.Configurations
{
    internal class ConfigurationPassport : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.ToTable("Passports");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.FirstName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.SecondName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.MiddleName)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.Series)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder
                .Property(x => x.Number)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder
                .Property(x => x.ResidenceRegistration)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(x => x.Citizenship)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(x => x.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
