﻿using Chopi.Modules.EFCore.Entities.Identity;
using System;

namespace Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories
{
    public interface IPassportRepository : IGenericRepository<Passport, Guid>
    {
    }
}
