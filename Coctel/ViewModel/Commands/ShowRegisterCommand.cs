using Coctel.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coctel.ViewModel.Commands
{
    class ShowRegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public ShowRegisterCommand(LoginVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.SwitchViews();
        }

    }
}
