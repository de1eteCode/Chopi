using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.Models.ApiSignalR
{
    internal class AutopartSignalR : ApiSignalController<AutopartData>
    {
        public AutopartSignalR()
            : base("autoparthub", "api/autoparts/sub")
        {
        }
    }
}
