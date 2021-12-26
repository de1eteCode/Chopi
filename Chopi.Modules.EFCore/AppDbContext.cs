using Chopi.Modules.EFCore.Entities.CarDealership;
using Chopi.Modules.EFCore.Entities.CarDealership.Configurations;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Entities.Identity.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chopi.Modules.EFCore
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken> 
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

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
            #region CarDealership
            builder.ApplyConfiguration(new ConfigurationAutopart());
            builder.ApplyConfiguration(new ConfigurationCar());
            builder.ApplyConfiguration(new ConfigurationComplete());
            builder.ApplyConfiguration(new ConfigurationCompleteCar());
            builder.ApplyConfiguration(new ConfigurationCountry());
            builder.ApplyConfiguration(new ConfigurationCustomCar());
            builder.ApplyConfiguration(new ConfigurationManufacturer());
            builder.ApplyConfiguration(new ConfigurationModel());
            builder.ApplyConfiguration(new ConfigurationOrder());
            #region Transits
            builder.ApplyConfiguration(new ConfigurationCompleteToAutopart());
            builder.ApplyConfiguration(new ConfigurationCustomCarToAutopart());
            builder.ApplyConfiguration(new ConfigurationModelToAutopart());
            #endregion
            #endregion
        }

        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<Autopart> Autoparts { get; set; }
        public virtual DbSet<Complete> Completes { get; set; }
        public virtual DbSet<CompleteCar> CompleteCars { get; set; }
        public virtual DbSet<CustomCar> CustomCars { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public virtual DbSet<CompleteToAutopart> CompleteToAutoparts { get; set; }
        public virtual DbSet<CustomCarToAutopart> CustomCarToAutoparts { get; set; }
        public virtual DbSet<ModelToAutopart> ModelToAutoparts { get; set; }
    }
}
