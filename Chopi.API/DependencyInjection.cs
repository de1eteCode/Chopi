using Chopi.Modules.EFCore.Repositories.EntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.EFCore.Repositories.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Chopi.API
{
    public static class DependencyInjection
    {
        public static void Inject(ref IServiceCollection services)
        {
            EntitiesRepo(ref services);
            Units(ref services);
        }

        private static void Units(ref IServiceCollection services)
        {
            #if DEBUG

            services.AddTransient<IUnitOfRoot, UnitOfRoot>();

            #endif
        }

        private static void EntitiesRepo(ref IServiceCollection services)
        {
            services.AddTransient<IPassportRepository, PassportRepository>();
            services.AddTransient<IRoleClaimRepository, RoleClaimRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserClaimRepository, UserClaimRepository>();
            services.AddTransient<IUserLoginRepository, UserLoginRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IUserTokenRepository, UserTokenRepository>();
        }
    }
}
