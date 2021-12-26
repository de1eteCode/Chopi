using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.ApiSignalR;
using Chopi.DesktopApp.Models.Extends;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.Models.ObjectSorting;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU;
using Chopi.DesktopApp.ViewArea.PageArea.Views;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.RequestModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class ControlPanelUsersVM : PageWithPaginatorVM<UserData>
    {

        public UserData _currentUser;
        private IDataSource _dataSource;
        private ApiDataService<UserData, DataRequest<UserData>> _dataService;

        public ControlPanelUsersVM()
            : base(new UserService(), new UserSignalR())
        {
            _dataSource = NetworkClient.GetInstance<IDataSource>();
            _dataService = new AboutMeService();

            OpenUpdateUserCommand = new RelayCommand(OpenUpdateUser);
            OpenCreateUserCommand = new RelayCommand(OpenCreateUser);

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
        public ICommand OpenCreateUserCommand { get; set; }

        public override async void OnOpen()
        {
            var data = await _dataSource.ObjectServiceAsync(_dataService);

            if (data is not null)
            {
                _currentUser = data;
            }

            base.OnOpen();
        }

        private async void OpenUpdateUser()
        {
            UserData data = SetectedEntity.CopyObj<UserData>();

            if (data is null)
            {
                MsgShowError("Не выбран пользователь");
                return;
            }

            if (_currentUser.Equals(SetectedEntity))
            {
                MsgShowError("В данном контексте себя изменить невозможно");
                return;
            }

            var status = await OpenDialog(new UpdateUserVM(data), new CUUser());
            if (status == Util.StatusModal.Ok)
            {
                var net = NetworkClient.GetInstance<IExecuter>();
                var service = new UpdateUserService(data);
                var result = await net.ExecuteAsync(service);

                if (result is null || result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MsgShowError("В ходе обновления произошла ошибка.");
                    return;
                }
                else
                {
                    MsgShowInfo($"Пользователь {data.UserName} обновлен");
                }
            }
        }

        private async void OpenCreateUser()
        {
            var data = new UserData();
            data.DateOfBirth = System.DateTime.Now.Date;
            var status = await OpenDialog(new CreateUserVM(data), new CUUser());
            if (status == Util.StatusModal.Ok)
            {
                // Todo: Register user

                var executer = NetworkClient.GetInstance<IExecuter>();

                var regModel = new RegisterModel()
                {
                    SecondName = data.SecondName,
                    Citizenship = data.Citizenship,
                    DateOfBirth = data.DateOfBirth,
                    Series = data.Series,
                    Email = data.Email,
                    FirstName = data.FirstName,
                    MiddleName = data.MiddleName,
                    Number = data.Number,
                    ResidenceRegistration = data.ResidenceRegistration,
                    Roles = data.Roles,
                    Username = data.UserName,
                    Password = "_asd12NMSDx",
                    PasswordConfirim = "_asd12NMSDx"
                };

                var service = new RegisterService(regModel);
                var res = await executer.ExecuteAsync(service);

                if (res is not null && res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MsgShowInfo($"Аккаунт {data.UserName} успешно зарегистрирован. Пароль: _asd12NMSDx");
                }
                else
                {
                    MsgShowError("При регистрации аккаунта произошла непредвиденная ошибка");
                }
            }
        }
    }
}
