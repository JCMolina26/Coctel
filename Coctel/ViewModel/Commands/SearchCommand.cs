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
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            string query = parameter.ToString();
            return (query != null);
        }

        public void Execute(object parameter)
        {
            string query = parameter as string;
            VM.GetCocktails(query);
        }
    }
}
