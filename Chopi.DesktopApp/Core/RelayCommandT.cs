using System;
using System.Windows.Input;

namespace Chopi.DesktopApp.Core
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T?, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<T> execute, Func<T?, bool>? canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action execute)
        {
            _execute = (obj) => execute();
            _canExecute = null;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object? parameter)
        {
            _execute((T)parameter);
        }
    }
}
