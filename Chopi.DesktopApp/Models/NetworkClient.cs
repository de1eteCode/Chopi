using Chopi.DesktopApp.Models.ApiServices;
using Chopi.DesktopApp.Models.ApiServices.Interfaces;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.Service;
using Chopi.Modules.Share;
using Chopi.Modules.Share.RequestModels;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models
{
    /// <summary>
    /// NetworkClient реализует паттерн Singleton, потому что данный класс должен существовать только в одном экземпляре.
    /// Он управляет сетевым пользователем и его содерижимым (данные, куки).
    /// Через данный класс проходят все запросы на сервер
    /// </summary>
    internal class NetworkClient : IAuthorize, IDataSource, ISubscriber, INetworkClient
    {
        #region Singleton

        private static object _lock = new();
        private static INetworkClient? _networkClient;

        public static T GetInstance<T>()
            where T : INetworkClient
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

            return (T)_networkClient;
        }

        #endregion

        private const string _signatureIdentity = ".AspNetCore.Identity";
        private const string _signatureRole = ".AspNetCore.Role";

        private readonly RestClient _restClient;
        private readonly Configuration _configuration;
        private readonly ApiServiceController _controller;

        protected NetworkClient()
        {
            _configuration = Configuration.GetInstance();
            _restClient = new RestClient(_configuration.HttpServerAddress);
            _controller = new ApiServiceController(_restClient);
        }

        /// <summary>
        /// Авторизация клиента на сервере
        /// </summary>
        /// <param name="username">Логин (имя пользователя)</param>
        /// <param name="password">Парроль</param>
        /// <returns>Возвращает статус входа, список ролей для пользователя, ошибку (если такая случилась)</returns>
        public async Task<(bool, List<string>, string)> Auth(string username, string password)
        {
            var service = new AuthService(new LoginModel { Username = username, Password = password });
            var result = await _controller.ExecuteService(service);

            // Для возврата
            var authStatus = false;
            var roles = new List<string>();
            var errorMsg = string.Empty;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var authCookies = result.Cookies.Where(c => c.Name.StartsWith(_signatureIdentity)).ToList();

                ApiAuth.AddAuthenticator(_restClient, authCookies);

                var rolesHeader = result.Headers.Where(x => x is not null && x.Name is not null && x.Name.StartsWith(_signatureRole)).ToList();

                foreach (var role in rolesHeader)
                {
                    if (role is not null)
                    {
                        if (role.Value is string strRole && string.IsNullOrEmpty(strRole) is false)
                        {
                            roles.Add(strRole);
                        }
                    }
                }

                authStatus = true;
            }
            else if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                errorMsg = "Не верный логин/пароль";
            }
            else
            {
                errorMsg = $"Не предвиденная ошибка, обратитесь к системному администратору (Код ошибки: {result.StatusCode})";
            }

            return (authStatus, roles, errorMsg);
        }

        /// <summary>
        /// Деавторизация
        /// </summary>
        /// <returns>Статус деавторизации</returns>
        public async Task<bool> LogOut()
        {
            var service = new LogOutService();
            var result = await _controller.ExecuteService(service);

            return result.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Запрос данных одного объекта со стороны сервера
        /// </summary>
        /// <typeparam name="T">Тип получаемого объекта</typeparam>
        /// <param name="service">Сервис, при помощи которого осуществляется получение данных</param>
        /// <returns>Объект с данными</returns>
        public async Task<T?> ObjectServiceAsync<T, TRequest>(IApiDataService<T, TRequest> service)
            where T : class
            where TRequest : DataRequestCollection<T>
        {
            var result = await _controller.ExecuteService(service);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var deserialize = JsonSerializer.Deserialize<T>(result.Content);
                return deserialize;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Запрос данных коллекции объектов со стороны сервера
        /// </summary>
        /// <typeparam name="T">Тип объекта в коллекции</typeparam>
        /// <param name="service">Сервис, при помощи которого осуществляется получение данных</param>
        /// <returns>Коллекция объектов с данными</returns>
        public async Task<IEnumerable<T>?> CollectionServiceAsync<T, TRequest>(IApiDataService<T, TRequest> service)
            where T : class
            where TRequest : DataRequestCollection<T>
        {
            var result = await _controller.ExecuteService(service);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var deserialize = JsonSerializer.Deserialize<IEnumerable<T>>(result.Content);
                return deserialize;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Подписка
        /// </summary>
        /// <param name="url"></param>
        /// <param name="signalKey"></param>
        /// <returns></returns>
        public async Task<bool> Subscribe(string url, string signalKey)
        {
            var service = new SubscribeService(url, new SubscribeModel(signalKey));
            var result = await _controller.ExecuteService(service);

            if (result.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}
