using Chopi.DesktopApp.Models.Service;
using Chopi.Modules.Share.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Abstracts
{
    internal class CacheObjects<T, TService>
        where T : CachedObject
        where TService : IApiService
    {
        private IList<T> _objects;
        private IApiService _apiService;
        private IData _data;

        public CacheObjects()
        {
            _data = NetworkClient.GetInstance<IData>();
            _objects = new List<T>();
        }

        public void LoadData()
        {

        }
    }
}
