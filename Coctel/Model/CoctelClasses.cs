using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoctelClasses.Model
{
    class Coctel
    {
        public int CoctelID { get; set;}
        public List<Ingrediente> Ingredientes { get; set;}
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Dificultad { get; set; }
        public int TiempoElaboracion { get; set; }
        public int PorcentajeRecomendacion { get; set; }
        public string Descripcion { get; set; }
    }

    class Ingrediente
    {
        public int IngredienteID { get; set; }
        public string Nombre { get; set; }
        public int Calorias { get; set; }
        public int PorcentajeAlcohol { get; set; }
        
    }
    class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public List<Coctel> Favoritos { get; set; }
        public List<Ingrediente> Inventario { get; set; }

        public bool NuevoFavorito(Coctel coctel)
        {
            if (Favoritos.Contains(coctel)) { return false; } else { Favoritos.Add(item: coctel); return true; }
      
        }
        public bool NuevoIngrediente(Ingrediente ingrediente)
        {
            if (Inventario.Contains(ingrediente)) { return false; } else { Inventario.Add(ingrediente); return true; }
        }
    }
    class Recomendacion
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
