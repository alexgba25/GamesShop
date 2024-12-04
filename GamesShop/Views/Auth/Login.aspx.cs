using GamesShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamesShop.Views.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        UsersController _controller = new UsersController();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si ya está logueado
            if (Session["username"] != null)
            {
                // Si está logueado, redirigir a la página de juegos
                Response.Redirect("~/Views/Admin/Games.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;

            // Agregar validación de base de datos
            if (_controller.Login(username, password))
            {
                // Guardar el nombre de usuario en la sesión
                Session["username"] = username; // Puedes almacenar más información si es necesario

                // Redirigir a la página de juegos
                Response.Redirect("~/Views/Admin/Games.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            }
        }
    }
}