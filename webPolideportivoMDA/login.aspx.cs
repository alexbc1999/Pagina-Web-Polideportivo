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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["USER_ID"] != null)
            {
                ENUsuario en = new ENUsuario();
                en.usuario = Session["USER_ID"].ToString();
                
                    en.getCorreo();
                    if (en.admin)
                    {
                        Response.Redirect("Admin.aspx");
                    }
                    Response.Redirect("Usuario.aspx");
                
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            ENUsuario us = new ENUsuario();
            bool validar = false;
            try
            {
                if (usuario.Text.Contains("@"))
                {
                    us.CorreoUsuario = usuario.Text;
                }
                else
                {
                    us.usuario = usuario.Text;
                    if (us.getCorreo())
                    {
                        validar = true;
                    }

                }
                if (validar)
                {
                    if (us.checkUsuario(HashPasswordMD5(password.Text)))
                    {
                        Session["USER_Id"] = us.usuario;
                        if (!us.admin)
                        {
                            Response.Redirect("Usuario.aspx");
                        }
                        else
                        {
                            Response.Redirect("Admin.aspx");
                        }

                    }
                    else
                    {
                        Label1.Text = "Error con los datos introducidos!!";
                    }
                }
                else
                {
                    Label1.Text = "El usuario no existe en nuestra base de datos!!";
                }
            }
            catch (SqlException sqlex)
            {
                Label1.Text = "Se ha producido la siguiente excepción: " + sqlex.Message;
            }
            catch (Exception ex)
            {
                Label1.Text = "Se ha producido la siguiente excepción: " + ex.Message;
            }

        }

        protected void Registrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("recuperarpasswd.aspx");
        }
    }
}