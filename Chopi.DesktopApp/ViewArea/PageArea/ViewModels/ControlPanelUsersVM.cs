using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelUsersVM : PageWithPaginatorVM<UserData>
    {
        private CacheObjects<UserData, DataRequestCollection<UserData>> _userCache;

        public ControlPanelUsersVM()
        {
            _userCache = new (new UserService());
        }

        public override string Title => "Пользователи";

        public override async void OnLoad()
        {
            base.OnLoad();

            await _userCache.LoadCollection(0,20);
        }
    }
}
