using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.ApiSignalR;
using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelProvidersVM : PageWithPaginatorVM<ProviderData>
    {
        public ControlPanelProvidersVM()
            : base(new ProviderService(), new ProviderSignalR())
        {
        }

        public override void OnLoad()
        {
        }

        public override void OnOpen()
        {
        }

        public override void OnClose()
        {
        }

        public override string Title => "Поставщики";
    }
}
