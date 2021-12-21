using Chopi.DesktopApp.Models.ApiServices.Interfaces;
using Chopi.DesktopApp.Models.ApiSignalR;
using Chopi.DesktopApp.Models.Cache.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using Chopi.Modules.Share.HubInterfaces.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Cache
{
    internal class UserCache : CacheObjects<UserData, DataRequestCollection<UserData>>, IUserHubActions
    {
        private UserSignalR _userSignalR;

        public UserCache(IApiDataService<UserData, DataRequestCollection<UserData>> service) : base(service)
        {
            _userSignalR = new UserSignalR(this, "userhub", "api/users/sub");
        }

        public async void StartListener() => await _userSignalR.Start();
        public async void StopListener() => await _userSignalR.Stop();

        public async Task Add(UserData entity)
        {
            await Task.Run(() => AddToCache(entity));
        }

        public async Task Update(UserData entity)
        {
            await Task.Run(() => UpdateInCache(entity));
        }
    }
}
