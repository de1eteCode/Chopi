using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks
{
    /// <summary>
    /// Содержит аккаунты
    /// </summary>
    public interface IUnitOfAccounts : IUnitOfWork
    {
        IUserLoginRepository UserLoginRepository { get; }
        IUserClaimRepository UserClaimRepository { get; }
        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserTokenRepository UserTokenRepository { get; }
        IPassportRepository PassportRepository { get; }
    }
}
