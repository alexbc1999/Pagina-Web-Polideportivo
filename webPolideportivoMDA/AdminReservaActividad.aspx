<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminReservaActividad.aspx.cs" Inherits="webPolideportivoMDA.AdminReservaActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
    <asp:Label ID="lb1" runat="server" Text="Correo: "></asp:Label>
    <asp:Label ID="lbCorreo" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
        <asp:Label ID="lbIdActividad" runat="server" Visible="False"></asp:Label>
    </h2>
    <p>
    <asp:GridView ID="GridView1" runat="server" Height="217px" Width="622px" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="ListaReservasActividades" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                
                <ItemTemplate>
                    
                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar" />
                    &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" OnClientClick="return confirm('¿Seguro que desea eliminar la Reserva?')" CommandName="Delete" Text="Eliminar" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
            <asp:BoundField DataField="Actividad" HeaderText="Actividad" SortExpression="Actividad" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <EmptyDataTemplate>
            Aún no tienes reservas. Vuelve y reserva alguna Actividad
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
    <asp:SqlDataSource ID="ListaReservasActividades" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" DeleteCommand="DELETE FROM [ReservaActividad] WHERE [Id] = @original_Id AND [Correo] = @original_Correo AND [Actividad] = @original_Actividad" InsertCommand="INSERT INTO [ReservaActividad] ([Correo], [Actividad]) VALUES (@Correo, @Actividad)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [ReservaActividad] WHERE ([Correo] = @Correo)" UpdateCommand="UPDATE [ReservaActividad] SET [Correo] = @Correo, [Actividad] = @Actividad WHERE [Id] = @original_Id AND [Correo] = @original_Correo AND [Actividad] = @original_Actividad">
        <DeleteParameters>
            <asp:Parameter Name="original_Id" Type="Int32" />
            <asp:Parameter Name="original_Correo" Type="String" />
            <asp:Parameter Name="original_Actividad" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Correo" Type="String" />
            <asp:Parameter Name="Actividad" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="lbCorreo" Name="Correo" PropertyName="Text" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Correo" Type="String" />
            <asp:Parameter Name="Actividad" Type="Int32" />
            <asp:Parameter Name="original_Id" Type="Int32" />
            <asp:Parameter Name="original_Correo" Type="String" />
            <asp:Parameter Name="original_Actividad" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="ListaActividad" ForeColor="Black" GridLines="Horizontal" Height="131px" Width="616px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="MaxPersonas" HeaderText="MaxPersonas" SortExpression="MaxPersonas" />
            <asp:BoundField DataField="Profesor" HeaderText="Profesor" SortExpression="Profesor" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
            <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:SqlDataSource ID="ListaActividad" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT * FROM [Actividad] WHERE ([Id] = @Id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="lbIdActividad" Name="Id" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        
        </p>
    <h3><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">&lt;-- Anterior</asp:LinkButton></h3>
</asp:Content>
