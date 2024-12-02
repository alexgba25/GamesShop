using GamesShop.Data.DbGamesTableAdapters;
using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GamesShop.Controllers
{
    public class GamesController
    {
        private videojuegosTableAdapter adapter = new videojuegosTableAdapter();

        public DataTable GetAllGames()
        {
            return adapter.GetData();
        }

        public void AddGame(string nombre, string plataforma, string desarrollador, decimal precio, string clasificación, string género, int cantidadDisponible)
        {
            adapter.InsertQuery(nombre, plataforma, desarrollador, precio, clasificación, género, cantidadDisponible);
        }


        public void DeleteGame(int id)
        {
            adapter.DeleteQuery(id);
        }

        public void UpdateGame(int id, string nombre, string plataforma, string desarrollador, decimal precio, string clasificación, string género, int cantidadDisponible)
        {
            adapter.UpdateQuery(nombre, plataforma, desarrollador, precio, clasificación, género, cantidadDisponible, id);
        }

    }
}