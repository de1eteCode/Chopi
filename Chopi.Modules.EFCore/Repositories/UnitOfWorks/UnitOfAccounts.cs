using Chopi.Modules.EFCore.Repositories.EntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;

namespace Chopi.Modules.EFCore.Repositories.UnitOfWorks
{
    public class UnitOfAccounts : UnitOfWork, IUnitOfAccounts
    {
        public UnitOfAccounts(AppContext context) : base(context)
        {
            UserLoginRepository = new UserLoginRepository(context);
            UserClaimRepository = new UserClaimRepository(context);
            UserRepository = new UserRepository(context);
            UserRoleRepository = new UserRoleRepository(context);
            UserTokenRepository = new UserTokenRepository(context);
            PassportRepository = new PassportRepository(context);
            RoleRepository = new RoleRepository(context);
        }

        public IUserLoginRepository UserLoginRepository { get; }

        public IUserClaimRepository UserClaimRepository { get; }

        public IUserRepository UserRepository { get; }

        public IUserRoleRepository UserRoleRepository { get; }

        public IUserTokenRepository UserTokenRepository { get; }

        public IPassportRepository PassportRepository { get; }

        public IRoleRepository RoleRepository { get; }
    }
}
