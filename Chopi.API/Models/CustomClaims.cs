namespace Chopi.API.Models
{
    /// <summary>
    /// Типы разрешений
    /// </summary>
    public static class CustomClaimTypes
    {
        /// <summary>
        /// Разрешения на управление своим аккаунтом
        /// </summary>
        public const string SelfAccount         = "permission:self:account";

        /// <summary>
        /// Разрешения на управление чужими аккаунтами
        /// </summary>
        public const string AnotherAccount      = "permission:another:account";

        /// <summary>
        /// Разрешения на управление бугалтерскими делами
        /// </summary>
        public const string Accountent          = "permission:accountent";

        /// <summary>
        /// Разрешения на управление запчастями для машин
        /// </summary>
        public const string Autoparts           = "permission:autoparts";

        /// <summary>
        /// Разрешения на управление поставщиками запчастей для машин
        /// </summary>
        public const string AutopartsProvider   = "permission:autoparts:provider";

        /// <summary>
        /// Разрешения на управление ролями
        /// </summary>
        public const string Role                = "permission:role";

        /// <summary>
        /// Разрешения на управление машинами
        /// </summary>
        public const string Cars                = "permission:cars";

        /// <summary>
        /// Разрешения на продажу машин
        /// </summary>
        public const string CarsSell            = "permission:cars:sell";

        /// <summary>
        /// Разрешения на управление заказанными машинами
        /// </summary>
        public const string CarsOrderedAll      = "permission:cars:ordered:all";

        /// <summary>
        /// Разрешения на управление собственными заказанными машинами
        /// </summary>
        public const string CarsOrderedSelf     = "permission:cars:ordered:self";

        /// <summary>
        /// Разрешения на управление заказанными машинами
        /// </summary>
        public const string CarsAllHistory      = "permission:cars:history:all";

        /// <summary>
        /// Разрешения на управление заказанными машинами
        /// </summary>
        public const string CarsSelfHistory     = "permission:cars:history:self";

        /// <summary>
        /// Разрешения на управление поставщиками машин
        /// </summary>
        public const string CarsProvider        = "permission:cars:provider";

        /// <summary>
        /// Разрешения на доступ к ТО
        /// </summary>
        public const string MaintenanceAll      = "permission:maintenance:all";

        /// <summary>
        /// Разрешения на доступ к ТО своих авто
        /// </summary>
        public const string MaintenanceSelf     = "permission:maintenance:self";
    }

    /// <summary>
    /// Значения для типов
    /// </summary>
    public static class CustomClaimValues
    {
        /// <summary>
        /// Создание
        /// </summary>
        public const string Create      = "value:create";

        /// <summary>
        /// Чтение
        /// </summary>
        public const string Read        = "value:read";

        /// <summary>
        /// Обновление
        /// </summary>
        public const string Update      = "value:update";

        /// <summary>
        /// Удалиние
        /// </summary>
        public const string Delete      = "value:delete";
    }
}
