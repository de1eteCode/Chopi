using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.Models.ApiSignalR
{
    internal class ProviderSignalR : ApiSignalController<ProviderData>
    {
        public ProviderSignalR()
            : base("providerhub", "api/providers/sub")
        {
        }
    }
}
