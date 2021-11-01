using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coctel.ViewModel.Helpers;

namespace CoctelClasses.Model
{
    public class Cocktail
    {
        public int ID { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Dificultad { get; set; }
        public int TiempoElaboracion { get; set; }
        public int PorcentajeRecomendacion { get; set; }
        public string Descripcion { get; set; }
    }

    public class Ingrediente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Calorias { get; set; }
        public int PorcentajeAlcohol { get; set; }

    }
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public List<Cocktail> Favoritos { get; set; }
        public List<Ingrediente> Inventario { get; set; }

        public bool NuevoFavorito(Cocktail coctel)
        {
            if (Favoritos.Contains(coctel))
            { return false; }
            else
            {
                bool success = DatabaseVM.InsertCocktail(coctel, this);
                if (success) { Favoritos.Add(item: coctel); return true; }
                else return false;
            }
        }
        public bool NuevoIngrediente(Ingrediente ingrediente)
        {
            if (Inventario.Contains(ingrediente))
            { return false; }
            else
            {
                bool success = DatabaseVM.InsertIngrediente(ingrediente, this);
                if (success) { Inventario.Add(ingrediente); return true; }
                else return false;
            }
        }
        public bool EliminarFavorito(Cocktail coctel)
        {
            if (!Favoritos.Contains(coctel))
            { return false; }
            else
            {
                bool success = DatabaseVM.DeleteCocktail(coctel, this);
                if (success) { Favoritos.Remove(item: coctel); return true; }
                else return false;
            }
        }
        public bool EliminarIngrediente(Ingrediente ingrediente)
        {
            if (!Inventario.Contains(ingrediente))
            { return false; }
            else
            {
                bool success = DatabaseVM.DeleteIngrediente(ingrediente, this);
                if (success) { Inventario.Remove(item: ingrediente); return true; }
                else return false;
            }
        }
    }
    public class Recomendacion
    {
        public int CoctelID { get; set; }
        private List<Usuario> recomendados;

        public List<Usuario> Recomendados //TODO//
        {
            get { return recomendados; }
            set { recomendados = value; }
        }
    }
}
