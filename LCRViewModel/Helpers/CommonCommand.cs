using System;
using System.Windows.Input;

namespace LCRViewModel.Helpers
{
    public class CommonCommand : ICommand
    {
        private Action<object> ExecuteAction;
        private Func<object, bool> IsExecutable;

        public event EventHandler CanExecuteChanged;

        public CommonCommand(Action<object> executeAction, Func<object, bool> isExecutable) {
            ExecuteAction = executeAction;
            IsExecutable = isExecutable;
        }

        public void CheckIsExecutable() {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsExecutable(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }
    }
}
