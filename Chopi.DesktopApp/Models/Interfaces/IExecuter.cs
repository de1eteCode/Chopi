using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Interfaces
{
    interface IExecuter : INetworkClient
    {
        Task<IRestResponse> ExecuteAsync(ApiService service);
    }
}
