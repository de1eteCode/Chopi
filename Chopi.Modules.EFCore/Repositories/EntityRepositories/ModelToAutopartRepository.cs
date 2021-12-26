using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class ModelToAutopartRepository : GenericRepository<ModelToAutopart>, IModelToAutopartRepository
    {
        public ModelToAutopartRepository(AppDbContext context) : base(context)
        {
        }
    }
}
