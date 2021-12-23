using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.ApiSignalR;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelUsersVM : PageWithPaginatorVM<UserData>
    {
        public ControlPanelUsersVM() 
            : base(new UserService(), new UserSignalR())
        {
            OpenUpdateUserCommand = new RelayCommand(OpenUpdateUser);
        }

        public override string Title => "Пользователи";

        public ICommand OpenUpdateUserCommand { get; set; }

        private async void OpenUpdateUser()
        {
            var status = await OpenDialog(new UpdateUserVM(), new UpdateUser());
            if (status == Util.StatusModal.NoSet)
            {

            }
        }
    }
}
