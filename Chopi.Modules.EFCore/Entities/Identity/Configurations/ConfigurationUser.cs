using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chopi.Modules.EFCore.Entities.Identity.Configurations
{
    internal class ConfigurationUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder
                .HasOne(e => e.Passport)
                .WithOne()
                .HasForeignKey<User>(e => e.PassportId)
                .IsRequired();
        }
    }
}
