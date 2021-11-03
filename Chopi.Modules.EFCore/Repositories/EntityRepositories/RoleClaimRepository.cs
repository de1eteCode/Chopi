using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class RoleClaimRepository : GenericRepository<RoleClaim>, IRoleClaimRepository
    {
        public RoleClaimRepository(AppContext context) : base(context)
        {
        }
    }
}
