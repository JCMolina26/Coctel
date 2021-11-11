using Coctel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coctel.ViewModel.Commands
{
    class ShowIngredientsManagerCommand : ICommand
    {
        public LoginVM VM;
        public ShowIngredientsManagerCommand(LoginVM vm)
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
            return VM.LoginStatus;
        }

        public void Execute(object parameter)
        {
            UserPanel userPanel = new UserPanel();
            userPanel.ShowDialog();
        }
    }
}
