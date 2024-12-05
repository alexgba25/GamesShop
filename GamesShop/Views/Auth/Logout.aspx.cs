using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamesShop.Views.Auth
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Terminar la sesión
            Session.Abandon();

            // Redirigir al login
            Response.Redirect("~/Views/Anonymous/Shop.aspx");
        }
    }
}