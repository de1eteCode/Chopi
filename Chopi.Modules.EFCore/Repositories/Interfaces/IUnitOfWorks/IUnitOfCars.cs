using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

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
