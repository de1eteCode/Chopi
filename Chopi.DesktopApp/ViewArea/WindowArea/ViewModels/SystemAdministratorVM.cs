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
            RegisterPageAndCreate<ControlPanelProvidersVM, ControlPanelProviders>();
            RegisterPageAndCreate<ControlPanelReportsVM, ControlPanelReports>();
            RegisterPageAndCreate<ControlPanelTechnicalServicesVM, ControlPanelTechnicalServices>();
            RegisterPageAndCreate<ControlPanelUsersVM, ControlPanelUsers>();
        }
    }
}
