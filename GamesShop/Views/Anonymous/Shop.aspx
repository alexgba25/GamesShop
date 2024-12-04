<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="GamesShop.Views.Anonymous.Shop" MasterPageFile="~/Views/MasterPage/Layout.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Shop</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
        <form id="form1" runat="server" class="container mt-4">
            <h1 class="mb-4">Tienda de Videojuegos</h1>
            <asp:GridView ID="GridViewShop" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
                OnRowCommand="GridViewShop_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID_Videojuego" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Plataforma" HeaderText="Plataforma" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Cantidad_Disponible" HeaderText="Cantidad Disponible" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAddToCart" runat="server" CommandName="AddToCart" Text="Agregar al Carrito"
                                CommandArgument='<%# Eval("ID_Videojuego") %>' CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnViewCart" runat="server" CssClass="btn btn-secondary mt-4" Text="Ver Carrito" OnClick="btnViewCart_Click" />
        </form>
</asp:Content>
