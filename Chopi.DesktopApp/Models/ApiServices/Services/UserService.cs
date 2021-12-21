using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class UserService : ApiDataService<UserData, DataRequestCollection<UserData>>
    {
        public UserService() : base(new DataRequestCollection<UserData>(0, 20), "api/users/getusers")
        {
        }

        public UserService(DataRequestCollection<UserData> @params) : base(@params, "api/users/getusers")
        {
        }
    }
}
