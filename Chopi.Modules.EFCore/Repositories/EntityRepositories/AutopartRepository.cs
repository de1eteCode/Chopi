using Chopi.Modules.EFCore.Entities.CarDealership;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class AutopartRepository : GenericRepository<Autopart>, IAutopartRepository
    {
        public AutopartRepository(AppDbContext context) : base(context)
        {
        }
    }

}
