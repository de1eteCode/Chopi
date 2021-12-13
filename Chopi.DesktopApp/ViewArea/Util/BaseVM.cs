using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Chopi.DesktopApp.ViewArea.Util
{
    public class BaseVM : INotifyPropertyChanged
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
    }
}
