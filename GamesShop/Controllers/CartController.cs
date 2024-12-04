using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesShop.Controllers
{
    public class CartController
    {
        private const string SessionCartKey = "Cart";
        private readonly GamesController _gamesController = new GamesController();

        public List<Cart> GetCart()
        {
            if (HttpContext.Current.Session[SessionCartKey] == null)
                HttpContext.Current.Session[SessionCartKey] = new List<Cart>();

            return (List<Cart>)HttpContext.Current.Session[SessionCartKey];
        }

        public void AddToCart(Cart item)
        {
            var cart = GetCart();
            var existingItem = cart.Find(i => i.ID_Videojuego == item.ID_Videojuego);

            if (existingItem != null)
            {
                int availableQuantity = _gamesController.GetQuantity(item.ID_Videojuego);
                if (existingItem.Cantidad + item.Cantidad <= availableQuantity)
                {
                    existingItem.Cantidad += item.Cantidad;
                    existingItem.Subtotal = existingItem.Cantidad * existingItem.Precio; // Actualizar subtotal
                }
                else
                {
                    throw new Exception("Cantidad insuficiente en inventario.");
                }
            }
            else
            {
                int availableQuantity = _gamesController.GetQuantity(item.ID_Videojuego);
                if (item.Cantidad <= availableQuantity)
                {
                    item.Subtotal = item.Cantidad * item.Precio; // Calcular subtotal al agregar
                    cart.Add(item);
                }
                else
                {
                    throw new Exception("Cantidad insuficiente en inventario.");
                }
            }
        }


        public decimal GetTotal()
        {
            var cart = GetCart();
            decimal total = 0;
            foreach (var item in cart)
            {
                total += item.Subtotal;
            }
            return total;
        }

        public void ClearCart()
        {
            HttpContext.Current.Session[SessionCartKey] = new List<Cart>();
        }


    }
}