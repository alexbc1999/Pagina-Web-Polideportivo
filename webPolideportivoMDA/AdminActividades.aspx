<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminActividades.aspx.cs" Inherits="webPolideportivoMDA.Actividades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administrar actividades</h1>
    <h5>
        Seleccione una hora para CREAR una Actividad. Seleccione una Actividad de la lista para EDITARLA. </h5>
    <h5>
        Para cancelar una selección y poder volver a CREAR, cambie de fecha o de Deporte.</h5>
    <div>

        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Height="247px" Width="514px" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="FullMonth">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar> 

    </div>
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
&nbsp;&nbsp;&nbsp;<asp:Label ID="lbHora" runat="server" Text="Hora :"></asp:Label>
        &nbsp;<asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="-1">-- Seleccione Hora --</asp:ListItem>
            <asp:ListItem>09:00</asp:ListItem>
            <asp:ListItem>10:00</asp:ListItem>
            <asp:ListItem>11:00</asp:ListItem>
            <asp:ListItem>12:00</asp:ListItem>
            <asp:ListItem>13:00</asp:ListItem>
            <asp:ListItem>14:00</asp:ListItem>
            <asp:ListItem>15:00</asp:ListItem>
            <asp:ListItem>16:00</asp:ListItem>
            <asp:ListItem>17:00</asp:ListItem>
            <asp:ListItem>18:00</asp:ListItem>
            <asp:ListItem>19:00</asp:ListItem>
            <asp:ListItem>20:00</asp:ListItem>
            <asp:ListItem>21:00</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;</h3>
    <h3>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:SqlDataSource ID="Lista1" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT * FROM [Actividad] WHERE (([Fecha] = @Fecha) AND ([Nombre] = @Nombre)) ORDER BY [Hora]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Actividad] WHERE [Id] = @original_Id AND [Nombre] = @original_Nombre AND [Descripcion] = @original_Descripcion AND [MaxPersonas] = @original_MaxPersonas AND [Profesor] = @original_Profesor AND [Fecha] = @original_Fecha AND [Hora] = @original_Hora" InsertCommand="INSERT INTO [Actividad] ([Nombre], [Descripcion], [MaxPersonas], [Profesor], [Fecha], [Hora]) VALUES (@Nombre, @Descripcion, @MaxPersonas, @Profesor, @Fecha, @Hora)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Actividad] SET [Nombre] = @Nombre, [Descripcion] = @Descripcion, [MaxPersonas] = @MaxPersonas, [Profesor] = @Profesor, [Fecha] = @Fecha, [Hora] = @Hora WHERE [Id] = @original_Id AND [Nombre] = @original_Nombre AND [Descripcion] = @original_Descripcion AND [MaxPersonas] = @original_MaxPersonas AND [Profesor] = @original_Profesor AND [Fecha] = @original_Fecha AND [Hora] = @original_Hora" OnSelecting="Lista1_Selecting">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_Nombre" Type="String" />
                <asp:Parameter Name="original_Descripcion" Type="String" />
                <asp:Parameter Name="original_MaxPersonas" Type="Int32" />
                <asp:Parameter Name="original_Profesor" Type="String" />
                <asp:Parameter Name="original_Fecha" Type="String" />
                <asp:Parameter Name="original_Hora" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Nombre" Type="String" />
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="MaxPersonas" Type="Int32" />
                <asp:Parameter Name="Profesor" Type="String" />
                <asp:Parameter Name="Fecha" Type="String" />
                <asp:Parameter Name="Hora" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="lbFechaSelected" Name="Fecha" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" Name="Nombre" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nombre" Type="String" />
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="MaxPersonas" Type="Int32" />
                <asp:Parameter Name="Profesor" Type="String" />
                <asp:Parameter Name="Fecha" Type="String" />
                <asp:Parameter Name="Hora" Type="String" />
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_Nombre" Type="String" />
                <asp:Parameter Name="original_Descripcion" Type="String" />
                <asp:Parameter Name="original_MaxPersonas" Type="Int32" />
                <asp:Parameter Name="original_Profesor" Type="String" />
                <asp:Parameter Name="original_Fecha" Type="String" />
                <asp:Parameter Name="original_Hora" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="Lista1" ForeColor="#333333" GridLines="Horizontal" Height="27px" Width="1005px" DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" CausesValidation="False" InsertVisible="False" ShowCancelButton="False" ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="MaxPersonas" HeaderText="MaxPersonas" SortExpression="MaxPersonas" />
                <asp:BoundField DataField="Profesor" HeaderText="Profesor" SortExpression="Profesor" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
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
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:SqlDataSource ID="ListaHoras2" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [Hora] FROM [Actividad] WHERE (([Fecha] = @Fecha) AND ([Nombre] = @Nombre))">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbFechaSelected" Name="Fecha" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" Name="Nombre" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        </h3>
    <p>
    
    
        
        <asp:Label ID="lbSalida" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lbExit" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
    
    
        </p>
    <p>
    
    
        
        <asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="68px" OnClick="Button1_Click" Text="Borrar de todos modos" Visible="False" Width="286px" />
        
    
    
        </p>
    <p>
    
    
        
        &nbsp;</p>
    <p>
        
    
    
        <asp:Label ID="lbDescripcion" runat="server" Text="Descripción: " Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Strikeout="False"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="tbDescripcion" runat="server" OnTextChanged="tbDescripcion_TextChanged"></asp:TextBox>
   
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbProfesor" runat="server" Text="Profesor: " Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="tbProfesor" runat="server" OnTextChanged="tbProfesor_TextChanged"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbMaxPersonas" runat="server" Text="MaxPersonas:" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="tbMaxPersonas" runat="server" TextMode="Number" OnTextChanged="tbMaxPersonas_TextChanged"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbMaxPersonas" ErrorMessage="Valores entre 0 y 50" MaximumValue="50" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
   
    </p>
    <p>
        &nbsp;&nbsp;
        </p>
    <p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="buCrear" runat="server" Height="30px" OnClick="buCrear_Click" Text="Crear" Width="150px" />
        <asp:Button ID="buActualizar" runat="server" Height="30px" OnClick="buActualizar_Click" Text="Actualizar" Visible="False" Width="150px" OnClientClick="return confirm ('Actualizarás todas las reservas de esta Actividad')" />
        <asp:Button ID="buBorrar" runat="server" Height="30px" OnClick="buBorrar_Click" Text="Borrar" Visible="False" Width="150px" OnClientClick="return confirm ('¿Está seguro de borrar esta Actividad?')" />
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
    <h3>
        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">&lt;-- Anterior</asp:LinkButton>
    </h3>
</asp:Content>
