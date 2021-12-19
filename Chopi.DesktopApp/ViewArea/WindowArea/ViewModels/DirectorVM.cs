using Chopi.DesktopApp.ViewArea.PageArea.ViewModels;
using Chopi.DesktopApp.ViewArea.PageArea.Views;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels
{
    internal class DirectorVM : AdministratorVM
    {
        public DirectorVM()
        {
            RegisterPageAndCreate<ControlPanelProvidersVM, ControlPanelProviders>();
        }
    }
}
