using Chopi.Modules.EFCore.Entities.CarDealership;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class CustomCarRepository : GenericRepository<CustomCar>, ICustomCarRepository
    {
        public CustomCarRepository(AppContext context) : base(context)
        {
        }
    }

}
