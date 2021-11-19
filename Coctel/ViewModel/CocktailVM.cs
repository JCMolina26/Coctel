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
        // Constructor
        public CocktailVM()
        {         
            NewFavCommand = new NewFavCommand(this);
            NewIngredientCommand = new NewIngredientCommand(this);
            SearchCommand = new SearchCommand(this);
            GetIngredientsCommand = new GetIngredientsCommand(this);
            GetFavCommand = new GetFavCommand(this);


            Cocktails = new ObservableCollection<Cocktail>();
            Ingredientes = new ObservableCollection<Ingrediente>();
            Login = new LoginVM();

            Query = "Buscar cóctel...";
            GetCocktails();         
        }

        // Properties //
        public ObservableCollection<Cocktail> Cocktails { get; set; }
        public ObservableCollection<Ingrediente> Ingredientes { get; set; }

        private LoginVM login;
        public LoginVM Login
        { 
            get { return login; } 
            set { login = value; OnPropertyChanged("Login"); if (Login.User.ID != -1) GetCocktails(Login.User); } 
        }
        
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
        private Ingrediente selectedIngredient;

        public Ingrediente SelectedIngredient
        {
            get { return selectedIngredient; }
            set { selectedIngredient = value;
                OnPropertyChanged("SelectedCocktail");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Commands //
        public NewFavCommand NewFavCommand  { get; set; }
        public NewIngredientCommand NewIngredientCommand { get; set; }
        public SearchCommand SearchCommand { get; set; }
        public GetIngredientsCommand GetIngredientsCommand { get; set; }
        public GetFavCommand GetFavCommand { get; set; }


        // Methods //
        public void AddIngredient(Ingrediente ingrediente)
        {
            if (!Login.User.Inventario.Any(item => item.ID == ingrediente.ID))
            {
                Login.User.Inventario.Add(ingrediente);
                DatabaseVM.Insert(ingrediente.ID, Login.User, "Inventario");
            } 
        }
        public void AddFav(Cocktail cocktail)
        {
            if (!Login.User.Favoritos.Any(item => item.ID == cocktail.ID))
            {
                Login.User.Favoritos.Add(cocktail);
                DatabaseVM.Insert(cocktail.ID, Login.User, "Favorito");
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
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void GetFavCocktails()
        {
            Cocktails.Clear();
            var cocktails = DatabaseVM.Read(Login.User);
            foreach (var cocktail in cocktails)
            {
                Cocktails.Add(cocktail);
            }
        }

    }
}
