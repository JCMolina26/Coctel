using Coctel.ViewModel.Commands;
using Coctel.ViewModel.Helpers;
using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Coctel.ViewModel
{
    class LoginVM : INotifyPropertyChanged   
    {
        // Constructor
        public LoginVM()
        {
            LoginVis = Visibility.Visible;
            RegisterVis = Visibility.Collapsed;
            LoggedVis = Visibility.Collapsed;
            User = new Usuario() { ID = -1 };
            LoginStatus = false;

            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
            ShowRegisterCommand = new ShowRegisterCommand(this);
            ShowIngredientsManagerCommand = new ShowIngredientsManagerCommand(this);
        }

        // Properties

        public bool isShowingRegister = false;

        private Visibility loginVis;
        public Visibility LoginVis
        {
            get { return loginVis; }
            set { loginVis = value;
                OnPropertyChanged("LoginVis");
            }
        }
        private Visibility registerVis;
        public Visibility RegisterVis
        {
            get { return registerVis; }
            set
            {
                registerVis = value;
                OnPropertyChanged("RegisterVis");
            }
        }
        private Visibility loggedVis;
        public Visibility LoggedVis
        {
            get { return loggedVis; }
            set
            {
                loggedVis = value;
                OnPropertyChanged("LoggedVis");
            }
        }
        private Usuario user;
        public Usuario User
        {
            get { return user; }
            set { user = value;
                OnPropertyChanged("User");
            }
        }
        private bool loginstatus;
        public bool LoginStatus
        {
            get { return loginstatus; }
            set {
                loginstatus = value;
                OnPropertyChanged("LoginStatus");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        // Commands
        public ShowRegisterCommand ShowRegisterCommand { get; set; }
        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public ShowIngredientsManagerCommand ShowIngredientsManagerCommand { get; set; }
        // Methods
        public void SwitchViews()
        {
            isShowingRegister = !isShowingRegister;
            if (isShowingRegister)
            {
                RegisterVis = Visibility.Visible;
                LoginVis = Visibility.Collapsed;
            }
            else
            {
                RegisterVis = Visibility.Collapsed;
                LoginVis = Visibility.Visible;
            }
        }
        public void Login()
        {
            User = DatabaseVM.Login(User);
            if (User.ID != -1) { LoginStatus = true; SwitchViews(); }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
