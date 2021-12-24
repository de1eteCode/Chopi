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

        private string _searchQuery = string.Empty;

        public PageWithPaginatorVM(
            ApiDatasService<TEntity, DataRequestCollection<TEntity>> service,
            ApiSignalController<TEntity> apiSignalController)
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
            _entities = new();

            _dataSource = NetworkClient.GetInstance<IDataSource>();

            _service = service;
            _apiSignalController = apiSignalController;

            _apiSignalController.AddEvent += AddItemResponse;
            _apiSignalController.UpdateEvent += UpdateItemResponse;
        }
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { _searchQuery = value; OnPropertyChanged(); }
        }

        private int _maxPage;

        public int CurrentPage { get; set; }
        public int MaxPage
        {
            get 
            { 
                return _maxPage; 
            }
            set 
            { 
                _maxPage = value;
                OnPropertyChanged();
            }
        }

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

            _dispatcher.Invoke(() => _entities[_entities.IndexOf(item)] = e);
        }

        private void AddItemResponse(object? sender, TEntity e)
        {
            _dispatcher.Invoke(() => _entities.Add(e));
        }


        #region Filter and sort

        private Filter _selectedFilter;

        public List<Filter> Filters { get; protected set; }
        public List<Sorting> Sorts { get; protected set; }

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
            set { _selectedFilter = value; }
        }

        private Sorting _selectedSort;

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
            set { _selectedSort = value; }
        }



        public IEnumerable<TEntity> Entities => _entities;


        #endregion
    }
}
