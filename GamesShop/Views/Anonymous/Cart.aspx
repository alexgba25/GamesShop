<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="GamesShop.Views.Anonymous.Cart"  MasterPageFile="~/Views/MasterPage/Layout.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Carrito</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
          <form id="form1" runat="server" class="container mt-4">
        <h1 class="mb-4">Carrito de Compras</h1>
  <!-- Tabla de productos en el carrito -->
        <div class="card bg-dark shadow mt-4">
            <div class="card-header bg-success text-white">
                <h5 class="mb-0">Productos en tu Carrito</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped table-bordered"
                    OnRowCommand="GridViewCart_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ID_Videojuego" HeaderText="ID" HeaderStyle-CssClass="text-white" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="text-white" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" HeaderStyle-CssClass="text-white" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="text-white" />
                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" HeaderStyle-CssClass="text-white" />
                        <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="text-white">
                            <ItemTemplate>
                                <asp:Button ID="btnRemove" runat="server" CommandName="Remove" Text="Eliminar" 
                                    CommandArgument='<%# Eval("ID_Videojuego") %>' CssClass="btn btn-danger btn-sm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- Mostrar Total -->
        <div class="mt-4">
            <h3 class="text-white">Total: $<asp:Label ID="lblTotal" runat="server" Text="0.00" CssClass="text-white"></asp:Label></h3>
        </div>
              <br />
              <hr />
        <!-- Formulario para realizar el pago -->
        <div class="mt-4">
            <h3 class="text-white"><b>Realizar Pago</b></h3>
            <label for="txtEmail" class="form-label text-white">Ingresa tu Correo Electrónico:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control bg-dark text-white" Placeholder="Correo Electrónico"></asp:TextBox><br />
            <asp:Button ID="btnPay" runat="server" CssClass="btn btn-success w-100" Text="Pagar" OnClick="btnPay_Click" />
            <asp:Button ID="btnBackToShop" runat="server" Text="Regresar a la tienda" CssClass="btn btn-secondary w-100 mt-2" OnClick="btnBackToShop_Click" />
        </div>
              <br />
              <br />
        <!-- Detalles de la compra -->
        <div id="purchaseDetails" runat="server" visible="false">
            <h3 class="text-white"><b>Detalles de la Compra</b></h3>
            <asp:GridView ID="GridViewPurchaseDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-dark table-bordered">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Juego" HeaderStyle-CssClass="text-white" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="text-white" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" HeaderStyle-CssClass="text-white" />
                    <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" HeaderStyle-CssClass="text-white" />
                </Columns>
            </asp:GridView>
            <p class="text-white"><strong>Total: </strong><asp:Label ID="lblPurchaseTotal" runat="server" CssClass="text-white"></asp:Label></p>
        </div>

    </form>
</asp:Content>