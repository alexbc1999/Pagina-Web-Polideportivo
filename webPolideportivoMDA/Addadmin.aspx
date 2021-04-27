<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addadmin.aspx.cs" Inherits="webPolideportivoMDA.Addadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-center">
        <br />
    </p>
    <p class="text-center">
        <asp:Label ID="Label1" runat="server" Text="Escribe el usuario: "></asp:Label>
        <asp:TextBox ID="usuario" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="buscar" runat="server" Text="Buscar" OnClick="buscar_Click" />
    </p>
    <p class="text-left">
        &nbsp;</p>
    <p class="text-center">
        <asp:Label ID="Label2" runat="server" Text="Resultado búsqueda:" ></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="PolideportivoMDA" DataTextField="Username" DataValueField="Username">
        </asp:DropDownList>
        <asp:SqlDataSource ID="PolideportivoMDA" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [Username] FROM [Usuario] WHERE ([Username] LIKE '%' + @Username + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="usuario" Name="Username" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="departamento" placeholder="Escribe el departamento: " Enabled="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="crear" runat="server" Visible ="false" Text="Añadir admin" OnClick="crear_Click" />
    </p>
    <p class="text-left">
        &nbsp;</p>
    <p class="text-center">
        <asp:Label ID="error" runat="server" Text="" Font-Size="Medium" ForeColor="red"></asp:Label>
    </p>
    <p class="text-left">
        &nbsp;</p>
    <p class="text-center">
        <asp:Button ID="volver" runat="server" Text="Cancelar" OnClick="volver_Click" />
    </p>
</asp:Content>
