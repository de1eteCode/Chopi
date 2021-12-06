using Chopi.Modules.EFCore.Entities.CarDealership.TO;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class WorkRepository : GenericRepository<Work>, IWorkRepository
    {
        public WorkRepository(AppDbContext context) : base(context)
        {
        }
    }

}
