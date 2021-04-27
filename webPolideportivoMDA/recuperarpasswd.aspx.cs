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
    public partial class recuperarpasswd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void confirmar_Click(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            if(username.Text.Length != 0)
            {
                en.usuario = username.Text;
                confirmar.Visible = false;
                error.Visible = true;
                try
                {
                    if (en.getCorreo())
                    {
                        if (en.NombreUsuario.Equals(nombre.Text) &&
                            en.ApellidosUsuario.Equals(apellidos.Text) &&
                            en.EdadUsuario == int.Parse(edad.Text))
                        {
                            if (passwd.Text.Length != 0 && confirmpasswd.Text.Length != 0
                                && passwd.Text.Equals(confirmpasswd.Text))
                            {
                                if (en.updatePassword(HashPasswordMD5(passwd.Text)))
                                {
                                    error.Text = "Contraseña cambiada perfectamente";
                                    

                                }
                                else
                                {
                                    error.Text = "No hemos podido cambiar su contraseña!!";
                                }
                            }
                            else
                            {
                                error.Text = "La contraseña no coincide con la confirmación!!!";
                            }
                        }
                        else
                        {
                            error.Text = "Los datos introducidos no coinciden con los de nuestra base de datos!!!";
                        }
                    }
                    else
                    {
                        error.Text = "El usuario introducido no existe!!!";
                    }
                }
                catch (SqlException sqlex)
                {
                    error.Text = "Se ha producido una excepción: " + sqlex;
                }
                catch (Exception ex)
                {
                    error.Text = "Se ha producido una excepción: " + ex;
                }
            } else
            {
                error.Text = "Introduce un username!!!";
            }
            
            

        }

        protected void volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}