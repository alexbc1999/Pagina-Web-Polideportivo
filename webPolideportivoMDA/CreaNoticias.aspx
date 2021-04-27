<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreaNoticias.aspx.cs" Inherits="webPolideportivoMDA.CreaNoticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-right: auto; margin-left: auto; text-align:center; ">
    <p>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" BorderStyle="None" Height="46px" TextMode="MultiLine" Visible="False" Width="449px" ForeColor="Red"></asp:TextBox>
    
    </p>
    <p>
        Señor Administrador, aqui tienes sus opciones:</p>
    <p>
        Título de la notícia:
        <asp:TextBox ID="Titulo" runat="server" Height="23px" Width="239px"></asp:TextBox>
    </p>
    <p>
        Descripción:<asp:TextBox ID="Descripcion" runat="server" Height="37px" Width="745px"></asp:TextBox>
    &nbsp;
    </p>
    <p>
        Autor:
        <asp:TextBox ID="Autor" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;
        <asp:Button ID="Anterior" runat="server" OnClick="Anterior_Click" Text="Página Anterior" />
&nbsp;&nbsp; <asp:Button ID="Crear" runat="server" OnClick="Button_Crear" OnClientClick="return confirm('¿Crear Notícia?');" Text="Crear" Width="107px" />
        &nbsp;&nbsp;
        <asp:Button ID="Actualizar" runat="server" OnClick="Button_Actualizar" OnClientClick="return confirm('¿Actualizar Notícia?');" Text="Actualizar" Width="107px" />
        &nbsp;&nbsp;
        <asp:Button ID="Leer" runat="server" OnClick="Button_Leer" OnClientClick="return confirm('¿Leer Notícia?');" Text="Leer Noticia" Width="107px" />
        &nbsp;
        <asp:Button ID="Borrar" runat="server" OnClick="Button_Borrar" OnClientClick="return confirm('¿Borrar Notícia?');" Text="Borrar" Width="107px" />
    </p>
        </div>
    </asp:Content>
