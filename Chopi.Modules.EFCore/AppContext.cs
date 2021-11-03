using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Entities.Identity.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chopi.Modules.EFCore
{
    public class AppContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken> 
    {
        public AppContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Identity
            builder.ApplyConfiguration(new ConfigurationRole());
            builder.ApplyConfiguration(new ConfigurationRoleClaim());
            builder.ApplyConfiguration(new ConfigurationUser());
            builder.ApplyConfiguration(new ConfigurationUserClaim());
            builder.ApplyConfiguration(new ConfigurationUserLogin());
            builder.ApplyConfiguration(new ConfigurationUserRole());
            builder.ApplyConfiguration(new ConfigurationUserToken());
            builder.ApplyConfiguration(new ConfigurationPassport());
            #endregion
        }

        public virtual DbSet<Passport> Passports { get; set; }
    }
}
