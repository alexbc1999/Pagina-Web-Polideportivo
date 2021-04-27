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
    public partial class Usuario : System.Web.UI.Page
    {
        ENUsuario sesion = new ENUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["USER_ID"]!= null)
            {
                sesion.usuario = Session["USER_ID"].ToString();
                Label1.Text = sesion.usuario;
                Master.FindControl("login").Visible=false;
                try
                {
                    if(!sesion.getCorreo())
                    {
                        Session.Abandon();
                        Response.Redirect("Default.aspx");
                    } 
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

                correo.Text = sesion.CorreoUsuario;
                nombre.Text = sesion.NombreUsuario;
                Apellidos.Text = sesion.ApellidosUsuario;
                username.Text = sesion.usuario;
                Edad.Text = sesion.EdadUsuario.ToString();
                numero.Text = sesion.numeroTarjeta.ToString();
                Tipo.Text = sesion.tarjetaSocio.categoriaTarjeta;
                if(Tipo.Text.Equals("Bronce"))
                {
                    Image1.ImageUrl = "/Imagenes/bronce.jpeg";
                } else if(Tipo.Text.Equals("Plata"))
                {
                    Image1.ImageUrl = "/Imagenes/plata.jpg";
                } else if (Tipo.Text.Equals("Oro"))
                {
                    Image1.ImageUrl = "/Imagenes/oro.jpg";
                }
                puntuacion.Text = sesion.tarjetaSocio.puntos.ToString();

            } else
            {
                Response.Redirect("Default.aspx");
            }
            
        }

        

        protected void Borrar(object sender, EventArgs e)
        {
            try
            {
                if (sesion.deleteUsuario())
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
            Confirmar.Visible = true;
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            if(cambionombre.Text.Length != 0)
            {
                sesion.NombreUsuario = cambionombre.Text;
            }

            if(cambioapellidos.Text.Length != 0)
            {
                sesion.ApellidosUsuario = cambioapellidos.Text;
            }

            if(cambioedad.Text.Length != 0)
            {
                sesion.EdadUsuario = int.Parse(cambioedad.Text);
            }

            try
            {
                if (sesion.updateUsuario())
                {
                    Response.Redirect("Usuario.aspx");
                } else
                {
                    Error.Text = "No hemos podido actualizar los datos del usuario!!";
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
                Error.Text = "No hemos podido actualizar los datos del usuario, ha ocurrido la siguiente excepción: " + sqlex.Message;
                Error.Visible = true;
            }
            catch (Exception ex)
            {
                Error.Text = "No hemos podido actualizar los datos del usuario, ha ocurrido la siguiente excepción: " + ex.Message;
                Error.Visible = true;
            }
        }

       
    }
}