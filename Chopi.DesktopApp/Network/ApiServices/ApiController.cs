using Chopi.DesktopApp.Network.ApiServices.Service;
using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Network.ApiServices
{
    internal class ApiController
    {
        private readonly IRestClient _restClient;

        public ApiController(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<IRestResponse> ExecuteService(IApiService service)
        {
            return await service.ExecuteAsync(_restClient);
        }
    }
}
