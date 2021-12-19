using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelCarsVM : PageWithPaginatorVM<CarData>
    {
        public override string Title => "Автомобили";
    }
}
