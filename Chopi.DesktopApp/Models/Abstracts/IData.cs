using Chopi.DesktopApp.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Abstracts
{
    internal interface IData : INetworkClient
    {
        public Task<T?> ObjectServiceAsync<T>(IApiService service)
            where T : class;

        public Task<IEnumerable<T>?> CollectionServiceAsync<T>(IApiService service)
            where T : class;
    }
}
