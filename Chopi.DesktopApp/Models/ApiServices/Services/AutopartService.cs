using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class AutopartService : ApiDatasService<AutopartData, DataRequestCollection<AutopartData>>
    {
        public AutopartService() : base(new DataRequestCollection<AutopartData>(0, 10000), "api/autoparts/getautoparts")
        {
        }

        public AutopartService(DataRequestCollection<AutopartData> @params) : base(@params, "api/autoparts/updateautoparts")
        {
        }
    }
}
