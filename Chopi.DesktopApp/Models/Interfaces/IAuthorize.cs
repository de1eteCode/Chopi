using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Interfaces
{
    /// <summary>
    /// Описывает класс авторизации и деавторизации
    /// </summary>
    internal interface IAuthorize : INetworkClient
    {
        public Task<(bool, List<string>, string)> Auth(string username, string password);
        public Task<bool> LogOut();
    }
}
