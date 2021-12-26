using Chopi.Modules.EFCore.Repositories.EntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IEntityRepositories;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;

namespace Chopi.Modules.EFCore.Repositories.UnitOfWorks
{
    /// <summary>
    /// Содержит все типы репозиториев. Создан для дебага.
    /// </summary>
    public class UnitOfRoot : UnitOfWork, IUnitOfRoot
    {
        public UnitOfRoot(AppDbContext context) : base(context)
        {
            Passports = new PassportRepository(context);
            RoleClaims = new RoleClaimRepository(context);
            Roles = new RoleRepository(context);
            UserClaims = new UserClaimRepository(context);
            UserLogins = new UserLoginRepository(context);
            UserRepository = new UserRepository(context);
            UserRoles = new UserRoleRepository(context);
            UserTokens = new UserTokenRepository(context);
            Autopart = new AutopartRepository(context);
            CompleteCar = new CompleteCarRepository(context);
            CompleteRepository = new CompleteRepository(context);
            Country = new CountryRepository(context);
            CustomCar = new CustomCarRepository(context);
            Manufacturer = new ManufacturerRepository(context);
            Model = new ModelRepository(context);
            Orders = new OrderRepository(context);
            CompleteToAutoparts = new CompleteToAutopartsRepository(context);
            CustomCarToAutoparts = new CustomCarToAutopartRepository(context);
            ModelToAutopart = new ModelToAutopartRepository(context);
        }

        public IPassportRepository Passports { get; }

        public IRoleClaimRepository RoleClaims { get; }

        public IRoleRepository Roles { get; }

        public IUserClaimRepository UserClaims { get; }

        public IUserLoginRepository UserLogins { get; }

        public IUserRepository UserRepository { get; }

        public IUserRoleRepository UserRoles { get; }

        public IUserTokenRepository UserTokens { get; }

        public IAutopartRepository Autopart { get; }

        public ICompleteCarRepository CompleteCar { get; }

        public ICompleteRepository CompleteRepository { get; }

        public ICountryRepository Country { get; }

        public ICustomCarRepository CustomCar { get; }

        public IManufacturerRepository Manufacturer { get; }

        public IModelRepository Model { get; }

        public IOrderRepository Orders { get; }

        public ICompleteToAutopartRepository CompleteToAutoparts { get; }

        public ICustomCarToAutopartRepository CustomCarToAutoparts { get; }

        public IModelToAutopartRepository ModelToAutopart { get; }
    }
}
