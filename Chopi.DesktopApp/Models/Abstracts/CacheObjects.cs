using Chopi.DesktopApp.Models.Interfaces;
using Chopi.Modules.Share.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chopi.DesktopApp.Models.Abstracts
{
    internal class CacheObjects<TObject, TRequest>
        where TObject : CachedObject
        where TRequest : IDataRequest<TObject>
    {
        private IEnumerable<TObject> _objects;
        private IApiDataService<TObject, TRequest> _apiService;
        private IData _data;

        public CacheObjects(IApiDataService<TObject, TRequest> apiService)
        {
            _data = NetworkClient.GetInstance<IData>();
            _apiService = apiService;
            _objects = new List<TObject>();
        }
        public IEnumerable<TObject> GetData()
        {
            return _objects;
        }

        public IEnumerable<TObject> GetData(Func<TObject, bool> predicate)
        {
            return _objects.Where(predicate);
        }

        public async void LoadData(Func<TObject, bool> predicate)
        {
            //IEnumerable<TObject>? data = await _data.CollectionServiceAsync(_apiService);

            //if (data is null)
            //{
            //    return;
            //}

            //_objects = data;
        }
    }
}
