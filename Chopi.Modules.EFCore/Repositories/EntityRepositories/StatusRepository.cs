using Chopi.Modules.EFCore.Entities.CarDealership.TO;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(AppDbContext context) : base(context)
        {
        }
    }

}
