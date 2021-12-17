using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels
{
    internal class AuthVM : WindowVM
    {
        #region Fields

        private readonly ProviderRoles _providerRoles;
        private string _username = String.Empty;

        #endregion

        public AuthVM()
        {
            AuthCommand = new RelayCommand<PasswordBox>(Auth);
            _providerRoles = new ProviderRoles();
        }

        #region Properties

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
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
        private async void Auth(PasswordBox box)
        {
            var password = box.Password;

            var nClient = NetworkClient.GetInstance<IAuthorize>();

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Не введен логин или пароль",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            var (auth, roles, errorMsg) = await nClient.Auth(Username, password);

            if (auth is true)
            {
                try
                {
                    if (roles is null || roles.Count == 0)
                        throw new ArgumentNullException(nameof(roles));

                    if (roles.Count > 1)
                        throw new Exception("Реализовать множественные роли. Как вариант декоратор, но не факт");

                    var vm = _providerRoles.GetVMByRole(roles.First());

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
                    MessageBox.Show("Для полученной роли не существует формы в данной программе. Выходим из аккаунта...", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
#endif
#pragma warning disable CS0162 // Обнаружен недостижимый код
                    await nClient.LogOut();
#pragma warning restore CS0162 // Обнаружен недостижимый код
                }
            }
            else
            {
                MessageBox.Show(
                    errorMsg,
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

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
            Auth(new PasswordBox() { Password = "DUSdb_3ed" });
        }

#endif
        #endregion
    }
}
