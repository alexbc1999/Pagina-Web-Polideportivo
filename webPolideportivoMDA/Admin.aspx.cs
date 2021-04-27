using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace webPolideportivoMDA
{
    public partial class Admin : System.Web.UI.Page
    {
        ENAdministrador sesion = new ENAdministrador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                sesion.usuario = Session["USER_ID"].ToString();
                Label1.Text = sesion.usuario;
                Master.FindControl("login").Visible = false;
                try
                {
                    if (!sesion.getCorreo())
                    {
                        Session.Abandon();
                        Response.Redirect("Default.aspx");
                    }
                    correo.Text = sesion.CorreoUsuario;
                    nombre.Text = sesion.NombreUsuario;
                    Apellidos.Text = sesion.ApellidosUsuario;
                    username.Text = sesion.usuario;
                    Edad.Text = sesion.EdadUsuario.ToString();
                    sesion.readAdmin();
                    depart.Text = sesion.depart;
                    numero.Text = sesion.numeroTarjeta.ToString();
                    Tipo.Text = sesion.tarjetaSocio.categoriaTarjeta;
                    if (Tipo.Text.Equals("Bronce"))
                    {
                        Image1.ImageUrl = "/Imagenes/bronce.jpeg";
                    }
                    else if (Tipo.Text.Equals("Plata"))
                    {
                        Image1.ImageUrl = "/Imagenes/plata.jpg";
                    }
                    else if (Tipo.Text.Equals("Oro"))
                    {
                        Image1.ImageUrl = "/Imagenes/oro.jpg";
                    }
                    puntuacion.Text = sesion.tarjetaSocio.puntos.ToString();
                }
                catch (SqlException)
                {
                    Session.Abandon();
                    Response.Redirect("Default.aspx");
                }
                catch (Exception)
                {
                    Session.Abandon();
                    Response.Redirect("Default.aspx");
                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        protected void Borrar(object sender, EventArgs e)
        {

            try {
                sesion.admin = false;
                if (sesion.deleteAdmin())
                {
                    Session.Abandon();
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Error.Text = "No hemos podido borrar el usuario!!";
                    Error.Visible = true;
                }
            }
            catch (SqlException sqlex)
            {
                Error.Text = "No hemos podido borrar el usuario, ha ocurrido la siguiente excepción: " + sqlex.Message;
                Error.Visible = true;
            }
            catch (Exception ex)
            {
                Error.Text = "No hemos podido borrar el usuario, ha ocurrido la siguiente excepción: " + ex.Message;
                Error.Visible = true;
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void Cambiar_password_Click(object sender, EventArgs e)
        {
            Response.Redirect("cambiarpasswd.aspx");
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            TextBox4.Visible = true;
            cambionombre.Visible = true;
            cambioapellidos.Visible = true;
            cambioedad.Visible = true;
            dept.Visible = true;
            Confirmar.Visible = true;
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            if (cambionombre.Text.Length != 0)
            {
                sesion.NombreUsuario = cambionombre.Text;
            }

            if (cambioapellidos.Text.Length != 0)
            {
                sesion.ApellidosUsuario = cambioapellidos.Text;
            }

            if (cambioedad.Text.Length != 0)
            {
                sesion.EdadUsuario = int.Parse(cambioedad.Text);
            }
            if(dept.Text.Length != 0)
            {
                sesion.depart = dept.Text;
            }
            try
            {
                if (sesion.updateAdmin())
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    Error.Text = "No hemos podido actualizar los datos del Administrador!!";
                    Error.Visible = true;
                }
                Confirmar.Visible = false;
                TextBox4.Visible = false;
                cambionombre.Visible = false;
                cambioapellidos.Visible = false;
                cambioedad.Visible = false;
            }
            catch (SqlException sqlex)
            {
                Error.Text = "No hemos podido actualizar los datos del Administrador, ha ocurrido la siguiente excepción: " + sqlex.Message;
                Error.Visible = true;
            }
            catch (Exception ex)
            {
                Error.Text = "No hemos podido actualizar los datos del Administrador, ha ocurrido la siguiente excepción: " + ex.Message;
                Error.Visible = true;
            }
        }

        protected void addnoticia_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreaNoticias.aspx");
        }

        protected void addpista_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreaPistas.aspx");
        }

        protected void addAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Addadmin.aspx");
        }

        protected void addactividad_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminActividades.aspx");
        }
    }
}