using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ConstructorCarsVM : PageWithPaginatorVM<CarData>
    {
        public ConstructorCarsVM() : base(null, null)
        {

        }

        public override void OnLoad()
        {
        }

        public override void OnClose()
        {
        }

        public override void OnOpen()
        {
        }

        public override string Title => "Конструктор";
    }
}
