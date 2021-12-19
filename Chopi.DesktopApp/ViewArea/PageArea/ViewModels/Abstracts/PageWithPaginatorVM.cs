using Chopi.DesktopApp.Models.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts
{
    internal abstract class PageWithPaginatorVM<T> : PageVM
        where T : CachedObject
    {
        private readonly CacheObjects<T, DataRequestCollection<T>> _cacheObjects;
        private string _searchQuery = string.Empty;

        public PageWithPaginatorVM()
        {

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
    }
}
