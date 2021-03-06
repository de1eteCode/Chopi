using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts
{
    internal class WindowVMWithPages : WindowVM
    {
        private readonly PageController _pageController;
        private Page? _currentPage;

        protected WindowVMWithPages()
        {
            _pageController = new();
            ChangePageCommand = new RelayCommand<PageVM>(SwitchPage);
        }

        public IEnumerable<PageVM> Pages => _pageController.Pages;

        public Page? CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PageTitle));
                }
            }
        }

        public string PageTitle => $"Чопи | {(CurrentPage?.DataContext as PageVM)?.Title ?? "Not found title"}";

        public ICommand ChangePageCommand { get; set; }

        protected void RegisterPageAndCreate<TVm, TPage>()
            where TVm : PageVM
            where TPage : Page
        {
            _pageController.RegisterVMToPageAndCreate<TVm, TPage>();

            if (CurrentPage is null)
            {
                SwitchPage((PageVM)_pageController.GetFirstPage().DataContext);
            }
        }

        private void SwitchPage(PageVM vm)
        {
            if (vm != CurrentPage?.DataContext)
            {
                if (vm.IsLoaded is false)
                {
                    // Метод зарузки
                    Task.Run(vm.OnLoad);
                }

                // Метод закрытия
                if (_currentPage?.DataContext is not null)
                {
                    Task.Run(((PageVM)_currentPage.DataContext).OnClose);
                }
                
                // Метод открытия
                Task.Run(vm.OnOpen);
                CurrentPage = _pageController.GetPage(vm);
            }
        }
    }
}
