using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesShop.Interfaces
{
    interface IUsersController
    {
        bool Register(User user);
        bool Login(string username, string password);
    }
}
