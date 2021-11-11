using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coctel.ViewModel.Commands
{
    class GetFavCommand : ICommand
    {
        public CocktailVM VM { get; set; }
        public LoginVM loginVM { get; set; }
        public GetFavCommand(CocktailVM vm)
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
            VM.GetCocktails(VM.Login.User);
        }
    }
}
