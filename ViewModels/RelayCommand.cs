using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRManagementApp.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action Execute { get; set; }
        private Func<bool>? CanExecute { get; set; }
        public RelayCommand(Action execute)
        {
            Execute = execute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            Execute = execute;
            CanExecute = canExecute;
        }

        event EventHandler? ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object? parameter)
        {
            if (CanExecute != null)
            {
                return CanExecute();
            }

            return true;
        }


        void ICommand.Execute(object? parameter)
        {
            if(Execute != null)
            {
                Execute();
            }
        }

    }
}
