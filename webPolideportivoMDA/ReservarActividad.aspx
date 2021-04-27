<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReservarActividad.aspx.cs" Inherits="webPolideportivoMDA.ReservarActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Reserva de Actividades&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </h1>
    <h3>
    <asp:Label ID="lb1" runat="server" Text="Correo del Usuario: "></asp:Label>
    <asp:Label ID="lbCorreo" runat="server" Text="-- Aqui va el correo --" Font-Bold="True" Font-Italic="True"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" >Mis Reservas</asp:LinkButton>
    </h3>
    <p>
        &nbsp;</p>
    <asp:Calendar ID="Calendar1" runat="server" Height="200px" Width="365px" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="FullMonth">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
    </asp:Calendar>
    <h3>
        <asp:Label ID="lbDeporte" runat="server" Text="Deporte: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="-1">-- Seleccione Deporte --</asp:ListItem>
            <asp:ListItem>Futbol</asp:ListItem>
            <asp:ListItem>Baloncesto</asp:ListItem>
            <asp:ListItem>Tenis</asp:ListItem>
            <asp:ListItem>Padel</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbFecha" runat="server" Text="Fecha: "></asp:Label>
        <asp:Label ID="lbFechaSeleccionada" runat="server" Text="-- Seleccione del calendario --"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Imagen" runat="server" Height="101px" Width="191px" />
&nbsp;<asp:SqlDataSource ID="ListaHoras" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [Hora] FROM [Actividad] WHERE (([Fecha] = @Fecha) AND ([Nombre] = @Nombre))">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbFechaSeleccionada" Name="Fecha" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" Name="Nombre" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </h3>
    <h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ListaActividades" ForeColor="#333333" GridLines="None" Width="949px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="MaxPersonas" HeaderText="MaxPersonas" SortExpression="MaxPersonas" />
                <asp:BoundField DataField="Profesor" HeaderText="Profesor" SortExpression="Profesor" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <EmptyDataTemplate>
                Seleccione un Deporte y una Fecha con actividades programadas
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
        <asp:SqlDataSource ID="ListaActividades" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [Nombre], [Descripcion], [MaxPersonas], [Profesor], [Fecha], [Hora] FROM [Actividad] WHERE (([Fecha] = @Fecha) AND ([Nombre] = @Nombre)) ORDER BY [Hora]">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbFechaSeleccionada" Name="Fecha" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" Name="Nombre" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
            
    
        &nbsp;
         
    </h3> 

    <p>
        <asp:Label ID="lbSalida" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Black"></asp:Label>

    </p>
    <p>

        

        <asp:Button ID="buReservar" runat="server" Text="Reservar" Height="59px" OnClick="buReservar_Click" Width="188px" Visible="False" BackColor="White" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Black" />
    </p> 
    <h3><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">&lt;-- Anterior</asp:LinkButton></h3>
       
</asp:Content>
