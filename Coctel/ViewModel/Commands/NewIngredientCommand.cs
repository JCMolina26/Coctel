using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coctel.ViewModel.Commands
{
    class NewIngredientCommand : ICommand
    {
        public CocktailVM VM { get; set; }
        public NewIngredientCommand(CocktailVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            Ingrediente selectedIngredient = parameter as Ingrediente;
            return /*(IsLogged) &&*/ selectedIngredient != null;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
