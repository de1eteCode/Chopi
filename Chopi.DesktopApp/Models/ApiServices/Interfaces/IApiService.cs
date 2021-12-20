using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiServices.Interfaces
{
    /// <summary>
    /// Описывает класс с доступом к серверу
    /// </summary>
    internal interface IApiService
    {
        Task<IRestResponse> ExecuteAsync(IRestClient client);
    }
}
