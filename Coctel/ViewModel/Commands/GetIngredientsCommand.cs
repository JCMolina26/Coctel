using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coctel.ViewModel.Commands
{
    class GetIngredientsCommand : ICommand
    {
        public CocktailVM VM { get; set; }
        public GetIngredientsCommand(CocktailVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            Cocktail selectedCocktail = parameter as Cocktail;
            return (selectedCocktail != null);
        }

        public void Execute(object parameter)
        {
            Cocktail selectedCocktail = parameter as Cocktail;
            VM.GetIngredients(selectedCocktail);
        }
    }
}
