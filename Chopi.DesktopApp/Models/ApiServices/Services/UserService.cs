using Chopi.DesktopApp.Models.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.Abstracts;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class UserService : ApiDataService<UserData, DataRequest<UserData>>
    {
        public UserService() : base(new DataRequest<UserData>(0, 20), "admin/getusers")
        {
        }

        public UserService(IDataRequest<UserData> @params) : base(@params, "admin/getusers")
        {
        }
    }
}
