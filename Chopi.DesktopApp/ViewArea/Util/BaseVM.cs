using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chopi.DesktopApp.ViewArea.Util
{
    public abstract class BaseVM : INotifyPropertyChanged
    {
        protected BaseVM() 
        {
#if DEBUG
            IsVisibility = Visibility.Visible;
            IsDEBUG = true;
            InitializationDebug();
#else
            IsVisibility = Visibility.Hidden;
            IsDEBUG = false;
#endif
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Visibility IsVisibility { get; }
        public bool IsDEBUG { get; }

        protected virtual void InitializationDebug() { }

        /// <summary>
        /// Открытие модальных окон
        /// </summary>
        /// <param name="vm">Объект ViewModal для окна</param>
        protected async Task<StatusModal> OpenDialog(PageVM vm, Page page)
        {
            if (page is null || vm is null)
                throw new ArgumentNullException();

            page.DataContext = vm;
            var modalVm = new ModalWindowVM(page);

            await ((App)Application.Current).Controller.ShowModal(modalVm);
            return modalVm.StatusModal;
        }
    }
}
