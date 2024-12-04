using System;
using System.Collections.Generic;
using System.Net.Mail;
using GamesShop.Models;

namespace GamesShop.Controllers
{
    public class MailController
    {
        private string _smtpServer = "smtp.office365.com"; // Cambiar según el proveedor de correo
        private int _smtpPort = 587;
        private string _fromEmail = "abahena@uninter.edu.mx";
        private string _fromPassword = "Agb252502";

        public void SendPurchaseConfirmation(string toEmail, List<Cart> cartItems)
        {
            if (string.IsNullOrEmpty(toEmail))
            {
                throw new ArgumentException("El correo destinatario no puede estar vacío.");
            }

            string subject = "Confirmación de Compra - GamesShop";
            string body = CreateEmailBody(cartItems);

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtp.Credentials = new System.Net.NetworkCredential(_fromEmail, _fromPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private string CreateEmailBody(List<Cart> cartItems)
        {
            string body = "Gracias por tu compra. Estos son los detalles de tu pedido:\n\n";
            decimal total = 0;

            foreach (var item in cartItems)
            {
                body += $"Nombre: {item.Nombre}, Cantidad: {item.Cantidad}, Precio Unitario: ${item.Precio}, Subtotal: ${item.Subtotal}\n";
                total += item.Subtotal;
            }

            body += $"\nTotal a pagar: ${total:F2}\n";
            body += "Gracias por tu compra en GamesShop.";
            return body;
        }
    }
}
