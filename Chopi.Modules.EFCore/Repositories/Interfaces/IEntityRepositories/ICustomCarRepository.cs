using Chopi.Modules.EFCore.Entities.CarDealership;
using System;

namespace Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories
{
    public interface ICustomCarRepository : IGenericRepository<CustomCar, Guid> { }
}
