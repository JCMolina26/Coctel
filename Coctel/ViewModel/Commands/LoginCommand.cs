using Coctel.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coctel.ViewModel.Commands
{
    class LoginCommand : ICommand
    {
        public bool IsLogged = false;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !IsLogged;
        }

        public void Execute(object parameter)
        {
            // bool result = DatabaseVM.Login(username.Text, password.Text);
            IsLogged = true;
        }
    }
}
