using Chopi.Modules.EFCore.Repositories.EntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;

namespace Chopi.Modules.EFCore.Repositories.UnitOfWorks
{
    /// <summary>
    /// Содержит все автомобили
    /// </summary>
    public class UnitOfCars : UnitOfWork, IUnitOfCars
    {
        public UnitOfCars(AppContext context) : base(context)
        {
            CustomCar = new CustomCarRepository(context);
            CompleteCar = new CompleteCarRepository(context);
        }

        public ICustomCarRepository CustomCar { get; }

        public ICompleteCarRepository CompleteCar { get; }
    }
}
