using Chopi.API.Models;
using Chopi.Modules.EFCore.Repositories.EntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.EFCore.Repositories.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Chopi.API
{
    public static class DependencyInjection
    {
        public static void Inject(ref IServiceCollection services)
        {
            EntitiesRepo(ref services);
            Units(ref services);
            Transients(ref services);
            Others(ref services);
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
            services.AddTransient<ICompleteToAutopartRepository, CompleteToAutopartsRepository>();
            services.AddTransient<ICustomCarToAutopartRepository, CustomCarToAutopartRepository>();
            services.AddTransient<IModelToAutopartRepository, ModelToAutopartRepository>();
            #endregion
        }

        private static void Others(ref IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddSignalR();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Car dealership Chopi API", Version = "v1" });
            });
        }

        private static void Transients(ref IServiceCollection services)
        {
            services.AddSingleton<SignalRConnections>();
        }

        private static void Units(ref IServiceCollection services)
        {
            services.AddTransient<IUnitOfRoot, UnitOfRoot>();
        }

    }
}
