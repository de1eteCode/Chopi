using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share;
using System.Collections.Generic;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelUsersVM : PageWithPaginatorVM
    {
        //private CacheObjects<UserData> _userDatas;

        public ControlPanelUsersVM()
        {
            //_userDatas = new CacheObjects<UserData>(new )
        }

        public override string Title => "Пользователи";



        public override async void OnLoad()
        {
            base.OnLoad();

            var service = new UserService(new DataRequest<UserData>(0, 20));
            var net = NetworkClient.GetInstance<IData>();
            var data = await net.CollectionServiceAsync(service);
            var a = 1;
        }
    }
}
