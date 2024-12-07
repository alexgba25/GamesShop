using GamesShop.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamesShop.Views.Anonymous
{
    public partial class Cart : System.Web.UI.Page
    {
        private CartController _cartController = new CartController();
        private GamesController _gamesController = new GamesController();
        private MailController _mailController = new MailController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            var cartItems = _cartController.GetCart();
            GridViewCart.DataSource = cartItems;
            GridViewCart.DataBind();

            decimal total = 0;
            foreach (var item in cartItems)
            {
                total += item.Subtotal;
            }
            lblTotal.Text = total.ToString("F2");
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                Response.Write("<script>alert('Por favor ingresa un correo válido.');</script>");
                return;
            }

            var cartItems = _cartController.GetCart();
            if (cartItems.Count == 0)
            {
                Response.Write("<script>alert('El carrito está vacío.');</script>");
                return;
            }

            try
            {
                // Enviar correo con detalles de la compra
                _mailController.SendPurchaseConfirmation(email, cartItems);

                // Actualizar inventario
                foreach (var item in cartItems)
                {
                    _gamesController.UpdateQuantity(item.ID_Videojuego, -item.Cantidad); // Restar cantidad comprada
                }

                // Mostrar detalles de la compra
                GridViewPurchaseDetails.DataSource = cartItems;
                GridViewPurchaseDetails.DataBind();
                lblPurchaseTotal.Text = cartItems.Sum(item => item.Subtotal).ToString("C");
                purchaseDetails.Visible = true;

                // Vaciar carrito y refrescar vista
                _cartController.ClearCart();
                LoadCart();

                Response.Write("<script>alert('Pago realizado exitosamente. Revisa tu correo.');</script>");
                btnPay.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error al procesar el pago: {ex.Message}');</script>");
            }
        }

        protected void GridViewCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int idVideojuego = Convert.ToInt32(e.CommandArgument);

                // Eliminar el producto del carrito
                _cartController.RemoveFromCart(idVideojuego);

                // Recargar el carrito
                LoadCart();

                // Mostrar mensaje de confirmación
                Response.Write("<script>alert('Producto eliminado del carrito.');</script>");
            }
        }


        protected void btnBackToShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx");
        }

    }
}