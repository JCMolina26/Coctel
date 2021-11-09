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
        public CocktailVM VM { get; set; }
        public LoginCommand(CocktailVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {            
            return !VM.IsLogged;
        }

        public void Execute(object parameter)
        {
            VM.Login(VM.Username, VM.Password);
        }
    }
}
