using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Interfaces
{
    /// <summary>
    /// Описывает класс, который подписывается на обновления
    /// </summary>
    internal interface ISubscriber : INetworkClient
    {
        /// <summary>
        /// Подписка
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<bool> Subscribe(string url, string signalKey);
    }
}
