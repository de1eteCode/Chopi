using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.Models.ApiSignalR
{
    internal class UserSignalR : ApiSignalController<UserData>
    {
        public UserSignalR()
            : base("userhub", "api/users/sub")
        {
        }
    }
}
