using Chopi.Modules.EFCore.Entities.CarDealership.TO;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class MaintenanceRepository : GenericRepository<Maintenance>, IMaintenanceRepository
    {
        public MaintenanceRepository(AppContext context) : base(context)
        {
        }
    }
}
