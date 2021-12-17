using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiServices.Service
{
    internal interface IApiService
    {
        Task<IRestResponse> ExecuteAsync(IRestClient client);
    }
}
