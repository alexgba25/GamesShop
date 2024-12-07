<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GamesShop.Views.Auth.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600&display=swap" rel="stylesheet"/>
    
    <title>Inicio de Sesión</title>
    <link href="../../Content/css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Iniciar Sesión</h2>
            <asp:TextBox ID="txtUser" CssClass="form-control" runat="server" placeholder="Nombre de usuario"></asp:TextBox>
            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
            <asp:Button ID="btnLogin" CssClass="btn btn-custom" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click"/>
        </div>
    </form>


</body>
</html>
