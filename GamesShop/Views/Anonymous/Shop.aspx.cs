using GamesShop.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamesShop.Views.Anonymous
{
    public partial class Shop : System.Web.UI.Page
    {
        private readonly GamesController _gamesController = new GamesController();
        private readonly CartController _cartController = new CartController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGames();
            }

           
        }

        private void LoadGames()
        {
            DataTable games = _gamesController.GetAllGames();
            GridViewShop.DataSource = games;
            GridViewShop.DataBind();
        }

        protected void GridViewShop_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int gameId = Convert.ToInt32(e.CommandArgument);
                AddGameToCart(gameId);
            }
        }

        private void AddGameToCart(int gameId)
        {
            DataTable games = _gamesController.GetAllGames();
            DataRow gameRow = games.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID_Videojuego") == gameId);

            if (gameRow != null)
            {
                var cartItem = new GamesShop.Models.Cart
                {
                    ID_Videojuego = gameRow.Field<int>("ID_Videojuego"),
                    Nombre = gameRow.Field<string>("Nombre"),
                    Precio = gameRow.Field<decimal>("Precio"),
                    Cantidad = 1 // Agregar uno al carrito
                };

                // Verificar si hay suficiente cantidad disponible
                int cantidadDisponible = gameRow.Field<int>("Cantidad_Disponible");
                if (cartItem.Cantidad <= cantidadDisponible)
                {
                    _cartController.AddToCart(cartItem);
                    Response.Write("<script>alert('Producto agregado al carrito.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Cantidad insuficiente en inventario.');</script>");

                }
            }
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}