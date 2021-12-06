using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;
using System.Linq;
using System.Threading.Tasks;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class PassportRepository : GenericRepository<Passport>, IPassportRepository
    {
        public PassportRepository(AppDbContext context) : base(context)
        {
        }
    }
}
