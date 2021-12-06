using RestSharp;
using Chopi.DesktopApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chopi.DesktopApp.Network.ApiServices;
using Chopi.Modules.Share;
using System.Net;
using Chopi.DesktopApp.Network.ApiServices.Service;

namespace Chopi.DesktopApp.Network
{
    /// <summary>
    /// NetworkClient реализует паттерн Singleton, потому что данный класс должен существовать только в одном экземпляре.
    /// Он управляет сетевым пользователем и его содерижимым (данные, куки).
    /// Через данный класс проходят все запросы на сервер
    /// </summary>
    internal class NetworkClient
    {
        #region Singleton

        private static object _lock = new();
        private static NetworkClient? _networkClient;

        public static NetworkClient GetInstance()
        {
            if (_networkClient is null)
            {
                lock (_lock)
                {
                    if (_networkClient is null)
                    {
                        _networkClient = new NetworkClient();
                    }
                }
            }

            return _networkClient;
        }

        #endregion

        private readonly RestClient _restClient;
        private readonly Configuration _configuration;
        private readonly ApiController _controller;

        protected NetworkClient()
        {
            _configuration = Configuration.GetInstance();
            _restClient = new RestClient(_configuration.HttpServerAddress);
            _controller = new ApiController(_restClient);
        }

        public async Task<bool> Auth(string username, string password)
        {
            var service = new AuthService(new LoginModel { Username = username, Password = password});
            var result = await _controller.ExecuteService(service);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var cookies = result.Cookies;
                ApiAuth.AddAuthenticator(_restClient, cookies.First());
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
