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
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return VM.Login.LoginStatus && VM.SelectedIngredient != null;
        }

        public void Execute(object parameter)
        {
            VM.AddIngredient(VM.SelectedIngredient);
        }
    }
}
