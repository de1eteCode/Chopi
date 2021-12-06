using Chopi.Modules.EFCore.Entities.CarDealership;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class CompleteRepository : GenericRepository<Complete>, ICompleteRepository
    {
        public CompleteRepository(AppDbContext context) : base(context)
        {
        }
    }

}
