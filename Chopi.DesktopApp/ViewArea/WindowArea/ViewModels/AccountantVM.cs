using Chopi.DesktopApp.ViewArea.PageArea.ViewModels;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels
{
    internal class AccountantVM : WindowVMWithPages
    {
        public AccountantVM()
        {
            RegisterPageAndCreate<ControlPanelReportsVM, ControlPanelReports>();
        }
    }
}
