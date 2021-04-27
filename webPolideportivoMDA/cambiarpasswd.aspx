<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cambiarpasswd.aspx.cs" Inherits="webPolideportivoMDA.cambiarpasswd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/password.css" rel="stylesheet" />

    <div class ="pass">
        <p style="margin-left: 80px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a>Contraseña actual: </a>
        <asp:TextBox ID="actual" TextMode ="Password" runat="server"></asp:TextBox><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a>Nueva contraseña:</a>&nbsp; 
        <asp:TextBox ID="new1" TextMode ="Password" runat="server"></asp:TextBox><br />
        <a>Confirme la nueva contraseña: </a> 
        <asp:TextBox ID="new2" TextMode ="Password" runat="server"></asp:TextBox><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="volver" runat="server" Text="Cancelar" style="width: 85px" OnClick="volver_Click"  />
        <asp:Button ID="cambiar" runat="server" Text="Cambiar Contraseña" OnClick="cambiar_Click" /><br />
            <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="red" Visible="false"> </asp:Label>
        </p>
    </div>

</asp:Content>
