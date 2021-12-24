using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    internal class UpdateUserVM : PageVM
    {
        private ApiDatasService<string, DataRequestCollection<string>> _service;
        private IDataSource _dataSource;
        private string _selectedRole;
        private IEnumerable<string> _roles;

        public UpdateUserVM(UserData data)
        {
            var disp = Dispatcher.CurrentDispatcher;
            ChangedUser = data;
            _dataSource = NetworkClient.GetInstance<IDataSource>();
            _service = new RolesService();
            _roles = new List<string>();
            Task.Run(() => disp.InvokeAsync(async () =>
            {
                _roles = await _dataSource.CollectionServiceAsync(_service);
                OnPropertyChanged(nameof(Roles));
            }));
        }

        public override string Title => "Обновление пользователя";
        public UserData ChangedUser { get; set; }

        public IEnumerable<string> Roles
        {
            get
            {
                if (_roles is null)
                    _roles = new List<string>();
                return _roles;
            }
            set => _roles = value;
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
            set => _selectedRole = value;

        }

    }
}
