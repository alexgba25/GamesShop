using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesShop.Models
{
    public class Cart
    {
        public int ID_Videojuego { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}