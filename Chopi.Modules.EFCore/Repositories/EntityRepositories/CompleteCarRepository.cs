using Chopi.Modules.EFCore.Entities.CarDealership;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class CompleteCarRepository : GenericRepository<CompleteCar>, ICompleteCarRepository
    {
        public CompleteCarRepository(AppDbContext context) : base(context)
        {
        }
    }

}
