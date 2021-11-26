using Chopi.DesktopApp.Service;
using RestSharp;

namespace Chopi.DesktopApp.Network.ApiServices.Abstracts
{
    class ApiService
    {
        protected IRestClient Client;
        protected Configuration Cfg => Configuration.GetInstance();

        public ApiService(IRestClient client)
        {
            Client = client;
        }
    }
}
