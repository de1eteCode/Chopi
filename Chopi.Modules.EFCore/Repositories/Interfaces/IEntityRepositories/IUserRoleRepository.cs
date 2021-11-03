using Chopi.Modules.EFCore.Entities.Identity;
using System;

namespace Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories
{
    public interface IUserRoleRepository : IGenericRepository<UserRole, Guid>
    {
    }
}
