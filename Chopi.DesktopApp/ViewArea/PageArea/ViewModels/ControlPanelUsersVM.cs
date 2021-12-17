using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share;
using System.Collections.Generic;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelUsersVM : PageWithPaginatorVM
    {
        public override string Title => "Пользователи";

        public override async void OnLoad()
        {
            base.OnLoad();

            var service = new UserService(0, 20);
            var net = NetworkClient.GetInstance<IData>();
            var data = await net.CollectionServiceAsync<UserData>(service);
            var a = 1;
        }
    }
}
