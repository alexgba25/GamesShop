<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="GamesShop.Views.Admin.Games" MasterPageFile="~/Views/MasterPage/Layout.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
         <form id="form1" runat="server" class="container mt-4">
        <h1 class="mb-4">Administrar Videojuegos</h1>

        <%-- GridView para listar videojuegos --%>
        <div class="card shadow mt-4 bg-dark">
            <div class="card-header bg-success text-white">
                <h5 class="card-title mb-0 ">Gestión de Videojuegos</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_Videojuego"
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                    CssClass="table table-dark table-hover text-center">
                    <Columns>
                        <asp:BoundField DataField="ID_Videojuego" HeaderText="ID" ReadOnly="True" />

                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control bg-dark text-white"
                                    Text='<%# Bind("Nombre") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Plataforma">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPlataforma" runat="server" CssClass="form-control bg-dark text-white"
                                    Text='<%# Bind("Plataforma") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPlataforma" runat="server" Text='<%# Bind("Plataforma") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Desarrollador">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDesarrollador" runat="server" CssClass="form-control bg-dark text-white"
                                    Text='<%# Bind("Desarrollador") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDesarrollador" runat="server" Text='<%# Bind("Desarrollador") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Precio">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control bg-dark text-white"
                                    Text='<%# Bind("Precio") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPrecio" runat="server" Text='<%# Bind("Precio") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Clasificación">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtClasificacion" runat="server" CssClass="form-control bg-dark text-white"
                                    Text='<%# Bind("Clasificación") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblClasificacion" runat="server" Text='<%# Bind("Clasificación") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Género">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGenero" runat="server" CssClass="form-control bg-dark text-white"
                                    Text='<%# Bind("Género") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGenero" runat="server" Text='<%# Bind("Género") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cantidad Disponible">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCantidadDisponible" runat="server" CssClass="form-control bg-dark text-white"
                                    Text='<%# Bind("Cantidad_Disponible") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCantidadDisponible" runat="server"
                                    Text='<%# Bind("Cantidad_Disponible") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--   Botones de acción --%>
                        <asp:CommandField ShowEditButton="True" EditText="Editar" UpdateText="Guardar"
                            CancelText="Cancelar" ShowDeleteButton="True" DeleteText="Eliminar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <br />
        <hr />
     <%-- Formulario para agregar nuevos videojuegos --%>
<div class="card shadow mt-4 bg-dark">
            <div class="card-header bg-success text-white">
        <h5>Agregar Nuevo Videojuego</h5>
    </div>
    <div class="card-body">
        <div class="row g-3">
          <div class="col-md-4">
                <label for="txtName" class="form-label text-white">Nombre</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control bg-dark text-white"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="txtPlatform" class="form-label text-white">Plataforma</label>
                <asp:TextBox ID="txtPlatform" runat="server" CssClass="form-control bg-dark text-white"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="txtDeveloper" class="form-label text-white">Desarrollador</label>
                <asp:TextBox ID="txtDeveloper" runat="server" CssClass="form-control bg-dark text-white"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="txtPrice" class="form-label text-white">Precio</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control bg-dark text-white"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="txtRating" class="form-label text-white">Rating</label>
                <asp:TextBox ID="txtRating" runat="server" CssClass="form-control bg-dark text-white"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="txtGenre" class="form-label text-white">Género</label>
                <asp:TextBox ID="txtGenre" runat="server" CssClass="form-control bg-dark text-white"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="txtQuantity" class="form-label text-white">Cantidad</label>
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control bg-dark text-white"></asp:TextBox>
            </div>
            <div class="col-md-4">
                   <label for="btnAdd" class="form-label text-white"></label>
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success w-100" Text="Agregar" OnClick="btnAdd_Click" />
          
            </div>
              <div class="col-md-4">
                   <label for="btnClear" class="form-label text-white"></label>
                 <asp:Button ID="btnClear" runat="server" CssClass="btn btn-secondary w-100" Text="Limpiar Campos" OnClick="btnClear_Click" />
            </div>
             
                
            
        </div>
    </div>
</div>

   


    </form>
</asp:Content>
