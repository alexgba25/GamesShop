<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="GamesShop.Views.Anonymous.Cart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrito</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <h1 class="mb-4">Carrito de Compras</h1>
        <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="ID_Videojuego" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
         <%-- Mostrar Total --%>
        <div class="mt-4">
            <h3>Total: $<asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label></h3>
        </div>

        <%-- Formulario para el pago --%>
        <div class="mt-4">
            <h3>Realizar Pago</h3>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" Placeholder="Correo Electrónico"></asp:TextBox>
            <asp:Button ID="btnPay" runat="server" CssClass="btn btn-success" Text="Pagar" OnClick="btnPay_Click" />
            <asp:Button ID="btnBackToShop" runat="server" Text="Regresar a la tienda" CssClass="btn btn-secondary" OnClick="btnBackToShop_Click" />

        </div>

        <div id="purchaseDetails" runat="server" visible="false">
    <h3>Detalles de la Compra</h3>
    <asp:GridView ID="GridViewPurchaseDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Juego" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>
    <p><strong>Total: </strong><asp:Label ID="lblPurchaseTotal" runat="server"></asp:Label></p>
</div>

    </form>
</body>
</html>
