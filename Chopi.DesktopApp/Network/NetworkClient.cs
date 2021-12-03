using RestSharp;
using Chopi.DesktopApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chopi.DesktopApp.Network.ApiServices;

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

        protected NetworkClient()
        {
            _configuration = Configuration.GetInstance();

            _restClient = new RestClient(_configuration.HttpServerAddress);
        }

        public async Task<bool> Auth(string login, string password)
        {
            var service = new AuthService(_restClient);
            return await service.Authorizate(login, password);
        }
    }
}
