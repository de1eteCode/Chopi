using Chopi.DesktopApp.ViewArea.PageArea.ViewModels;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels
{
    internal class AdministratorVM : WindowVMWithPages
    {
        public AdministratorVM()
        {
            RegisterPageAndCreate<ControlPanelUsersVM, ControlPanelUsers>();
            RegisterPageAndCreate<ControlPanelCarsVM, ControlPanelCars>();
        }
    }
}
