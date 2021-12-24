using Chopi.DesktopApp.ViewArea.Util;
using System.Windows;

namespace Chopi.DesktopApp.ViewArea.WindowArea.ViewModels.Abstracts
{
    public abstract class WindowVM : BaseVM
    {
        public WindowVM()
        {
        }

        protected void Close() => Close(this);

        protected void Close(WindowVM vm)
        {
            var controller = ((App)Application.Current).Controller;
            controller.CloseWindow(vm);
        }
    }

}
