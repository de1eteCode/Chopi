using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class CustomCarToAutopartRepository : GenericRepository<CustomCarToAutopart>, ICustomCarToAutopartRepository
    {
        public CustomCarToAutopartRepository(AppDbContext context) : base(context)
        {
        }
    }
}
