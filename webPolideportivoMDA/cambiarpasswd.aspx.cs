using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace webPolideportivoMDA
{
    public partial class cambiarpasswd : System.Web.UI.Page
    {
        ENUsuario sesion = new ENUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                Master.FindControl("login").Visible = false;
                sesion.usuario = Session["USER_ID"].ToString();
                try
                {
                    if (!sesion.getCorreo())
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

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        public static string HashPasswordMD5(string passwd)
        {
            using (var md5 = MD5.Create())
            {
                byte[] passwdBytes = Encoding.ASCII.GetBytes(passwd);

                byte[] hash = md5.ComputeHash(passwdBytes);

                var stringBuilder = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("X2"));
                }

                return stringBuilder.ToString();
            }
        }

        protected void cambiar_Click(object sender, EventArgs e)
        {
            try
            {
                Label1.Visible = true;
                if (!actual.Text.Equals(new1.Text))
                {
                    if (HashPasswordMD5(actual.Text).Equals(sesion.ContrasenaUsuario))
                    {
                        if (new1.Text.Equals(new2.Text))
                        {
                            if (!sesion.updatePassword(HashPasswordMD5(new1.Text)))
                            {
                                Label1.Text = "No se ha podido cambiar el password!!";
                            }
                            else
                            {
                                Label1.Text = "Contraseña actualizada correctamente!!";
                            }
                        }
                        else
                        {
                            Label1.Text = "No coincide la confirmación con la nueva contraseña!!";
                        }
                    }
                    else
                    {
                        Label1.Text = "La contraseña actual no coincide con la que tenemos!!";

                    }
                }
                else
                {
                    Label1.Text = "La nueva contraseña no puede ser igual a la actual!!";
                }
            }
            catch (SqlException sqlex)
            {
                Label1.Text = "No hemos podido cambiar la contraseña del usuario, ha ocurrido la siguiente excepción: " + sqlex.Message;
                
            }
            catch (Exception ex)
            {
                Label1.Text = "No hemos podido cambiar la contraseña del usuario, ha ocurrido la siguiente excepción: " + ex.Message;
                
            }
        }

        protected void volver_Click(object sender, EventArgs e)
        {
            if(sesion.admin)
            {
                Response.Redirect("Admin.aspx");
            } else
            {
                Response.Redirect("Usuario.aspx");
            }
            
        }
    }
}