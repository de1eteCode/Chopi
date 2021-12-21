using Chopi.DesktopApp.Models.ApiServices.Interfaces;
using Chopi.DesktopApp.Models.ApiSignalR;
using Chopi.DesktopApp.Models.Cache.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Cache
{
    internal class CarCache : CacheObjects<CarData, DataRequestCollection<CarData>>, ICarHubActions
    {
        private CarSignalR _carSignalR;
        
        public CarCache(IApiDataService<CarData, DataRequestCollection<CarData>> service) : base(service)
        {
            _carSignalR = new CarSignalR(this, "/carhub", "/api/cars/sub");
        }

        public async Task Add(CarData entity)
        {
            await Task.Run(() => AddToCache(entity));
        }

        public async Task Update(CarData entity)
        {
            await Task.Run(() => UpdateInCache(entity));
        }
    }
}
