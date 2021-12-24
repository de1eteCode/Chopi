using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class AboutMeService : ApiDataService<UserData, DataRequest<UserData>>
    {
        public AboutMeService() : base(new DataRequest<UserData>(string.Empty), "account/information/aboutme")
        {
        }

        public AboutMeService(DataRequest<UserData> @params) : base(@params, "account/information/aboutme")
        {
        }
    }
}
