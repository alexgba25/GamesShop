using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GamesShop.Interfaces
{
    public interface IGamesController
    {
        DataTable GetAllGames();
        DataTable GetById(int id);
        void AddGame(string nombre, string plataforma, string desarrollador, decimal precio, string clasificación, string género, int cantidadDisponible);
        void DeleteGame(int id);
        void UpdateGame(int id, string nombre, string plataforma, string desarrollador, decimal precio, string clasificación, string género, int cantidadDisponible);
        int GetQuantity(int id);
        void UpdateQuantity(int id, int change);
    }
}