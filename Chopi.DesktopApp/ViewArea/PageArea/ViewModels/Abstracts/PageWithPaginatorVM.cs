using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts
{
    internal abstract class PageWithPaginatorVM : PageVM
    {
        private string _searchQuery;

        public PageWithPaginatorVM()
        {
            CurrentPage = 2;
        }

        public string SearchQuery
        {
            get { return _searchQuery; }
            set { _searchQuery = value; OnPropertyChanged(); }
        }

        private int _maxPage;
        private int _currentPage;

        public int CurrentPage
        {
            get 
            {
                return _currentPage; 
            }
            set 
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

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
