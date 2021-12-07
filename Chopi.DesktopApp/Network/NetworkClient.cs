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

        private const string _signatureIdentity = ".AspNetCore.Identity";
        private const string _signatureRole = ".AspNetCore.Role";

        private readonly RestClient _restClient;
        private readonly Configuration _configuration;
        private readonly ApiController _controller;

        protected NetworkClient()
        {
            _configuration = Configuration.GetInstance();
            _restClient = new RestClient(_configuration.HttpServerAddress);
            _controller = new ApiController(_restClient);
        }

        public async Task<(bool, List<string>)> Auth(string username, string password)
        {
            var service = new AuthService(new LoginModel { Username = username, Password = password });
            var result = await _controller.ExecuteService(service);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var authCookies = result.Cookies.Where(c => c.Name.StartsWith(_signatureIdentity)).ToList();

                ApiAuth.AddAuthenticator(_restClient, authCookies);

                var roles = new List<string>();

                var rolesHeader = result.Headers.Where(x => x is not null && x.Name is not null && x.Name.StartsWith(_signatureRole)).ToList();

                foreach (var role in rolesHeader)
                {
                    if (role is not null)
                    {
                        if (role.Value is string strRole && string.IsNullOrEmpty(strRole))
                        {
                            roles.Add(strRole);
                        }
                    }
                }

                return (true, roles);
            }
            else
            {
                return (false, new List<string>());
            }
        }
    }
}
