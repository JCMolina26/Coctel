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
        public int Cantidad { get; set; }

    }
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public List<Cocktail> Favoritos { get; set; }
        public List<Ingrediente> Inventario { get; set; }
    }
}
