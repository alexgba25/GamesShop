using GamesShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamesShop.Views.Admin
{
    public partial class Games : System.Web.UI.Page
    {
        private GamesController _GameController = new GamesController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= GridView1.Rows.Count)
                {
                    throw new ArgumentOutOfRangeException("RowIndex fuera del rango.");
                }

                int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                TextBox txtNombre = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNombre");
                TextBox txtPlataforma = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPlataforma");
                TextBox txtDesarrollador = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDesarrollador");
                TextBox txtPrecio = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPrecio");
                TextBox txtClasificacion = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtClasificacion");
                TextBox txtGenero = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGenero");
                TextBox txtCantidadDisponible = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCantidadDisponible");

                if (txtNombre == null || txtPlataforma == null || txtDesarrollador == null ||
                    txtPrecio == null || txtClasificacion == null || txtGenero == null || txtCantidadDisponible == null)
                {
                    throw new Exception("No se encontraron los controles en la fila editada.");
                }

                string nombre = txtNombre.Text;
                string plataforma = txtPlataforma.Text;
                string desarrollador = txtDesarrollador.Text;

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    throw new Exception("El precio debe ser un valor numérico válido.");
                }

                string clasificacion = txtClasificacion.Text;
                string genero = txtGenero.Text;

                if (!int.TryParse(txtCantidadDisponible.Text, out int cantidadDisponible))
                {
                    throw new Exception("La cantidad debe ser un número entero válido.");
                }

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(plataforma) || string.IsNullOrEmpty(desarrollador))
                {
                    throw new Exception("El nombre, plataforma y desarrollador no pueden estar vacíos.");
                }

                _GameController.UpdateGame(id, nombre, plataforma, desarrollador, precio, clasificacion, genero, cantidadDisponible);

                GridView1.EditIndex = -1;
                LoadData();
                ShowAlert("Videojuego actualizado con éxito.", "success");
            }
            catch (Exception ex)
            {
                ShowAlert("Error al actualizar el videojuego: " + ex.Message, "error");
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                _GameController.DeleteGame(id);
                LoadData();
                ShowAlert("Videojuego eliminado con éxito.", "success");
            }
            catch (Exception ex)
            {
                ShowAlert("Error al eliminar el videojuego: " + ex.Message, "error");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string platform = txtPlatform.Text;
                string developer = txtDeveloper.Text;
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    throw new Exception("El precio debe ser un valor numérico.");
                }
                string rating = txtRating.Text;
                string genre = txtGenre.Text;
                if (!int.TryParse(txtQuantity.Text, out int quantity))
                {
                    throw new Exception("La cantidad debe ser un número entero.");
                }

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(platform) || string.IsNullOrEmpty(developer))
                {
                    throw new Exception("El nombre, plataforma y desarrollador no pueden estar vacíos.");
                }

                _GameController.AddGame(name, platform, developer, price, rating, genre, quantity);

                txtName.Text = string.Empty;
                txtPlatform.Text = string.Empty;
                txtDeveloper.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtRating.Text = string.Empty;
                txtGenre.Text = string.Empty;
                txtQuantity.Text = string.Empty;

                LoadData();
                ShowAlert("Videojuego agregado con éxito.", "success");
            }
            catch (Exception ex)
            {
                ShowAlert("Error al agregar el videojuego: " + ex.Message, "error");
            }
        }

        private void LoadData()
        {
            GridView1.DataSource = _GameController.GetAllGames();
            GridView1.DataBind();
        }

        private void ShowAlert(string message, string type)
        {
            string script = $"alert('{message}');";
            if (type == "error")
            {
                script = $"alert('¡Error! {message}');";
            }

            // Mostrar el mensaje de alerta
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, true);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            // Limpiar los campos del formulario
            txtName.Text = string.Empty;
            txtPlatform.Text = string.Empty;
            txtDeveloper.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtRating.Text = string.Empty;
            txtGenre.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }

    }
}