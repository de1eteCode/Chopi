using Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts;
using System.Windows;

namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.CU
{
    abstract class BaseCUVM : ModalPageVM
    {
        protected abstract CUStatus Status { get; }
        public bool IsCreate => Status == CUStatus.Create;
        public bool IsUpdate => Status == CUStatus.Update;
        public Visibility IsVisibilityIfCreateHidden => IsCreate ? Visibility.Visible : Visibility.Hidden;
    }
}
