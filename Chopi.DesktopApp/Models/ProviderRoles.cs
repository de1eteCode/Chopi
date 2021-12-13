using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;
using Chopi.Modules.Share;
using System;
using System.Windows.Threading;

namespace Chopi.DesktopApp.Models
{
    class ProviderRoles
    {
        private Dispatcher _dispatcher;

        public ProviderRoles()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
        }

        /// <summary>
        /// Получение vm по роли
        /// </summary>
        /// <param name="role">Роль пользователя</param>
        /// <returns>vm для пользователя</returns>
        /// <exception cref="ArgumentException">Роль не поддерживается приложением</exception>
        public WindowVM GetVMByRole(string role)
        {
            return _dispatcher.Invoke(() =>
            {
                return VMByRole(role);
            });
        }


        private WindowVM VMByRole(string role) => role switch
        {
            Roles.ManagerSystemRole => new ManagerVM(),
            Roles.AccountentSystemRole => new AccountantVM(),
            Roles.AdministratorSystemRole => new AdministratorVM(),
            Roles.DirectorSystemRole => new DirectorVM(),
            Roles.SysAdministratorSystemRole => new SystemAdministratorVM(),
            _ => throw new ArgumentException(nameof(role))
        };
    }
}
