using Chopi.DesktopApp.ViewArea.PageArea.ViewModels;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels
{
    internal class SystemAdministratorVM : WindowVMWithPages
    {
        public SystemAdministratorVM()
        {
            RegisterPageAndCreate<InfoVM, InfoPage>();
        }
    }
}
