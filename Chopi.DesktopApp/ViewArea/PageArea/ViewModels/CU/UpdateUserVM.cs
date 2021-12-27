using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    internal class UpdateUserVM : BaseCUVM
    {
        private ApiDatasService<string, DataRequestCollection<string>> _service;
        private IDataSource _dataSource;
        private string _selectedRole;
        private ObservableCollection<string> _roles = new();

        public UpdateUserVM(UserData data)
        {
            var disp = Dispatcher.CurrentDispatcher;
            Data = data;
            _dataSource = NetworkClient.GetInstance<IDataSource>();
            _service = new RolesService();
            Task.Run(() => disp.InvokeAsync(async () =>
            {
                Roles = new(await _dataSource.CollectionServiceAsync(_service));
                SelectedRole = Roles.Where(r => r.Equals(data.Roles.First())).First();
            }));
        }

        public override string Title => "Обновление пользователя";
        protected override CUStatus Status => CUStatus.Update;
        public UserData Data { get; set; }

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
