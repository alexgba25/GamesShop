using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesShop.Interfaces
{
    public interface IMailController
    {
        void SendPurchaseConfirmation(string toEmail, List<Cart> cartItems);
    }
}