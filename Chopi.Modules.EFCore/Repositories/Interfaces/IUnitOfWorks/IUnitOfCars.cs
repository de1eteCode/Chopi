using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks
{
    /// <summary>
    /// Содержит все автомобили
    /// </summary>
    public interface IUnitOfCars : IUnitOfWork
    {
        ICustomCarRepository CustomCar { get; }
        ICompleteCarRepository CompleteCar { get; }
    }
}
