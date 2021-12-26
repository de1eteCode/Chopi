using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    abstract class BaseCUVM : ModalPageVM
    {
        protected abstract CUStatus Status { get; }
    }
}
