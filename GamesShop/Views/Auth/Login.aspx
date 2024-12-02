<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GamesShop.Views.Auth.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <title>Inicio de Sesión</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: linear-gradient(135deg, #6e8efb, #a777e3);
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            font-family: 'Arial', sans-serif;
        }

        .login-container {
            background: #fff;
            padding: 40px;
            border-radius: 20px;
            box-shadow: 0 12px 30px rgba(0, 0, 0, 0.2);
            width: 100%;
            max-width: 400px;
            text-align: center;
            animation: fadeIn 1.2s ease-in-out;
            border: 2px solid #6e8efb; /* Bordes para más estilo */
        }

        @keyframes fadeIn {
            from {
                opacity: 0;
                transform: scale(0.8);
            }
            to {
                opacity: 1;
                transform: scale(1);
            }
        }

        .login-container h2 {
            color: #6e8efb;
            font-weight: bold;
            margin-bottom: 20px;
            text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.2); /* Sombra para el título */
        }

        .form-control {
            margin-bottom: 15px;
            border: 2px solid #6e8efb; /* Bordes de entrada */
            border-radius: 10px;
            padding: 10px;
            transition: border-color 0.3s;
        }

        .form-control:focus {
            border-color: #a777e3; /* Color al enfocar */
            outline: none;
        }

        .btn-custom {
            background-color: #6e8efb;
            border: none;
            color: white;
            padding: 12px 20px; /* Mayor padding */
            border-radius: 50px;
            width: 100%;
            font-weight: bold; /* Texto más grueso */
            transition: background-color 0.3s, transform 0.3s; /* Transiciones mejoradas */
        }

        .btn-custom:hover {
            background-color: #a777e3;
            transform: translateY(-2px); /* Efecto de elevar el botón al pasar el ratón */
        }

        .footer-text {
            margin-top: 15px;
            color: #999;
            font-size: 0.9em; /* Ajuste de tamaño de texto */
        }
    </style>
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

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.7/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
