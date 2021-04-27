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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                ENUsuario en = new ENUsuario();
                en.usuario = Session["USER_ID"].ToString();
                try
                {
                    en.getCorreo();
                    if (en.admin)
                    {
                        Response.Redirect("Admin.aspx");
                    }
                    Response.Redirect("Usuario.aspx");
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
        }

        public static string HashPasswordMD5(string passwd)
        {
            using (var md5 = MD5.Create())
            {
                byte[] passwdBytes = Encoding.ASCII.GetBytes(passwd);

                byte[] hash = md5.ComputeHash(passwdBytes);

                var stringBuilder = new StringBuilder();

                for(int i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("X2"));
                }

                return stringBuilder.ToString();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();

            try
            {
                if (correo.Text.Contains("@") && correo.Text.Length != 0)
                {
                    en.CorreoUsuario = correo.Text;
                    if (nombre.Text.Length != 0)
                    {
                        en.NombreUsuario = nombre.Text;
                        if (apellidos.Text.Length != 0)
                        {
                            en.ApellidosUsuario = apellidos.Text;
                            if (username.Text.Length != 0)
                            {
                                en.usuario = username.Text;
                                if (!en.getCorreo())
                                {
                                    if (edad.Text.Length != 0)
                                    {
                                        en.EdadUsuario = int.Parse(edad.Text);
                                        if (password.Text.Length != 0 && Check_password.Text.Length != 0)
                                        {
                                            if (password.Text.Equals(Check_password.Text))
                                            {
                                                
                                                en.ContrasenaUsuario = HashPasswordMD5(password.Text);
                                                if (en.createUsuario())
                                                {
                                                    Session["USER_Id"] = en.usuario;
                                                    Response.Redirect("Usuario.aspx");
                                                }
                                                else
                                                {
                                                    Label8.Text = "No hemos podido crear el usuario!!";
                                                }
                                            }
                                            else
                                            {
                                                Label8.Text = "Las contraseñas no coinciden!!!";
                                            }
                                        }
                                        else
                                        {
                                            Label8.Text = "Rellene el campo correspondiente a la contraseña!!";
                                        }

                                    }
                                    else
                                    {
                                        Label8.Text = "Rellene el campo correspondiente a la edad!!";
                                    }
                                }
                                else
                                {
                                    Label8.Text = "El nombre de usuario ya existe!!";
                                }
                            }
                            else
                            {
                                Label8.Text = "Rellene el campo correspondiente al nombre de usuario!!";
                            }
                        }
                        else
                        {
                            Label8.Text = "Rellene el campo correspondiente a los apellidos!!";
                        }
                    }
                    else
                    {
                        Label8.Text = "Rellene el campo correspondiente al nombre!!";
                    }
                }
                else
                {
                    Label8.Text = "El correo debe tener el formato correcto, por ejemplo: ejemplo@gmail.com!!";
                    correo.Text = "";
                }
            }
            catch (SqlException sqlex)
            {
                Label8.Text = "Se ha producido la siguiente excepción: " + sqlex.Message;
            }
            catch (Exception ex)
            {
                Label8.Text = "Se ha producido la siguiente excepción: " + ex.Message;
            }

        }

        protected void log(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}