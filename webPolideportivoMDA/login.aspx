<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="webPolideportivoMDA.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>

    <link href="Content/logstyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <section >
            <img src="Imagenes/prueba2.jpg" width="500" height="450" class ="panel" />
        </section>
        <div class="sec2">
            <div class="container">
                <div class="social">
                    <a href="https://www.facebook.com">
                        <asp:Image ID="Image1" runat="server" width ="40" Height="40" ImageUrl="~/Content/facebook.png" /></a>
                    <a href="https://plus.google.com">
                        <asp:Image ID="Image2" runat="server" width ="40" Height="40" ImageUrl="~/Content/googlelogo.png" /></a>
                </div>
 
                <div class="content">
                    <h2>Inicia Sesión</h2>
                    <asp:TextBox ID="usuario" placeholder="Username" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="password" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox><br />
                    <asp:LinkButton ID="LinkButton1" style="margin-left:100px;" runat="server" Font-Size="Small" OnClick="LinkButton1_Click">Recupera tu contraseña</asp:LinkButton><br />
                    <asp:Button ID="Acceder" runat="server"  Text="Acceder" OnClick="Submit_Click" /> <br /> <br />
                    <asp:LinkButton ID="Registrarse" style="margin-left:60px;"  Font-Size="Small" runat="server" OnClick="Registrarse_Click">¿No dispone de una cuenta?</asp:LinkButton><br /> <br />
                    <asp:Label ID="Label1" Style="padding-left: 4vw; padding-top: 2vw;" Font-Size="Medium" ForeColor="red" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
