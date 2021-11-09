using Coctel.ViewModel.Commands;
using Coctel.ViewModel.Helpers;
using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coctel.ViewModel
{
    class CocktailVM: INotifyPropertyChanged
    {
        public CocktailVM()
        {         
            NewFavCommand = new NewFavCommand(this);
            NewIngredientCommand = new NewIngredientCommand(this);
            LoginCommand = new LoginCommand(this);
            SearchCommand = new SearchCommand(this);
            GetIngredientsCommand = new GetIngredientsCommand(this);


            Cocktails = new ObservableCollection<Cocktail>();
            Ingredientes = new ObservableCollection<Ingrediente>();
            IsLogged = false;
            Query = "Buscar cóctel...";
            GetCocktails();         
        }

        // Properties //
        public ObservableCollection<Cocktail> Cocktails { get; set; }
        public ObservableCollection<Ingrediente> Ingredientes { get; set; }


        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Usuario User { get; set; }
        private string query;

        public string Query
        {
            get { return query; }
            set { query = value;
                OnPropertyChanged("Query");
                if (query != null) { GetCocktails(Query); }
            }
        }


        private Cocktail selectedCocktail;

        public Cocktail SelectedCocktail
        {
            get { return selectedCocktail; }
            
            set {
                selectedCocktail = value;
                OnPropertyChanged("SelectedCocktail");
                if (selectedCocktail != null) { GetIngredients(selectedCocktail); } }
        }

        public bool IsLogged;

        public event PropertyChangedEventHandler PropertyChanged;

        // Commands //
        public NewFavCommand NewFavCommand  { get; set; }
        public NewIngredientCommand NewIngredientCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public SearchCommand SearchCommand { get; set; }
        public GetIngredientsCommand GetIngredientsCommand { get; set; }


        // Methods //
        public void AddIngredient(Ingrediente ingrediente)
        {
            if (!User.Inventario.Contains(ingrediente))
            {
                User.Inventario.Add(ingrediente);
                DatabaseVM.Insert(ingrediente.ID, User, "Inventario");
            } 
        }
        public void AddFav(Cocktail cocktail)
        {
            if (!User.Favoritos.Contains(cocktail))
            {
                User.Favoritos.Add(cocktail);
                DatabaseVM.Insert(cocktail.ID, User, "Favorito");
            }  
        }
        public void GetCocktails()
        {
            var cocktails = DatabaseVM.Read();
            Cocktails.Clear();
            foreach (var cocktail in cocktails)
            {
                Cocktails.Add(cocktail);
            }
        }
        public void GetCocktails(string text)
        {
            Cocktails.Clear();
            var cocktails = DatabaseVM.Read(text); 
            foreach (var cocktail in cocktails)
            {
                Cocktails.Add(cocktail);
            }        
        }
        public void GetCocktails(Usuario usuario)
        {
            Cocktails.Clear();
            var cocktails = DatabaseVM.Read(usuario);
            foreach (var cocktail in cocktails)
            {
                Cocktails.Add(cocktail);
            }
        }
        public void GetIngredients(Cocktail item)
        {
            var ingredientes = DatabaseVM.Read(item);
            Ingredientes.Clear();
            foreach (var ingrediente in ingredientes)
            {
                Ingredientes.Add(ingrediente);
            }
        }
        public void Login(string usuario, string pass)
        {
            User = DatabaseVM.Login(usuario, pass);
            if (User.ID != -1) { IsLogged = true; GetCocktails(User); }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
