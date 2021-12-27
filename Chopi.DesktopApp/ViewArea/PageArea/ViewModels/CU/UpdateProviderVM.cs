using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.ApiServices.Services;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.Modules.Share.DataModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    internal class UpdateProviderVM : BaseCUVM
    {
        private string _selectedCountry;
        private ObservableCollection<string> _countries;

        public UpdateProviderVM(ProviderData data)
        {
            var disp = Dispatcher.CurrentDispatcher;
            Data = data;
            var datasource = NetworkClient.GetInstance<IDataSource>();
            var service = new CountriesService();
            Task.Run(() => disp.InvokeAsync(async () =>
            {
                Countries = new(await datasource.CollectionServiceAsync(service));
                SelectedCountry = Countries.First();
            }));
        }

        public override string Title => "Обновление поставщика";

        protected override CUStatus Status => CUStatus.Update;

        public ProviderData Data { get; set; }

        public ObservableCollection<string> Countries
        {
            get
            {
                if (_countries is null)
                    _countries = new ObservableCollection<string>();
                return _countries;
            }
            set
            {
                _countries = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCountry
        {
            get
            {
                if (string.IsNullOrEmpty(_selectedCountry))
                {
                    _selectedCountry = Countries.FirstOrDefault();
                }
                return _selectedCountry;
            }
            set
            {
                _selectedCountry = value;
                OnPropertyChanged();
            }
        }

        public override void OnApply()
        {
            Data.CountryName = SelectedCountry;
        }

        public override bool IsApply()
        {
            return Data.IsValid();
        }
    }
}
