<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="webPolideportivoMDA.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/Sesion.css" rel="stylesheet" />
        
    <br />
        
    <div class ="container">
        <div class ="content" >
        <img width="40px" height="40px" src="../Imagenes/perfil.png" />
        <a>&nbsp;Admin: <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></a><br />
        
    </div>
     
    <div class="inf" contenteditable="true">
         <asp:TextBox ID="TextBox1" width ="790px" Height="30px" BackColor="#99ccff" Text=">Datos personales: " runat="server" Enabled="False"></asp:TextBox><br />
         <a>Correo: </a>  
         <asp:TextBox ID="correo" width ="300px" Height="20px" placeholder="Correo: " runat="server" Enabled="False"></asp:TextBox><br />
         <a>Nombre: </a><asp:TextBox ID="nombre" width ="100px" Height="20px" placeholder="Nombre: " runat="server" Enabled="False" ></asp:TextBox>
         <a> Apellidos: </a><asp:TextBox ID="Apellidos" width ="200px" Height="20px" placeholder="Apellidos: " runat="server" Enabled="False"></asp:TextBox><br />
         <a>Username: </a><asp:TextBox ID="username" width ="100px" Height="20px" placeholder="Nombre: " runat="server" Enabled="False"></asp:TextBox>
         <a> Edad: </a><asp:TextBox ID="Edad" width ="50px" Height="20px" placeholder="Edad: " TextMode="Number" runat="server" MaxLength="3" Enabled="False"></asp:TextBox>
         <a>Departamento: </a><asp:TextBox ID="depart" width ="100px" Height="20px" placeholder="Departamento: " runat="server" Enabled="False" ></asp:TextBox>
         <asp:Button ID="edit" runat="server" Text="Editar" OnClick="edit_Click" />
         
      </div>
    </div>
    
    <div class="cont">
        <div class="vertical-menu">
          <a href="Usuario" class="active">Inicio</a>
          <asp:LinkButton ID="addnoticia" runat="server" OnClick="addnoticia_Click" >Añadir Noticia</asp:LinkButton>
          <asp:LinkButton ID="addpista" runat="server" OnClick="addpista_Click" >Añadir Pista</asp:LinkButton>
          <asp:LinkButton ID="addactividad" runat="server" OnClick="addactividad_Click" >Añadir Actividad</asp:LinkButton>
          <asp:LinkButton ID="addAdmin" runat="server" OnClick="addAdmin_Click" >Añadir Administrador</asp:LinkButton>
          <a href="Calendario">Calendario</a>
          <a href="ReservarPista">Reservar pistas</a>
          <a href="ReservarActividad">Reservar actividad</a>
          <asp:LinkButton ID="Cambiar_password" runat="server" OnClick="Cambiar_password_Click">Cambiar contraseña</asp:LinkButton>
          <asp:LinkButton ID="borrar" OnClick="Borrar" runat="server" OnClientClick="return confirm('¿Seguro quieres borrar?')">Borrar Datos</asp:LinkButton>
          <asp:LinkButton ID="Log_out" OnClick="Logout" runat="server">Log out</asp:LinkButton>
        </div>

        <div class="target">
            <asp:TextBox ID="TextBox6" width ="790px" Height="30px" BackColor="#99ccff" Text=">Tarjeta Socio: " runat="server" Enabled="False"></asp:TextBox><br />
            <a>Número Tarjeta Socio: </a> <asp:TextBox ID="numero" width ="100px" Height="20px" placeholder="Numero Tarjeta: " runat="server" Enabled="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="Image1" runat="server" Height="49px" ImageAlign="Right" Width="101px" />
&nbsp;&nbsp;&nbsp;&nbsp; <br />
            <a>Tipo de Tarjeta: </a> <asp:TextBox ID="Tipo" width ="100px" Height="20px" placeholder="Categoria: " runat="server" Enabled="False"></asp:TextBox>
            <a>Puntuación: </a><asp:TextBox ID="puntuacion" width ="80px" Height="20px" placeholder="Puntuacion: " runat="server" Enabled="False"></asp:TextBox><br />

            <br />
            <br />
            <asp:TextBox ID="TextBox4" width ="790px"  Height="30px" BackColor="#99ccff" Text=">Cambio de datos personales: " Visible="False" runat="server" Enabled="False"></asp:TextBox><br />
            <asp:TextBox ID="cambionombre" width ="200px" Height="20px" placeholder="Nuevo nombre: " Visible="False" runat="server"  ></asp:TextBox>
            <asp:TextBox ID="cambioapellidos" width ="300px" Height="20px" placeholder="Nuevos apellidos: " Visible="False" runat="server" ></asp:TextBox><br />
            <asp:TextBox ID="cambioedad" width ="100px" Height="20px" placeholder="Nueva edad: " TextMode="Number" Visible="False" runat="server" MaxLength="3" ></asp:TextBox>
            <asp:TextBox ID="dept" width ="200px" Height="20px" placeholder="Departamento: " runat="server" Visible="False" ></asp:TextBox>
            <asp:Button ID="Confirmar" runat="server" Text="Confirmar" Visible="False" OnClick="Confirmar_Click" BackColor="#99CCFF"  /><br />
            <asp:Label ID="Error" Style="padding-left: 1vw; padding-top: 20px;" Font-Size="Medium" ForeColor="red" runat="server" Visible="false" Text=""></asp:Label>

        </div>
    </div>

    
    
    <br />
</asp:Content>
