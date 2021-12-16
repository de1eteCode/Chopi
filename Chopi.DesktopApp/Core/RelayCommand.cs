using System;

namespace Chopi.DesktopApp.Core
{
    public class RelayCommand : RelayCommand<object?>
    {

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute) : base(execute, canExecute) { }

        public RelayCommand(Action<object?> execute) : this(execute, null) { }

        public RelayCommand(Action execute) : base(execute) { }
    }
}
