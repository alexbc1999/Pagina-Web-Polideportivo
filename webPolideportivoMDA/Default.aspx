<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webPolideportivoMDA._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-right: auto; margin-left: auto; text-align:center; ">
    <div class="jumbotron" style="background-image:url('/Imagenes/fondo.jpg'); background-size: 80% 80%; background-attachment: fixed;">
        <h1 style="color:azure">PolideportivoMDA</h1>
        <p style="color:azure">
            ¡¡Bienvenido a nuestro polideportivo, donde te ofrecemos las mejores pistas y servicios calidad-precio!!
        </p>
    </div>

    <script src="Scripts/modernizr-2.0.6.min.js"></script>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/jquery.mousewheel-3.0.6.min.js"></script>
    <script src="Scripts/jquery.rondell.min.js"></script>
    <link href="Content/jquery.rondell.css" rel="stylesheet" />
    
        <div id="rondellCarousel" style="margin:auto;">
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <a href="<%# Container.DataItem %>">
            <img src="<%# Container.DataItem %>" />
        </ItemTemplate>
            </asp:Repeater>
    </div>
   
    <script type="text/javascript">
        $(function (){
            $("#rondellCarousel").rondell({
                preset: "carousel",
            });
        });
    </script>
        </div>
</asp:Content>
