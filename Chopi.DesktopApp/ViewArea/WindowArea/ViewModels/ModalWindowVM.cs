using Chopi.DesktopApp.ViewArea.Util;
using System.Windows.Controls;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels
{
    public class ModalWindowVM : BaseVM
    {
        public ModalWindowVM(Page page)
        {
            CurrentPage = page;
        }

        public StatusModal StatusModal { get; private set; } = StatusModal.NoSet;

        public Page CurrentPage { get; private set; }
    }
}
