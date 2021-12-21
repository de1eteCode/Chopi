using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share.RequestModels;
using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class SubscribeService : ApiService
    {
        private string _url;

        public SubscribeService(string url, object @params) : base(@params)
        {
            _url = url;
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var sModel = ParseParams<SubscribeModel>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/{_url}", Method.POST, DataFormat.Json)
                .AddJsonBody(sModel);

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
