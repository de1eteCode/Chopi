using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.Network;
using Chopi.DesktopApp.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chopi.DesktopApp.ViewModels
{
    internal class AuthVM : BaseVM
    {
        public AuthVM()
        {
            AuthCommand = new RelayCommand(Auth);
        }

        private string _username;
        private string _password;

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


        #region Properties
        public ICommand AuthCommand { get; }

        #endregion

        #region Methonds

        private async void Auth()
        {
            var nClient = NetworkClient.GetInstance();
            
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Не введен логин или пароль");
                return;
            }
            var result = await nClient.Auth(Username, Password);

            if (result is true)
            {

            }
        }

        #endregion

#if DEBUG

        protected override void InitializationDebug()
        {
            AuthAdminCommand = new RelayCommand(AuthAdmin); 
        }
        #region Properties

        public ICommand AuthAdminCommand { get; private set; }

        #endregion

        private void AuthAdmin()
        {
            Username = "testuser1";
            Password = "DUSdb_3ed";
            Task.Run(() => Auth());
        }

#endif
    }
}
