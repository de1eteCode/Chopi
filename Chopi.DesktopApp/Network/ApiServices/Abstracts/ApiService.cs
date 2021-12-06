using Chopi.DesktopApp.Network.ApiServices.Service;
using Chopi.DesktopApp.Service;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Network.ApiServices.Abstracts
{
    abstract class ApiService : IApiService
    {
        private object _params { get; set; }

        protected Configuration Cfg => Configuration.GetInstance();

        public ApiService()
        {

        }

        protected ApiService(object @params)
        {
            _params = @params;
        }

        public abstract Task<IRestResponse> ExecuteAsync(IRestClient client);

        protected T ParseParams<T>()
        {
            if (_params is null)
            {
#if DEBUG
                throw new ArgumentNullException(nameof(_params));
#else
                return null;
#endif
            }
            if (_params.GetType() != typeof(T))
            {
#if DEBUG
                throw new ArgumentException($"Тип {nameof(_params)} не соответствует ожидаемому");
#else
                return null;
#endif
            }

            return (T)_params;
        }
    }
}
