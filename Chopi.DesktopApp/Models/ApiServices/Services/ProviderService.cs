using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using RestSharp;
using System.Threading.Tasks;

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

    internal class ProviderAddService : ApiService
    {
        public ProviderAddService(ProviderData data) : base(data)
        {

        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var data = ParseParams<ProviderData>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/providers/addprovider", Method.POST, DataFormat.Json)
                .AddJsonBody(System.Text.Json.JsonSerializer.Serialize(data));

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }

    internal class ProviderUpdateService : ApiService
    {
        public ProviderUpdateService(ProviderData data) : base(data)
        {

        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var data = ParseParams<ProviderData>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/providers/updateprovider", Method.POST, DataFormat.Json)
                .AddJsonBody(System.Text.Json.JsonSerializer.Serialize(data));

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
