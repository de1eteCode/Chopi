using Chopi.Modules.EFCore.Entities.Identity;
using System;

namespace Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories
{
    public interface IUserClaimRepository : IGenericRepository<UserClaim, Guid>
    {
    }
}
