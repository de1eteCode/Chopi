using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Cache;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share.DataModels;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelUsersVM : PageWithPaginatorVM<UserData>
    {
        // Закоментированный код для отключения функционала

        private UserCache _userCache;

        public ControlPanelUsersVM()
        {
            _userCache = new UserCache(new UserService());
        }

        public override string Title => "Пользователи";

        public override async void OnLoad()
        {
            base.OnLoad();

            await _userCache.LoadCollection(0,20);
        }

        public override void OnOpen()
        {
            Task.Run(_userCache.StartListener);
        }

        public override void OnClose()
        {
            Task.Run(_userCache.StopListener);
        }
    }
}
