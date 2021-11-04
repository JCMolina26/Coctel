using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coctel.ViewModel.Commands 
{
    class NewFavCommand : ICommand
    {
        public CocktailVM VM { get; set; }
        public NewFavCommand(CocktailVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return VM.IsLogged;
        }

        public void Execute(object parameter)
        {
            Cocktail selectedCocktail = parameter as Cocktail;
            VM.AddFav(selectedCocktail);
        }
    }
}
