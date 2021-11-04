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
            Cocktails = new ObservableCollection<Cocktail>();
            Ingredientes = new ObservableCollection<Ingrediente>();

            GetCocktails();
        }

        // Properties //
        public ObservableCollection<Cocktail> Cocktails { get; set; }
        public ObservableCollection<Ingrediente> Ingredientes { get; set; }

        private Usuario user;
        public Usuario User
        {
            get { return user; }
            set { user = value; }
        }

        private Cocktail selectedCocktail;
        public Cocktail SelectedCocktail
        {
            get { return selectedCocktail; }
            set { selectedCocktail = value; }
        }

        // Commands //
        public NewFavCommand NewFavCommand  { get; set; }
        public NewIngredientCommand NewIngredientCommand { get; set; }
        public LoginCommand Login { get; set; }

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
            Cocktails.Clear();
            foreach (var cocktail in cocktails)
            {
                Cocktails.Add(cocktail);
            }
        }
        public void GetCocktails(string query)
        {
            var cocktails = DatabaseVM.Read(query);
            Cocktails.Clear();
            foreach (var cocktail in cocktails)
            {
                Cocktails.Add(cocktail);
            }
        }

        public void GetIngredients(Cocktail item)
        {
            var ingredientes = DatabaseVM.ReadIngredients(item);
            Ingredientes.Clear();
            foreach (var ingrediente in ingredientes)
            {
                Ingredientes.Add(ingrediente);
            }
        }
    }
}
