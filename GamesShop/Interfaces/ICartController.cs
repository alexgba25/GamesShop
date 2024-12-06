using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesShop.Interfaces
{
    public interface ICartController
    {
        List<Cart> GetCart();
        string AddToCart(Cart item);
        decimal GetTotal();
        void ClearCart();
        void RemoveFromCart(int idVideojuego);
    }
}