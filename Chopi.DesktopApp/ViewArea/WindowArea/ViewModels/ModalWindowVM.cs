using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.ViewArea.Util;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels
{
    public class ModalWindowVM : WindowVM
    {
        public ModalWindowVM(Page page)
        {
            CurrentPage = page;
        }

        public StatusModal StatusModal { get; private set; } = StatusModal.NoSet;

        public Page CurrentPage { get; private set; }

        public ICommand Apply
        {
            get
            {
                return new RelayCommand(() =>
                {
                    StatusModal = StatusModal.Ok;
                    Close();
                });
            }
        }
        public ICommand Cancel
        {
            get
            {
                return new RelayCommand(() =>
                {
                    StatusModal = StatusModal.Cancel;
                    Close();
                });
            }
        }
    }
}
