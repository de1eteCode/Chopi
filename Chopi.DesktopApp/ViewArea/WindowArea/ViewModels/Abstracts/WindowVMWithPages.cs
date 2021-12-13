using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                }
            }
        }

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
                    Task.Run(vm.OnLoad);
                }
                Task.Run(vm.OnOpen);
                CurrentPage = _pageController.GetPage(vm);
            }
        }
    }
}
