<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="webPolideportivoMDA.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registrar</title>

    <link href="Content/RegisterStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <img src="Imagenes/prueba2.jpg"  width="570" height="430" class ="panel" />
        </section>
        <div class ="sec2">
            <div class ="container">
                <div class ="content">
                    <h2>Formulario de registro</h2>
                    <asp:Label ID="Label1" runat="server" Text="Correo:"></asp:Label>
                    <asp:TextBox ID="correo" placeholder="introduzca su correo" MaxLength ="50" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                    <asp:TextBox ID="nombre" placeholder="introduzca su nombre" MaxLength ="32" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Label3" runat="server" Text="Apellidos:"></asp:Label>
                    <asp:TextBox ID="apellidos" placeholder="introduzca sus apellidos" MaxLength ="40" runat="server"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" Text="Edad:"></asp:Label>
                    <asp:TextBox ID="edad" placeholder="" TextMode="Number" runat ="server"></asp:TextBox><br />
                    <asp:Label ID="Label6" runat="server" Text="Usuario:"></asp:Label>
                    <asp:TextBox ID="username" placeholder="introduzca su nombre de usuario" MaxLength="20" runat="server"></asp:TextBox><br  />
                    <asp:Label ID="Label4" runat="server" Text="Contraseña:"></asp:Label>
                    <asp:TextBox ID="password" placeholder="Password" TextMode="Password" MaxLength="32" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Label5" runat="server" Text="Confirmar contraseña:"></asp:Label>
                    <asp:TextBox ID="Check_password" placeholder="Password" TextMode="Password" MaxLength="32" runat="server"></asp:TextBox><br />
                    <asp:LinkButton ID="LinkButton1" OnClick="log" runat="server">¿Dispones de una cuenta?</asp:LinkButton>
                    <asp:Button ID="Submit" runat="server"  Text="Acceder" OnClick="Submit_Click" /> <br /> <br />
                    <asp:Label ID="Label8" Style="padding-left: 1vw; padding-top: 20px;" Font-Size="Medium" ForeColor="red" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
