using System;
using System.Windows.Input;

namespace dz6.InfoStructure
{
    public class RelayCommand:ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;

        public RelayCommand(Action<object> action, Predicate<object> predicate = null)
        {
            _action = action;
            _predicate = predicate;
        }


        public bool CanExecute(object parameter) => _predicate?.Invoke(parameter) ?? true;


        public void Execute(object parameter) => _action?.Invoke(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}