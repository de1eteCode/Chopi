using Chopi.Modules.EFCore.Repositories.EntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;

namespace Chopi.Modules.EFCore.Repositories.UnitOfWorks
{
#if DEBUG

    /// <summary>
    /// Содержит все типы репозиториев. Создан для дебага.
    /// </summary>
    public class UnitOfRoot : UnitOfWork, IUnitOfRoot
    {
        public UnitOfRoot(AppContext context) : base(context)
        {
            Passports = new PassportRepository(context);
            RoleClaims = new RoleClaimRepository(context);
            Roles = new RoleRepository(context);
            UserClaims = new UserClaimRepository(context);
            UserLogins = new UserLoginRepository(context);
            Users = new UserRepository(context);
            UserRoles = new UserRoleRepository(context);
            UserTokens = new UserTokenRepository(context);
        }

        public IPassportRepository Passports { get; }

        public IRoleClaimRepository RoleClaims { get; }

        public IRoleRepository Roles { get; }

        public IUserClaimRepository UserClaims { get; }

        public IUserLoginRepository UserLogins { get; }

        public IUserRepository Users { get; }

        public IUserRoleRepository UserRoles { get; }

        public IUserTokenRepository UserTokens { get; }
    }

#endif
}
