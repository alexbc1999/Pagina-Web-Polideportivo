<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recuperarpasswd.aspx.cs" Inherits="webPolideportivoMDA.recuperarpasswd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p class="text-center">
        <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Para recuperar su contraseña introduzca sus datos:"></asp:Label>
    </p>
    <p class="text-center">
        <asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="username" runat="server"></asp:TextBox>
    </p>
    <p class="text-center">
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
    </p>
    <p class="text-center">
&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Apellidos:"></asp:Label>
        <asp:TextBox ID="apellidos" runat="server"></asp:TextBox>
    </p>
    <p class="text-center">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Edad:"></asp:Label>
        <asp:TextBox ID="edad" runat="server" MaxLength="3" TextMode="Number"></asp:TextBox>
    </p>
    <p class="text-center">
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Nueva contraseña:"></asp:Label>
        <asp:TextBox ID="passwd" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p class="text-center">
        <asp:Label ID="Label7" runat="server" Text="Confirme contraseña:"></asp:Label>
        <asp:TextBox ID="confirmpasswd" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p class="text-center">
        &nbsp;</p>
    <p class="text-center">
        <asp:TextBox ID="error" runat="server" Height="57px" ReadOnly="True" Width="190px" Visible="False" TextMode="MultiLine" ForeColor="Red"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        </p>
    <p class="text-center">
        &nbsp;</p>
    <p class="text-center">
        <asp:Button ID="volver" runat="server" Text="Volver" OnClick="volver_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="confirmar" runat="server" Text="Confirmar" OnClick="confirmar_Click" />
    </p>
</asp:Content>
