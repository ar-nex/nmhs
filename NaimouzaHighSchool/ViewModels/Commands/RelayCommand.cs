using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace NaimouzaHighSchool.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        private Action ExecuteMethod;
        private Func<bool> CanExecuteMethod;
        private event EventHandler CanExecuteChangedInternal;


        public RelayCommand(Action Ex, Func<bool> CanEx)
        {
            this.ExecuteMethod = Ex;
            this.CanExecuteMethod = CanEx;
        }


        public bool CanExecute(object parameter)
        {
            return CanExecuteMethod();
        }



        public void Execute(object parameter)
        {
            ExecuteMethod();
        }



        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }
    }
}
