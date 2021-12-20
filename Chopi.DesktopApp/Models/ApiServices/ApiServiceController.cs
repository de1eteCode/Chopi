using Chopi.DesktopApp.Models.ApiServices.Interfaces;
using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiServices
{
    internal class ApiServiceController
    {
        private readonly IRestClient _restClient;

        public ApiServiceController(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<IRestResponse> ExecuteService(IApiService service)
        {
            return await service.ExecuteAsync(_restClient);
        }
    }
}
