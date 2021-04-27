<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreaPistas.aspx.cs" Inherits="webPolideportivoMDA.CreaPistas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-right: auto; margin-left: auto; text-align:center; ">
    <p>
        <br />
        <asp:TextBox ID="Resultados" runat="server" AutoPostBack="True" BorderStyle="None" ForeColor="Red" Visible="False" Width="625px" Height="54px" TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <span style="color: rgb(51, 51, 51); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Señor Administrador, aqui tienes sus opciones:</span></p>
    <p>

        Numero de la pista:<asp:TextBox ID="numpista" onkeypress="return justNumbers(event);" runat="server"></asp:TextBox>
    &nbsp;(sólo números)</p>
    <p>

        Deporte:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="deppista" runat="server" AppendDataBoundItems="True" Height="17px" Width="183px">
            <asp:ListItem Value="-1">-- Seleccione Deporte --</asp:ListItem>
            <asp:ListItem>Tenis</asp:ListItem>
            <asp:ListItem>Futbol</asp:ListItem>
            <asp:ListItem>Baloncesto</asp:ListItem>
            <asp:ListItem>Padel</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>

        Descripcion:<asp:TextBox ID="descpista" runat="server"></asp:TextBox>
    </p>
    <p>

        Cubierta?:&nbsp;
        <asp:DropDownList ID="cubpista" runat="server" AppendDataBoundItems="True" Height="16px" Width="136px">
            <asp:ListItem Value="-1">-- Seleccione --</asp:ListItem>
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>

        <script type="text/javascript">
            function justNumbers(e) {
                var keynum = window.event ? window.event.keyCode : e.which;
                if ((keynum == 8 || keynum == 48))
                    return true;
                if (keynum <= 47 || keynum >= 58) return false;
                return /\d/.test(String.fromCharCode(keynum));
            }
        </script>

        <asp:Button ID="Anterior" runat="server" OnClick="Anterior_Click" Text="Página Anterior" />
&nbsp;

        <asp:Button ID="Crear" runat="server" OnClick="Crear_Click" Text="Crear" />
        &nbsp;
        <asp:Button ID="Actualizar" runat="server" Text="Actualizar" OnClick="Actualizar_Click" />
    &nbsp;
        <asp:Button ID="Leer" runat="server" Text="Leer Pista" OnClick="Leer_Click" />
        &nbsp;
        <asp:Button ID="Borrar" runat="server" Text="Borrar" OnClick="Borrar_Click" />
        </p>
        </div>
</asp:Content>
