using Chopi.Modules.EFCore.Repositories.EntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.EFCore.Repositories.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Chopi.API.StartupConfiguration
{
    public static class DependencyInjectionConfiguration
    {
        public static void Configure(ref IServiceCollection services)
        {
            EntitiesRepo(ref services);
            Units(ref services);
        }

        private static void Units(ref IServiceCollection services)
        {
            services.AddTransient<IUnitOfRoot, UnitOfRoot>();
        }

        private static void EntitiesRepo(ref IServiceCollection services)
        {
            #region Identity
            services.AddTransient<IPassportRepository, PassportRepository>();
            services.AddTransient<IRoleClaimRepository, RoleClaimRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserClaimRepository, UserClaimRepository>();
            services.AddTransient<IUserLoginRepository, UserLoginRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IUserTokenRepository, UserTokenRepository>();
            #endregion
            #region CarDealership
            services.AddTransient<IAutopartRepository, AutopartRepository>();
            services.AddTransient<ICompleteCarRepository, CompleteCarRepository>();
            services.AddTransient<ICompleteRepository, CompleteRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICustomCarRepository, CustomCarRepository>();
            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            #endregion
        }
    }
}
