using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class UserClaimRepository : GenericRepository<UserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(AppContext context) : base(context)
        {
        }
    }
}
