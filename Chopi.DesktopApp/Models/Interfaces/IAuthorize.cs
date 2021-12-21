using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Interfaces
{
    /// <summary>
    /// Описывает класс авторизации и деавторизации
    /// </summary>
    internal interface IAuthorize : INetworkClient
    {
        /// <summary>
        /// Авторизация на сервере
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<(bool, List<string>, string)> Auth(string username, string password);

        /// <summary>
        /// Деавторизация на сервере
        /// </summary>
        /// <returns></returns>
        public Task<bool> LogOut();
    }
}
