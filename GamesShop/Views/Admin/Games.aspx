<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="GamesShop.Views.Admin.Games" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Administrar Videojuegos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <h1 class="mb-4">Administrar Videojuegos</h1>

        <%-- GridView para listar videojuegos --%>
        <div class="card mt-4">
            <div class="card-header bg-primary text-white">
                <h5 class="card-title mb-0">Gestión de Videojuegos</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_Videojuego"
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                    CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="ID_Videojuego" HeaderText="ID" ReadOnly="True" />

                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"
                                    Text='<%# Bind("Nombre") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Plataforma">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPlataforma" runat="server" CssClass="form-control"
                                    Text='<%# Bind("Plataforma") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPlataforma" runat="server" Text='<%# Bind("Plataforma") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Desarrollador">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDesarrollador" runat="server" CssClass="form-control"
                                    Text='<%# Bind("Desarrollador") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDesarrollador" runat="server" Text='<%# Bind("Desarrollador") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Precio">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"
                                    Text='<%# Bind("Precio") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPrecio" runat="server" Text='<%# Bind("Precio") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Clasificación">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtClasificacion" runat="server" CssClass="form-control"
                                    Text='<%# Bind("Clasificación") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblClasificacion" runat="server" Text='<%# Bind("Clasificación") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Género">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGenero" runat="server" CssClass="form-control"
                                    Text='<%# Bind("Género") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGenero" runat="server" Text='<%# Bind("Género") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cantidad Disponible">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCantidadDisponible" runat="server" CssClass="form-control"
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
<div class="card mt-4">
    <div class="card-header">
        <h2>Agregar Nuevo Videojuego</h2>
    </div>
    <div class="card-body">
        <div class="row g-3">
            <div class="col-md-4">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Nombre"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPlatform" runat="server" CssClass="form-control" Placeholder="Plataforma"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtDeveloper" runat="server" CssClass="form-control" Placeholder="Desarrollador"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" Placeholder="Precio"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtRating" runat="server" CssClass="form-control" Placeholder="Rating"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtGenre" runat="server" CssClass="form-control" Placeholder="Género"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" Placeholder="Cantidad"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAdd_Click" />
                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-secondary" Text="Limpiar Campos" OnClick="btnClear_Click" />
            </div>
             
                
            
        </div>
    </div>
</div>

   


    </form>
</body>
</html>
