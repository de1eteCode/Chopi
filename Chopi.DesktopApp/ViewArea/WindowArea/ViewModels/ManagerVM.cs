using Chopi.DesktopApp.ViewArea.PageArea.ViewModels;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels
{
    internal class ManagerVM : WindowVMWithPages
    {
        public ManagerVM()
        {
            RegisterPageAndCreate<ControlPanelUsersVM, ControlPanelUsers>();
            RegisterPageAndCreate<ControlPanelTechnicalServicesVM, ControlPanelTechnicalServices>();
            RegisterPageAndCreate<ConstructorCarsVM, ConstructorCars>();
        }
    }
}
