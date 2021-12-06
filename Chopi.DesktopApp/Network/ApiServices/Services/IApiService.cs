using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Network.ApiServices.Service
{
    internal interface IApiService
    {
        Task<IRestResponse> ExecuteAsync(IRestClient client);
    }
}
