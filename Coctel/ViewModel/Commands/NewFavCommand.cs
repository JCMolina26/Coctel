using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return VM.Login.LoginStatus;
        }

        public void Execute(object parameter)
        {
            VM.AddFav(VM.SelectedCocktail);            
        }
    }
}
