using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;

namespace Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks
{
    /// <summary>
    /// Содержит все типы репозиториев. Создан для дебага.
    /// </summary>
    public interface IUnitOfRoot : IUnitOfWork
    {
        IPassportRepository Passports { get; }
        IRoleClaimRepository RoleClaims { get; }
        IRoleRepository Roles { get; }
        IUserClaimRepository UserClaims { get; }
        IUserLoginRepository UserLogins { get; }
        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoles { get; }
        IUserTokenRepository UserTokens { get; }

        IAutopartRepository Autopart { get; }
        ICompleteCarRepository CompleteCar { get; }
        ICompleteRepository CompleteRepository { get; }
        ICountryRepository Country { get; }
        ICustomCarRepository CustomCar { get; }
        IManufacturerRepository Manufacturer { get; }
        IModelRepository Model { get; }
        IOrderRepository Orders { get; }

        ICompleteToAutopartRepository CompleteToAutoparts { get; }
        ICustomCarToAutopartRepository CustomCarToAutoparts { get; }
        IModelToAutopartRepository ModelToAutopart { get; }
    }
}
