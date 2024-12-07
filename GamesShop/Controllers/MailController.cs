using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using GamesShop.Interfaces;
using GamesShop.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GamesShop.Controllers
{
    public class MailController : IMailController
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

            // Generar PDF con detalles de la compra
            byte[] pdfBytes = GeneratePurchasePdf(cartItems);

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                // Adjuntar el PDF
                mail.Attachments.Add(new Attachment(new MemoryStream(pdfBytes), "DetalleCompra.pdf"));

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
                body += $"Nombre: {item.Nombre}\nCantidad: {item.Cantidad}\nPrecio Unitario: ${item.Precio}\nSubtotal: ${item.Subtotal}\n\n";
                total += item.Subtotal;
            }

            body += $"\nTotal a pagar: ${total:F2}\n";
            body += "Gracias por tu compra en GamesShop.";
            return body;
        }

        private byte[] GeneratePurchasePdf(List<Cart> cartItems)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(document, stream);
                document.Open();

                // Título
                var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                document.Add(new Paragraph("Confirmación de Compra - GamesShop", titleFont));
                document.Add(new Paragraph("\n"));

                // Tabla
                PdfPTable table = new PdfPTable(4) { WidthPercentage = 100 };
                table.AddCell("Nombre");
                table.AddCell("Cantidad");
                table.AddCell("Precio Unitario");
                table.AddCell("Subtotal");

                decimal total = 0;
                foreach (var item in cartItems)
                {
                    table.AddCell(item.Nombre);
                    table.AddCell(item.Cantidad.ToString());
                    table.AddCell($"${item.Precio:F2}");
                    table.AddCell($"${item.Subtotal:F2}");
                    total += item.Subtotal;
                }

                // Total
                PdfPCell totalCell = new PdfPCell(new Phrase($"Total: ${total:F2}"))
                {
                    Colspan = 4,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                table.AddCell(totalCell);

                document.Add(table);
                document.Close();

                return stream.ToArray();
            }
        }
    }
}
