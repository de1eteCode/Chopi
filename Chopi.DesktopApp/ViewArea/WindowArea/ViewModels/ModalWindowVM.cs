using Chopi.DesktopApp.Core;
using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using Chopi.DesktopApp.ViewArea.Util;
using Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts;
using System.Threading.Tasks;
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

        private ModalPageVM Context
        {
            get
            {
                if (CurrentPage.DataContext is ModalPageVM vm)
                {
                    return vm;
                }
                else
                {
                    return null;
                }
            }
        }

        public ICommand Apply
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Task.Run(Context.OnApply);

                    if (Context.IsApply())
                        StatusModal = StatusModal.Ok;
                    else
                        MsgShowError(Context.ErrorOnApply);
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
                });
            }
        }
    }
}
