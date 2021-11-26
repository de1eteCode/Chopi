using Chopi.DesktopApp.Core;
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

        #region Properties
        public ICommand AuthCommand { get; }

        #endregion

        #region Methonds

        private void Auth()
        {

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
            MessageBox.Show("1");
        }

#endif
    }
}
