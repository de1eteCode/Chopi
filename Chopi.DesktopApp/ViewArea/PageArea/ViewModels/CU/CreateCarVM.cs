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
    internal class CreateCarVM : BaseCUVM
    {
        private string _selectedManufacture;
        private string _selectedModel;
        private string _selectedCompletes;
        private ObservableCollection<string> _manufactures;
        private ObservableCollection<string> _models;
        private ObservableCollection<string> _completes;

        public CreateCarVM(CarCompleteData data)
        {
            Data = data;
            var dispatcher = Dispatcher.CurrentDispatcher;
            var datasource = NetworkClient.GetInstance<IDataSource>();
            var service1 = new ManufacturesService();
            var service2 = new ModelsService();
            var service3 = new CompletesService();
            Task.Run(() => dispatcher.Invoke(async () =>
            {
                Models = new(await datasource.CollectionServiceAsync(service2));
                SelectedModels = Models.FirstOrDefault();

                Manufactures = new(await datasource.CollectionServiceAsync(service1));
                SelectedManufacture = Manufactures.FirstOrDefault();

                Completes = new(await datasource.CollectionServiceAsync(service3));
                SelectedComplete = Completes.FirstOrDefault();
            }));
        }

        public CarCompleteData Data { get; set; }

        public override string Title => "Создание машины";

        protected override CUStatus Status => CUStatus.Create;

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

        public ObservableCollection<string> Models
        {
            get
            {
                if (_models == null)
                    _models = new ObservableCollection<string>();
                return _models;
            }
            set
            {
                _models = value;
                OnPropertyChanged();
            }
        }

        public string SelectedModels
        {
            get
            {
                if (string.IsNullOrEmpty(_selectedModel))
                {
                    _selectedModel = Models.FirstOrDefault();
                }
                return _selectedModel;
            }
            set
            {
                _selectedModel = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> Completes
        {
            get
            {
                if (_completes == null)
                    _completes = new ObservableCollection<string>();
                return _completes;
            }
            set
            {
                _completes = value;
                OnPropertyChanged();
            }
        }

        public string SelectedComplete
        {
            get
            {
                if (string.IsNullOrEmpty(_selectedCompletes))
                {
                    _selectedCompletes = Completes.FirstOrDefault();
                }
                return _selectedCompletes;
            }
            set
            {
                _selectedCompletes = value;
                OnPropertyChanged();
            }
        }

        public override bool IsApply()
        {
            Data.BrandName = SelectedManufacture;
            Data.ModelName = SelectedModels;
            Data.CompleteName = SelectedComplete;
            return Data.IsValid();
        }
    }
}
