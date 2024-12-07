<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="GamesShop.Views.Anonymous.Shop" MasterPageFile="~/Views/MasterPage/Layout.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Shop</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
        <form id="form1" runat="server" class="container mt-4">
            <h1 class="mb-4">Tienda de Videojuegos</h1>
          <!-- Tabla para mostrar los videojuegos -->
        <div class="card bg-dark shadow mt-4">
            <div class="card-header bg-success text-white">
                <h5 class="mb-0">Catálogo de Videojuegos</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridViewShop" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-dark table-striped table-bordered"
                    OnRowCommand="GridViewShop_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ID_Videojuego" HeaderText="ID" HeaderStyle-CssClass="text-white" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="text-white" />
                        <asp:BoundField DataField="Plataforma" HeaderText="Plataforma" HeaderStyle-CssClass="text-white" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" HeaderStyle-CssClass="text-white" />
                        <asp:BoundField DataField="Cantidad_Disponible" HeaderText="Cantidad Disponible" HeaderStyle-CssClass="text-white" />
                        <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="text-white">
                            <ItemTemplate>
                                <asp:Button ID="btnAddToCart" runat="server" CommandName="AddToCart" Text="Agregar al Carrito"
                                    CommandArgument='<%# Eval("ID_Videojuego") %>' CssClass="btn btn-success w-100" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
        <!-- Botón para ver el carrito -->
        <asp:Button ID="btnViewCart" runat="server" CssClass="btn btn-secondary mt-4" Text="Ver Carrito" OnClick="btnViewCart_Click" />
    </form>
</asp:Content>