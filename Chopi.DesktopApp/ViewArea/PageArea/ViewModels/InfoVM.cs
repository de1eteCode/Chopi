using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels
{
    class InfoVM : PageVM
    {
        public UserData _informationUser;
        private IDataSource _dataSource;
        private ApiDataService<UserData, DataRequest<UserData>> _dataService;

        public InfoVM()
        {
            _dataSource = NetworkClient.GetInstance<IDataSource>();
            _dataService = new AboutMeService();
        }
        
        public override string Title => "Информация";

        
        public UserData InformationUser
        {
            get => _informationUser;
            set
            {
                _informationUser = value;
                OnPropertyChanged();
            }
        }

        public override async void OnOpen()
        {
            var data = await _dataSource.ObjectServiceAsync(_dataService);

            if (data is not null)
            {
                InformationUser = data;
            }
        }
    }
}
