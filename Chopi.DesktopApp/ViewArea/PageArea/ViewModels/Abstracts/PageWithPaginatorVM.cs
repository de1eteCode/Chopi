using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.Models;
using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.DesktopApp.Models.Extends;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.Models.ObjectSorting;
using Chopi.Modules.Share;
using Chopi.Modules.Share.Abstracts;
using Chopi.Modules.Share.HubInterfaces.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts
{
    internal abstract class PageWithPaginatorVM<TEntity> : PageVM
        where TEntity : ObjectConteinered
    {
        private ObservableCollection<TEntity> _entities;
        private ApiDatasService<TEntity, DataRequestCollection<TEntity>> _service;
        private ApiSignalController<TEntity> _apiSignalController;
        private IDataSource _dataSource;
        private Dispatcher _dispatcher;


        public PageWithPaginatorVM(
            ApiDatasService<TEntity, DataRequestCollection<TEntity>> service,
            ApiSignalController<TEntity> apiSignalController)
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
            _entities = new();
            
            _dataSource = NetworkClient.GetInstance<IDataSource>();

            _service = service;
            _apiSignalController = apiSignalController;

            if (_apiSignalController is null)
                return;

            _apiSignalController.AddEvent += AddItemResponse;
            _apiSignalController.UpdateEvent += UpdateItemResponse;
        }

        public TEntity SetectedEntity { get; set; }

        public override async void OnOpen()
        {
            await _apiSignalController.Start();

            var data = await _dataSource.CollectionServiceAsync(_service);
            data?.ForEach(e => UpdateItemResponse(null, e));
        }

        public override async void OnClose()
        {
            await _apiSignalController.Stop();
        }

        private void UpdateItemResponse(object? sender, TEntity e)
        {
            var item = _entities.Where(s => s.Id == e.Id).FirstOrDefault();

            if (item is null)
            {
                AddItemResponse(sender, e);
                return;
            }

            _dispatcher.Invoke(() =>
            {
                _entities[_entities.IndexOf(item)] = e;
                OnPropertyChanged(nameof(Entities));
            });
        }

        private void AddItemResponse(object? sender, TEntity e)
        {
            _dispatcher.Invoke(() =>
            {
                _entities.Add(e);
                OnPropertyChanged(nameof(Entities));
            });
        }

        #region Filter sort paging

        private string _searchQuery = string.Empty;
        private int _dispInPage = 20;
        private int _currentPage = 1;

        private Filter _selectedFilter;
        private Sorting _selectedSort;

        public List<Filter> Filters { get; protected set; } = new List<Filter>() { new Filter("SampleData1", string.Empty), new Filter("SampleData2", string.Empty) };
        public List<Sorting> Sorts { get; private set; } = new()
        {
            new OBy(),
            new ODistinct()
        };

        public Filter SelectedFilter
        {
            get
            {
                if (_selectedFilter is null)
                {
                    _selectedFilter = Filters.FirstOrDefault();
                }
                return _selectedFilter;
            }
            set 
            { 
                _selectedFilter = value;
                OnPropertyChanged(nameof(Entities));
            }
        }

        public Sorting SelectedSort
        {
            get
            {
                if (_selectedSort is null)
                {
                    _selectedSort = Sorts.FirstOrDefault();
                }
                return _selectedSort;
            }
            set 
            { 
                _selectedSort = value;
                OnPropertyChanged(nameof(Entities));
            }
        }

        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Entities));
            }
        }


        public int CurrentPage
        {
            get { return _currentPage; }
            set 
            { 
                _currentPage = value;
                OnPropertyChanged(nameof(Entities));
            }
        }

        public int MaxPage
        {
            get => (int)(Math.Ceiling((double)_entities.Count / (double)_dispInPage));
            set
            {
                return;
            }
        }


        public IEnumerable<TEntity> Entities
        {
            get
            {
                OnPropertyChanged(nameof(MaxPage));
                return _entities
                    .Ordering(SelectedSort, SelectedFilter.Property)
                    .Filtered(SelectedFilter, SearchQuery)
                    .Pagging(CurrentPage - 1, _dispInPage);
            }
        }



        #endregion
    }
}
