using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Cache;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share.DataModels;

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
    }
}
