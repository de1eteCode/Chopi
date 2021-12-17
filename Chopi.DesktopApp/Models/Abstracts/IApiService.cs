using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Service
{
    internal interface IApiService
    {
        Task<IRestResponse> ExecuteAsync(IRestClient client);
    }
}
