using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class UserTokenRepository : GenericRepository<UserToken>, IUserTokenRepository
    {
        public UserTokenRepository(AppContext context) : base(context)
        {
        }
    }
}
