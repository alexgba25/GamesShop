<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GamesShop.Views.Auth.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro</title>
    <link href="Content/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <h2>Registro</h2>
            <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" placeholder="Nombre de usuario"></asp:TextBox>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Correo Electrónico"></asp:TextBox>
            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
            <asp:Button ID="btnRegister" CssClass="btn btn-custom" runat="server" Text="Registrarse" OnClick="btnRegister_Click" />
        </div>
    </form>
</body>
</html>