<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actividades.aspx.cs" Inherits="webPolideportivoMDA.AdminActividades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <h1>Actividades&nbsp;
    </h1>
    <h3>Infórmate de las Actividades que más te gusten&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h3>
    <p>&nbsp; 
        
         <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
            <TodayDayStyle BackColor="#CCCC99" />
        </asp:Calendar>
         
    </p>
    <h3>
         
        <asp:Label ID="lbDepote" runat="server" Text="Deporte: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="-1">-- Elige Deporte --</asp:ListItem>
            <asp:ListItem>Futbol</asp:ListItem>
            <asp:ListItem>Baloncesto</asp:ListItem>
            <asp:ListItem>Tenis</asp:ListItem>
            <asp:ListItem>Padel</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbFecha" runat="server" Text="Fecha: "></asp:Label>
&nbsp;<asp:Label ID="lbFechaSelected" runat="server" Text="-- Seleccione del calendario --"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Imagen" runat="server" Height="127px" Width="198px" />
&nbsp;</h3>
    <h3><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ListaActividades" ForeColor="#333333" GridLines="None" Width="1060px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="Profesor" HeaderText="Profesor" SortExpression="Profesor" />
                <asp:BoundField DataField="MaxPersonas" HeaderText="MaxPersonas" SortExpression="MaxPersonas" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <EmptyDataTemplate>
                Busca Actividades seleccionando un Deporte y una Fecha que tengan actividades programadas
            </EmptyDataTemplate>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </h3>
    <p> <asp:Button ID="buReservar" runat="server" Height="57px" Text="Ir a Reservar" Width="209px" OnClick="buReservar_Click" Font-Bold="True" Font-Size="Large" />
        <asp:SqlDataSource ID="ListaActividades" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [Nombre], [Fecha], [Hora], [Descripcion], [Profesor], [MaxPersonas] FROM [Actividad] WHERE (([Nombre] = @Nombre) AND ([Fecha] = @Fecha)) ORDER BY [Hora]" OnSelecting="ListaActividades_Selecting">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Nombre" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="lbFechaSelected" Name="Fecha" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    
       
</asp:Content>
