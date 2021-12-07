using Chopi.DesktopApp.Network.ApiServices.Abstracts;
using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Network.ApiServices.Services
{
    internal class LogOutService : ApiService
    {
        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/account/auth/logout", Method.POST, DataFormat.Json);

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
