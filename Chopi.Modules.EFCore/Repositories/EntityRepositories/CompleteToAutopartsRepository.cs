using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class CompleteToAutopartsRepository : GenericRepository<CompleteToAutopart>, ICompleteToAutopartRepository
    {
        public CompleteToAutopartsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
