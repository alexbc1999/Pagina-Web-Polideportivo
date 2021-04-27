using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data.SqlClient;
using System.Drawing;

namespace webPolideportivoMDA
{
    public partial class CreaNoticias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null) {
                Master.FindControl("login").Visible = false;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            TextBox2.Visible = false;
        }

        protected void Button_Crear(object sender, EventArgs e)
        {
            bool todoOK = false;

            if (Titulo.Text.Length == 0)
            {
                TextBox2.Visible = true;
                TextBox2.Text = "El Título no puede estar vacío";
            }
            else
            {
                if (Descripcion.Text.Length < 10)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "La descripción de la pista no puede contener menos de 10 caráceteres";
                }
                else
                {
                    if (Autor.Text.Length == 0)
                    {
                        TextBox2.Visible = true;
                        TextBox2.Text = "Debes introducir algún autor";
                    }
                    else
                    {
                        todoOK = true;
                    }
                }
            }

            if (todoOK)
            {
                try
                {
                    ENNoticia eN = new ENNoticia();
                    eN.TituloNoticia = Titulo.Text;
                    eN.DescripcionNoticia = Descripcion.Text;
                    eN.FechaNoticia = DateTime.Now.ToString();
                    eN.AutorNoticia = Autor.Text;

                    if (eN.CreateNoticia())
                    {
                        TextBox2.Visible = true;
                        TextBox2.ForeColor = Color.Green;
                        TextBox2.Text = "Has introducido correctamente la notícia con el Título: " + eN.TituloNoticia;
                    }
                    else
                    {
                        TextBox2.Visible = true;
                        TextBox2.Text = "¡¡ERROR!! No anyadido correctamente el Título, ya tenemos ese título registrado en nuestra base de datos.";
                    }
                }
                catch (SqlException sqlex)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "¡¡ERROR!! Producida la excepción de comandos de SQL: " + sqlex;
                }
                catch (Exception ex)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "¡¡ERROR!! Producida la excepción: " + ex;
                }
            }
        }

        protected void Button_Actualizar(object sender, EventArgs e)
        {
            bool todoOK = false;

            if (Titulo.Text.Length == 0)
            {
                TextBox2.Visible = true;
                TextBox2.Text = "El Título no puede estar vacío";
            }
            else
            {
                if (Descripcion.Text.Length < 10)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "La descripción de la pista no puede contener menos de 10 caráceteres";
                }
                else
                {
                    if (Autor.Text.Length == 0)
                    {
                        TextBox2.Visible = true;
                        TextBox2.Text = "Debes introducir algún autor";
                    }
                    else
                    {
                        todoOK = true;
                    }
                }
            }

            if (todoOK)
            {
                try
                {
                    ENNoticia en = new ENNoticia();
                    en.TituloNoticia = Titulo.Text;
                    en.DescripcionNoticia = Descripcion.Text;
                    en.FechaNoticia = DateTime.Now.ToString();
                    en.AutorNoticia = Autor.Text;

                    if (en.UpdateNoticia())
                    {
                        TextBox2.Visible = true;
                        TextBox2.ForeColor = Color.Green;
                        TextBox2.Text = "Se ha actualizado correctamente la notícia con el Título: " + en.TituloNoticia;
                    }
                    else
                    {
                        TextBox2.Visible = true;
                        TextBox2.Text = "¡¡ERROR!! No actualizado correctamente el Título, porque no está registrado en nuestra base de datos.";
                    }
                }
                catch (SqlException sqlex)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "¡¡ERROR!! Producida la excepción de comandos de SQL: " + sqlex;
                }
                catch (Exception ex)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "¡¡ERROR!! Producida la excepción: " + ex;
                }
            }
        }

        protected void Button_Borrar(object sender, EventArgs e)
        {
            bool todoOK = false;

            if (Titulo.Text.Length == 0)
            {
                TextBox2.Visible = true;
                TextBox2.Text = "El Título no puede estar vacío";
            }
            else
            {
                todoOK = true;
            }
            if (todoOK)
            {
                try
                {
                    ENNoticia eN = new ENNoticia();
                    eN.TituloNoticia = Titulo.Text;

                    if (eN.DeleteNoticia())
                    {
                        TextBox2.Visible = true;
                        TextBox2.ForeColor = Color.Green;
                        TextBox2.Text = "La notícia con el Título: " + eN.TituloNoticia + " se ha borrado correctamente. ";
                    }
                    else
                    {
                        TextBox2.Visible = true;
                        TextBox2.Text = "¡¡ERROR!! No hemos podido borrar la Notícia con el Título: " + eN.TituloNoticia + " porque no existe en nuestra base de datos.";
                    }
                }
                catch (SqlException sqlex)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "¡¡ERROR!! Producida la excepción de comandos de SQL: " + sqlex;
                }
                catch (Exception ex)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "¡¡ERROR!! Producida la excepción: " + ex;
                }
            }
        }


        protected void Button_Leer(object sender, EventArgs e)
        {
            bool todoOK = false;

            if (Titulo.Text.Length == 0)
            {

                TextBox2.Visible = true;
                TextBox2.Text = "El Título no puede estar vacío";
            }
            else
            {
                todoOK = true;
            }
            if (todoOK)
            {
                try
                {
                    ENNoticia eN = new ENNoticia();
                    eN.TituloNoticia = Titulo.Text;

                    if (eN.ReadNoticia())
                    {
                        TextBox2.Visible = true;
                        TextBox2.ForeColor = Color.Green;
                        TextBox2.Text = "La descripción de la notícia que quieres leer es: " + eN.DescripcionNoticia + " Con la fecha: " + eN.FechaNoticia + " Y el autor: " + eN.AutorNoticia;
                    }
                    else
                    {
                        TextBox2.Visible = true;
                        TextBox2.Text = "¡¡ERROR!! No hemos podido leer la Notícia con el Título: " + eN.TituloNoticia + " porque no existe en nuestra base de datos.";
                    }
                }
                catch (SqlException sqlex)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "¡¡ERROR!! Producida la excepción de comandos de SQL: " + sqlex;
                }
                catch (Exception ex)
                {
                    TextBox2.Visible = true;
                    TextBox2.Text = "¡¡ERROR!! Producida la excepción: " + ex;
                }
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}