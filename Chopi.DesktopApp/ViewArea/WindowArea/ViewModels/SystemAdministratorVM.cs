using Chopi.DesktopApp.ViewArea.PageArea.ViewModels;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels
{
    internal class SystemAdministratorVM : WindowVMWithPages
    {
        public SystemAdministratorVM()
        {
            RegisterPageAndCreate<InfoVM, InfoPage>();
            RegisterPageAndCreate<ConstructorCarsVM, ConstructorCars>();
            RegisterPageAndCreate<ControlPanelCarsVM, ControlPanelCars>();
            RegisterPageAndCreate<ControlPanelAutopartsVM, ControlPanelAutoparts>();
            RegisterPageAndCreate<ControlPanelProvidersVM, ControlPanelProviders>();
            RegisterPageAndCreate<ControlPanelUsersVM, ControlPanelUsers>();
        }
    }
}
