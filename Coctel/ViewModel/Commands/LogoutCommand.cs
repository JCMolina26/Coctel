using Coctel.ViewModel.Helpers;
using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coctel.ViewModel.Commands
    {
        class LogoutCommand : ICommand
        {
            public CocktailVM VM { get; set; }
            public LogoutCommand(CocktailVM vm)
            {
                VM = vm;
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter)
            {
                Usuario user = parameter as Usuario;
                if (user == null) return false;
                if (string.IsNullOrWhiteSpace(user.Nombre)) return false;
                if (string.IsNullOrWhiteSpace(user.Password)) return false;
                else return true;

            }

            public void Execute(object parameter)
            {
                //TODO
            }
        }
    }

