using Coctel.ViewModel.Commands;
using Coctel.ViewModel.Helpers;
using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coctel.ViewModel
{
    class CocktailVM
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
            query = "Buscar cóctel...";

            Login(username, password);
            GetCocktails();
        }

        // Properties //
        public ObservableCollection<Cocktail> Cocktails { get; set; }
        public ObservableCollection<Ingrediente> Ingredientes { get; set; }

        
        public string username { get; set; }
        public string password { get; set; }
        public string query { get; set; }
        public Usuario User { get; set; }
        public Cocktail selectedCocktail { get; set; }
        public bool IsLogged;

        // Commands //
        public NewFavCommand NewFavCommand  { get; set; }
        public NewIngredientCommand NewIngredientCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public SearchCommand SearchCommand { get; set; }
        public GetIngredientsCommand GetIngredientsCommand { get; set; }


        // Methods //
        public void AddIngredient(Ingrediente ingrediente)
        {
            User.Inventario.Add(ingrediente);
            DatabaseVM.Insert(ingrediente.ID, User, "Inventario");
        }
        public void AddFav(Cocktail cocktail)
        {
            User.Favoritos.Add(cocktail);
            DatabaseVM.Insert(cocktail.ID, User, "Favorito");    
        }
        public void GetCocktails()
        {
            var cocktails = DatabaseVM.Read();
            var ingredients = DatabaseVM.Read(cocktails.First());
            Cocktails.Clear();
            foreach (var cocktail in cocktails)
            {
                Cocktails.Add(cocktail);
            }
            foreach (var ingredient in ingredients)
            {
                Ingredientes.Add(ingredient);
            }
        }
        public void GetCocktails(string query)
        {
            Cocktails.Clear();
            Ingredientes.Clear();
            var cocktails = DatabaseVM.Read(query);
            if (cocktails.Any())
            {
                var ingredients = DatabaseVM.Read(cocktails.First());
                foreach (var ingredient in ingredients)
                {
                    Ingredientes.Add(ingredient);
                }
            }           
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
            if (User.ID == -1) { IsLogged = true; }
        }
    }
}
