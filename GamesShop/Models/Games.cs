using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesShop.Models
{
    public class Games
    {
        public int ID_Videojuego { get; set; }
        public string Nombre { get; set; }
        public string Plataforma { get; set; }
        public string Desarrollador { get; set; }
        public decimal Precio { get; set; }
        public string Clasificación { get; set; }
        public string Género { get; set; }
        public int Cantidad_Disponible { get; set; }

        // Constructor que toma 8 argumentos
        public Games(int id, string nombre, string plataforma, string desarrollador, decimal precio, string clasificacion, string genero, int cantidad)
        {
            ID_Videojuego = id;
            Nombre = nombre;
            Plataforma = plataforma;
            Desarrollador = desarrollador;
            Precio = precio;
            Clasificación = clasificacion;
            Género = genero;
            Cantidad_Disponible = cantidad;
        }
    }

}