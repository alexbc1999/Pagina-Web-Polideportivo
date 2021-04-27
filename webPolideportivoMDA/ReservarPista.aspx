<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReservarPista.aspx.cs" Inherits="webPolideportivoMDA.ReservarPista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-right: auto; margin-left: auto; text-align:center; ">
    <p>
        &nbsp;</p>
    <p>
        <br />
        Hora:&nbsp; <asp:DropDownList ID="ListaHoras" runat="server" AppendDataBoundItems="True" Height="22px" Width="206px">
            <asp:ListItem Value="-1">-- Seleccione una hora --</asp:ListItem>
            <asp:ListItem>10:00</asp:ListItem>
            <asp:ListItem>11:00</asp:ListItem>
            <asp:ListItem>12:00</asp:ListItem>
            <asp:ListItem>13:00</asp:ListItem>
            <asp:ListItem>16:00</asp:ListItem>
            <asp:ListItem>17:00</asp:ListItem>
            <asp:ListItem>18:00</asp:ListItem>
            <asp:ListItem>19:00</asp:ListItem>
            <asp:ListItem>20:00</asp:ListItem>
            <asp:ListItem>21:00</asp:ListItem>
            <asp:ListItem>22:00</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Deporte:
        <asp:DropDownList ID="ListaDeportes" runat="server" AppendDataBoundItems="True" AutoPostBack="True" Height="21px" Width="192px">
            <asp:ListItem Value="-1">-- Seleccione Deporte --</asp:ListItem>
            <asp:ListItem>Tenis</asp:ListItem>
            <asp:ListItem>Futbol</asp:ListItem>
            <asp:ListItem>Baloncesto</asp:ListItem>
            <asp:ListItem>Padel</asp:ListItem>
        </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tus reservas:
        <asp:DropDownList ID="Reservado" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SelectNumeroPista" DataTextField="Numero" DataValueField="Numero" Height="16px" Width="164px">
            <asp:ListItem Value="-1">-- Seleccione Numero --</asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:SqlDataSource ID="SelectNumeroPista" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [Numero] FROM [ReservaPista] WHERE ([Correo] = @Correo)">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="Correo" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
        <p>
        Correo: 
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False" ReadOnly="True" Width="154px"></asp:TextBox>
&nbsp;<asp:SqlDataSource ID="SelectCorreo" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [Correo] FROM [Usuario] WHERE ([Username] = @Username)">
            <SelectParameters>
                <asp:SessionParameter Name="Username" SessionField="ID" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>
&nbsp;&nbsp; NumeroPista:
        <asp:DropDownList ID="ListaPistas" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="NumeroPista" DataTextField="NumeroPista" DataValueField="NumeroPista" Height="20px" Width="164px">
            <asp:ListItem Value="-1">-- Seleccione Pista --</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="NumeroPista" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [NumeroPista] FROM [Pista] WHERE ([Deporte] = @Deporte)">
            <SelectParameters>
                <asp:ControlParameter ControlID="ListaDeportes" Name="Deporte" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        Fecha:
        <asp:TextBox ID="Fecha" runat="server" Height="22px" OnTextChanged="Fecha_TextChanged" Width="201px" ReadOnly="True">    -- Seleccione una Fecha --</asp:TextBox>
&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="/Imagenes/Calendario.jpg" OnClick="ImageButton1_Click" Width="31px" />
&nbsp;&nbsp;&nbsp;</p>
        <div style="width:30%; margin: 0 auto; height: 180px;">    
            <asp:Calendar ID="Calendar1" runat="server"  DayHeaderStyle-VerticalAlign="Bottom" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Calendar1_SelectionChanged1" OnDayRender="Calendar1_DayRender" Width="288px" Height="177px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
    </div>
        <p>
        <asp:TextBox ID="Resultados" runat="server" BorderStyle="None" ForeColor="Red" Height="58px" TextMode="MultiLine" Visible="False" Width="541px"></asp:TextBox>
    </p>

    <p>
        <asp:Button ID="Anterior" runat="server" Text="Página Anterior" OnClick="Anterior_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="Crear" runat="server" OnClick="Crear_Click" Text="Reservar" />
    &nbsp;
        <asp:Button ID="Actualizar" runat="server" OnClick="Actualizar_Click" Text="Actualizar" />
&nbsp;
        <asp:Button ID="Borrar" runat="server" Text="Borrar" OnClick="Borrar_Click" />
&nbsp;
        <asp:Button ID="Leer" runat="server" Text="Ver Reserva" OnClick="Leer_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
</asp:Content>
