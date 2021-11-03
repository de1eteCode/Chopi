using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks
{
#if DEBUG

    /// <summary>
    /// Содержит все типы репозиториев. Создан для дебага.
    /// </summary>
    public interface IUnitOfRoot : IUnitOfWork
    {
        IPassportRepository Passports { get; }
        IRoleClaimRepository RoleClaims { get; }
        IRoleRepository Roles { get; }
        IUserClaimRepository UserClaims { get; }
        IUserLoginRepository UserLogins { get; }
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        IUserTokenRepository UserTokens { get; }
    }

#endif
}
