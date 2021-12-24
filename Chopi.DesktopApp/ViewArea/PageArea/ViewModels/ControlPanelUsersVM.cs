using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.ApiSignalR;
using Chopi.DesktopApp.Models.Extends;
using Chopi.DesktopApp.Models.ObjectSorting;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using System.Collections.Generic;
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

            Filters = new List<Filter>()
            {
                new Filter("Username", "UserName"),
                new Filter("Фамилия", "SecondName"),
                new Filter("Имя", "FirstName"),
                new Filter("Отчество", "MiddleName"),
                new Filter("Роль", "RoleStr")
            };
        }

        public override string Title => "Пользователи";

        public ICommand OpenUpdateUserCommand { get; set; }
        public UserData SelectedUser { get; set; }

        private async void OpenUpdateUser()
        {
            UserData data = SelectedUser.CopyObj<UserData>();

            if (data is null)
            {
                MsgShowError("Не выбран пользователь");
                return;
            }

            var status = await OpenDialog(new UpdateUserVM(data), new UpdateUser());
            if (status == Util.StatusModal.Ok)
            {
                // Todo: Обработка
            }
        }
    }
}
