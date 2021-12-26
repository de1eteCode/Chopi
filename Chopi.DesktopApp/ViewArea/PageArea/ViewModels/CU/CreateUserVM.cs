using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    class CreateUserVM : BaseCUVM
    {
        private ApiDatasService<string, DataRequestCollection<string>> _service;
        private IDataSource _dataSource;
        private string _selectedRole;
        private ObservableCollection<string> _roles = new();

        public CreateUserVM(UserData data)
        {
            var disp = Dispatcher.CurrentDispatcher;
            Data = data;
            _dataSource = NetworkClient.GetInstance<IDataSource>();
            _service = new RolesService();
            Task.Run(() => disp.InvokeAsync(async () =>
            {
                Roles = new(await _dataSource.CollectionServiceAsync(_service));
                SelectedRole = Roles.First();
            }));
        }

        public override string Title => "Регистрация";

        public UserData Data { get; }

        protected override CUStatus Status => CUStatus.Create;

        public ObservableCollection<string> Roles
        {
            get
            {
                if (_roles is null)
                    _roles = new ObservableCollection<string>();
                return _roles;
            }
            set
            {
                _roles = value;
                OnPropertyChanged();
            }
        }

        public override string ErrorOnApply => "Данные не соответствуют полям";

        public string SelectedRole
        {
            get
            {
                if (string.IsNullOrEmpty(_selectedRole))
                {
                    _selectedRole = Roles.FirstOrDefault();
                }
                return _selectedRole;
            }
            set
            {
                _selectedRole = value;
                OnPropertyChanged();
            }

        }

        public override void OnApply()
        {
            Data.Roles = new List<string>() { SelectedRole };
        }

        public override bool IsApply()
        {
            return Data.IsValid();
        }
    }
}
