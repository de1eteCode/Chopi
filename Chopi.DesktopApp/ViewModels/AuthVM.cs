using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.Network;
using Chopi.DesktopApp.ViewModels.Abstracts;
using Chopi.Modules.Share;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chopi.DesktopApp.ViewModels
{
    internal class AuthVM : BaseVM
    {
        #region Fields

        private string _username = String.Empty;
        private string _password = String.Empty;

        #endregion

        public AuthVM()
        {
            AuthCommand = new RelayCommand(Auth);
        }

        #region Properties

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand AuthCommand { get; }

        #endregion

        #region Methonds

        /// <summary>
        /// Логика работы авторизации с view
        /// </summary>
        /// <exception cref="ArgumentNullException">Отсутствие роль</exception>
        /// <exception cref="Exception">Используется в дебаге</exception>
        /// <exception cref="NullReferenceException">Не найден контроллер</exception>
        private async void Auth()
        {
            var nClient = NetworkClient.GetInstance();

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Не введен логин или пароль");
                return;
            }

            var (auth, roles) = await nClient.Auth(Username, Password);

            if (auth is true)
            {
                try
                {
                    if (roles is null || roles.Count == 0)
                        throw new ArgumentNullException(nameof(roles));

                    if (roles.Count > 1)
                        throw new Exception("Реализовать множественные роли. Как вариант декоратор, но не факт");

                    var vm = GetVMByRole(roles.First());

                    var controller = (Application.Current as App)?.Controller;

                    if (controller is not null)
                    {
                        controller.ShowNewAndCloseOld(vm, this);
                    }
                    else
                    {
                        throw new NullReferenceException(nameof(controller));
                    }
                }
                catch (ArgumentException ex) // Из GetVMByRole
                {
#if DEBUG
                    throw new Exception(ex.Message);
#else
                    MessageBox.Show("Для полученной роли не существует формы в данной программе", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
#endif
                    await nClient.LogOut();
                }
            }
        }

        /// <summary>
        /// Получение vm по роли
        /// </summary>
        /// <param name="role">Роль пользователя</param>
        /// <returns>vm для пользователя</returns>
        /// <exception cref="ArgumentException">Роль не поддерживается приложением</exception>
        private BaseVM GetVMByRole(string role) => role switch
        {
            Roles.ManagerSystemRole => new ManagerVM(),
            Roles.AccountentSystemRole => new AccountantVM(),
            Roles.AdministratorSystemRole => new AdministratorVM(),
            Roles.DirectorSystemRole => new DirectorVM(),
            Roles.SysAdministratorSystemRole => new SystemAdministratorVM(),
            _ => throw new ArgumentException(nameof(role))
        };

        #endregion

        #region Debug
#if DEBUG

        protected override void InitializationDebug()
        {
            AuthAdminCommand = new RelayCommand(AuthAdmin);
        }

        #region Properties

        public ICommand? AuthAdminCommand { get; private set; }

        #endregion

        private void AuthAdmin()
        {
            Username = "testuser1";
            Password = "DUSdb_3ed";
            Task.Run(() => Auth());
        }

#endif
        #endregion
    }
}
