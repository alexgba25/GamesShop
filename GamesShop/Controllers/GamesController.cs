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

        public DataTable GetById(int id)
        {
            return adapter.GetDataById(id);
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

        public int GetQuantity(int id)
        {
            DataTable game = adapter.GetDataById(id);
            if (game.Rows.Count > 0)
            {
                return Convert.ToInt32(game.Rows[0]["Cantidad_Disponible"]);
            }
            return 0;
        }

        public void UpdateQuantity(int id, int change)
        {
            DataTable game = adapter.GetDataById(id);
            if (game.Rows.Count > 0)
            {
                int currentQuantity = Convert.ToInt32(game.Rows[0]["Cantidad_Disponible"]);
                int newQuantity = currentQuantity + change;

                if (newQuantity < 0)
                {
                    throw new Exception("No hay suficientes unidades en inventario.");
                }

                adapter.UpdateQuantity(newQuantity, id);
            }
        }

    }
}