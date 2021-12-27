using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.Modules.Share.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    internal class UpdateAutopartVM : BaseCUVM
    {
        private string _selectedManufacture;
        private ObservableCollection<string> _manufactures;

        public UpdateAutopartVM(AutopartData data)
        {
            Data = data;
            var dispatcher = Dispatcher.CurrentDispatcher;
            var datasource = NetworkClient.GetInstance<IDataSource>();
            var service1 = new ManufacturesService();
            Task.Run(() => dispatcher.Invoke(async () =>
            {
                Manufactures = new(await datasource.CollectionServiceAsync(service1));
                SelectedManufacture = Manufactures.FirstOrDefault();
            }));
        }

        public override string ErrorOnApply => throw new NotImplementedException();

        public override string Title => "Обновление детали";

        protected override CUStatus Status => CUStatus.Update;

        public AutopartData Data { get; set; }

        public ObservableCollection<string> Manufactures
        {
            get
            {
                if (_manufactures == null)
                    _manufactures = new ObservableCollection<string>();
                return _manufactures;
            }
            set
            {
                _manufactures = value;
                OnPropertyChanged();
            }
        }

        public string SelectedManufacture
        {
            get
            {
                if (string.IsNullOrEmpty(_selectedManufacture))
                {
                    _selectedManufacture = Manufactures.FirstOrDefault();
                }
                return _selectedManufacture;
            }
            set
            {
                _selectedManufacture = value;
                OnPropertyChanged();
            }
        }

        public override bool IsApply()
        {
            Data.ManufactureName = SelectedManufacture;
            return Data.IsValid();
        }
    }
}
