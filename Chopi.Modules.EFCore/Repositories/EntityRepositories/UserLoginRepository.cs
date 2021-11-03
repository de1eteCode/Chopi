using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class UserLoginRepository : GenericRepository<UserLogin>, IUserLoginRepository
    {
        public UserLoginRepository(AppContext context) : base(context)
        {
        }
    }
}
