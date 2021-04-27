<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="webPolideportivoMDA.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-right: auto; margin-left: auto; text-align: center;">
    <h2>Formulario de Contacto</h2>
    <p>&nbsp;</p>
    <p>
        <asp:TextBox ID="Nombre" runat="server" onblur="crearCambiarNombre('Nombre *', this)" onfocus="CambiarNombre('Nombre *', this)" ForeColor="Gray" >Nombre *</asp:TextBox>
        <script type="text/javascript">
            function CambiarNombre(defaultText, texBoxControl) {
                if (texBoxControl.value == defaultText) {
                    texBoxControl.value = "";
                    texBoxControl.style.color = "black";
                }
            }

            function crearCambiarNombre(defaultText, texBoxControl) {
                if (texBoxControl.value.length == 0) {
                    texBoxControl.value = defaultText;
                    texBoxControl.style.color = "gray";
                }
            }
        </script>
    </p>
    <p>&nbsp;</p>
    <p>
        <asp:TextBox ID="Email" runat="server" onblur="crearCambiarNombre('Email *', this)" onfocus="CambiarNombre('Email *', this)" ForeColor="Gray">Email *</asp:TextBox>
    </p>
    <p>&nbsp;</p>
    <p>
        <asp:TextBox ID="Telefono" runat="server" onblur="crearCambiarNombre('Teléfono *', this)" onfocus="CambiarNombre('Teléfono *', this)" ForeColor="Gray">Teléfono *</asp:TextBox>
    </p>
    <p>&nbsp;</p>
    <p>
        <asp:TextBox ID="Mensaje" runat="server" Height="95px" TextMode="MultiLine" Width="418px" onblur="crearCambiarNombre('Mensaje *', this)" onfocus="CambiarNombre('Mensaje *', this)" ForeColor="Gray">Mensaje *</asp:TextBox>
    </p>
    <p>&nbsp;</p>
    <p>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="He leído y acepto la Política de Privacidad *" />
    </p>
    <p>
        <asp:TextBox ID="Resultados" runat="server" BorderStyle="None" ForeColor="Red" Visible="False"></asp:TextBox>
        </p>
    <p>
        <asp:Button ID="Enviar" runat="server" Height="37px" OnClientClick="return confirm('¿Enviar Mensaje?')" Text="Enviar" Width="95px" OnClick="Enviar_Click" />
    </p>
    
    <address>
        <strong>Soporte:</strong>   <a href="mailto:Support@example.com">polideportivoMDA@ua.es</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">mohammed@derfoufi.com</a><br />
        <strong>Diseño:</strong> <a href="mailto:Marketing@example.com">daniel@sentamans.com</a><br />
        <strong>Colaboración:</strong> <a href="mailto:Marketing@example.com">alejandro@bernabeu.com</a>
    </address>
        </div>
    </asp:Content>
