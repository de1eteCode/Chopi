using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;

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

    internal class AutopartAddService : ApiService
    {
        public AutopartAddService(AutopartData @params) : base(@params)
        {
        }

        public async override Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var data = ParseParams<AutopartData>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/autoparts/addautoparts", Method.POST, DataFormat.Json)
                .AddJsonBody(JsonSerializer.Serialize(data));

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }

    internal class AutopartUpdateService : ApiService
    {
        public AutopartUpdateService(AutopartData @params) : base(@params)
        {
        }

        public async override Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var data = ParseParams<AutopartData>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/autoparts/updateautoparts", Method.POST, DataFormat.Json)
                .AddJsonBody(JsonSerializer.Serialize(data));

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
