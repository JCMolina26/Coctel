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
    class SearchCommand : ICommand
    {
        public CocktailVM VM { get; set; }

        public SearchCommand(CocktailVM vm)
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
            return (VM.Query != null);
        }

        public void Execute(object parameter)
        {
            var query = parameter as string;
            VM.GetCocktails(query);
        }
    }
}
