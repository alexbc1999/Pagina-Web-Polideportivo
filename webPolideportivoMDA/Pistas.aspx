<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pistas.aspx.cs" Inherits="webPolideportivoMDA.Pistas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div style="margin-right: auto; margin-left: auto; text-align:center; align-content:center; align-items:center; ">
    <h2>Pistas de nuestro PolideportivoMDA</h2>
    <p>
        &nbsp;</p>
    <p>
        Si quieres buscar alguna pista, seleccione una pista&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True" Height="16px" Width="193px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="-1">-- Seleccione Pista --</asp:ListItem>
            <asp:ListItem>Tenis</asp:ListItem>
            <asp:ListItem>Futbol</asp:ListItem>
            <asp:ListItem>Baloncesto</asp:ListItem>
            <asp:ListItem>Padel</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="DropdownNumero" DataTextField="NumeroPista" DataValueField="NumeroPista" Height="19px" Width="223px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ValidateRequestMode="Enabled">
            <asp:ListItem Value="-1">-- Seleccione Número Pista --</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="DropdownNumero" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [NumeroPista] FROM [Pista] WHERE ([Deporte] = @Deporte)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Deporte" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
&nbsp;<asp:SqlDataSource ID="ElegirPista" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT [Deporte], [NumeroPista] FROM [Pista]"></asp:SqlDataSource>
        </p>
        <div style="margin-right: auto; margin-left: auto; text-align:left;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NumeroPista,Deporte" DataSourceID="MostrarDatosPista" ForeColor="#333333" GridLines="None" Height="24px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1223px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NumeroPista" HeaderText="NumeroPista" ReadOnly="True" SortExpression="NumeroPista" />
                <asp:BoundField DataField="Deporte" HeaderText="Deporte" ReadOnly="True" SortExpression="Deporte" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:CheckBoxField DataField="Cubierta" HeaderText="Cubierta" SortExpression="Cubierta" />
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
            <br />
            </div>
        <asp:SqlDataSource ID="MostrarDatosPista" runat="server" ConnectionString="<%$ ConnectionStrings:conexion_PolideportivoMDA %>" SelectCommand="SELECT * FROM [Pista] WHERE (([Deporte] = @Deporte) AND ([NumeroPista] = @NumeroPista))">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Deporte" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownList2" Name="NumeroPista" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    <p>
        <asp:Image ID="Imagen" runat="server" Height="193px" Width="293px" ImageAlign="Right" Visible="False" />

    </p>
    <p>
        <asp:LinkButton ID="Reservar" runat="server" BorderStyle="Solid" ForeColor="Black" OnClick="Reservar_Click" OnClientClick="return confirm('¿Reservar Pista?')" Visible="False">Reservar Pista</asp:LinkButton>
    </p>
       </div>
    </asp:Content>
