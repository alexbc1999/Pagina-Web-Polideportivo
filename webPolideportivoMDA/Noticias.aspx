<%@ Page Title="Noticias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="webPolideportivoMDA.About" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-right: auto; margin-left: auto; text-align:center; align-content:center; align-items:center; ">
    <h2> Bienvenido a las Notícias más recientes del PolideportivoMDA </h2>
    
    <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        
    </p>
    <p> Si desea leer alguna notícia en especial eliga uno de los Títulos:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="MostrarTitulos" DataTextField="Titulo" DataValueField="Titulo" Height="17px" Width="184px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True">
            <asp:ListItem Value="-1">-- Seleccione Título --</asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:SqlDataSource ID="MostrarTitulos" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [Titulo] FROM [Noticia]"></asp:SqlDataSource>
    </p>
        <div style="margin-right: auto; margin-left: auto; text-align:left; ">
    <p> 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Titulo" DataSourceID="ReadNoticia" ForeColor="#333333" GridLines="None" Height="16px" Width="1189px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" ReadOnly="True" SortExpression="Titulo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </p>
            </div>
    <p> 
        <asp:SqlDataSource ID="ReadNoticia" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT * FROM [Noticia] WHERE ([Titulo] = @Titulo)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Titulo" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p> 
        <asp:DataList ID="DataList1" runat="server" CellPadding="4" DataKeyField="Titulo" DataSourceID="SqlDataSource1" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" Width="1191px">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
            <ItemTemplate>
                Titulo:
                <asp:Label ID="TituloLabel" runat="server" Text='<%# Eval("Titulo") %>' />
                <br />
                Descripcion:
                <asp:Label ID="DescripcionLabel" runat="server" Text='<%# Eval("Descripcion") %>' />
                <br />
                Fecha:
                <asp:Label ID="FechaLabel" runat="server" Text='<%# Eval("Fecha") %>' />
                <br />
                Autor:
                <asp:Label ID="AutorLabel" runat="server" Text='<%# Eval("Autor") %>' />
                <br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT * FROM [Noticia]"></asp:SqlDataSource>
    </p>
    </div>
</asp:Content>
