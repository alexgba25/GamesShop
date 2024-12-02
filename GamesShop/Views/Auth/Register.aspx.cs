using GamesShop.Controllers;
using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamesShop.Views.Auth
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        UsersController _controller = new UsersController();

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Por favor, complete todos los campos.');</script>");
                return;
            }

            // Crear instancia de usuario
            var user = new User
            {
                nombre_usuario = userName,
                correo_electronico = email,
                contrasena = password,
                fecha_creacion = DateTime.Now
            };

            // Registrar usuario en la base de datos
            if (_controller.Register(user))
            {
                Response.Write("<script>alert('Registro exitoso. Redirigiendo al login.');</script>");
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Write("<script>alert('Error al registrar el usuario.');</script>");
            }
        }
    }
}