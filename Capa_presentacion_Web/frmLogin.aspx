<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="Capa_presentacion_Web.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ACCESO AL SISTEMA</title>
    <link rel="stylesheet" href="css/estilos.css"/>
</head>
<body>
    <div class="contenedor-form">
        <div > </div>
        <div class="formulario">
            <h2>Iniciar Sesión</h2>
            <form id="form1" runat="server">
                <asp:TextBox ID="txtusuario" placeholder="Usuario" runat="server" required></asp:TextBox>
                <asp:TextBox ID="txtpassword" placeholder="Password" runat="server" required></asp:TextBox>
                <asp:Button ID="btnValidar" runat="server" Text="Inicia sesión" onClick="btnValidar_Click"/>
            </form>
        </div>
    </div>
</body>
</html>
