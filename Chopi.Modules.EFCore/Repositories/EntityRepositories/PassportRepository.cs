﻿using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.EntityRepositories
{
    public class PassportRepository : GenericRepository<Passport>, IPassportRepository
    {
        public PassportRepository(AppContext context) : base(context)
        {
        }
    }
}