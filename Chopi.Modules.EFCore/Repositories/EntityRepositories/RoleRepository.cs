using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
