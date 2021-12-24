using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class ProviderService : ApiDatasService<ProviderData, DataRequestCollection<ProviderData>>
    {
        public ProviderService() : base(new DataRequestCollection<ProviderData>(0, 10000), "api/providers/getproviders")
        {
        }

        public ProviderService(DataRequestCollection<ProviderData> @params) : base(@params, "api/providers/getproviders")
        {
        }
    }
}
