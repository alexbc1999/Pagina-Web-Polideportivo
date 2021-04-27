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
    public partial class CreaPistas : System.Web.UI.Page
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
            Resultados.Visible = false;
        }

        protected void Crear_Click(object sender, EventArgs e)
        {
            bool todoOK = false;

            if (numpista.Text.Length == 0)
            {
                Resultados.Visible = true;
                Resultados.Text = "El numero de pista no puede estar vacío";
            }
            else
            {
                if (deppista.Text.Equals("-1"))
                {
                    Resultados.Visible = true;
                    Resultados.Text = "El deporte no puede estar vacío";
                }
                else
                {
                    if (descpista.Text.Length < 10)
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "La descripción de la pista no puede contener menos de 10 caráceteres";
                    }
                    else
                    {
                        if (cubpista.Text.Equals("-1"))
                        {
                            Resultados.Visible = true;
                            Resultados.Text = "La pista debe ser cubierta(1) o no cubierta(0)";
                        }
                        else
                        {
                            todoOK = true;
                        }
                    }
                }
            }

            if (todoOK)
            {
                try
                {
                    ENPista en = new ENPista();
                    en.numeroPista = Convert.ToInt32(numpista.Text);
                    en.deportePista = deppista.Text;
                    en.descripcionPista = descpista.Text;
                    if (cubpista.Text == "0")
                    {
                        en.cubiertaPista = false;
                    }
                    else
                    {
                        en.cubiertaPista = true;
                    }

                    if (en.createPista())
                    {
                        Resultados.Visible = true;
                        Resultados.ForeColor = Color.Green;
                        Resultados.Text = "Creada correctamente la pista con el número: " + en.numeroPista + " y el deporte: " + en.deportePista;
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "¡¡ERROR!! No hemos podido Crear la Pista con el Número: " + en.numeroPista + " y el Deporte: " + en.deportePista + "porque ya existe en nuestra base de datos.";
                    }
                }
                catch (SqlException sqlex)
                {
                    Resultados.Visible = true;
                    Resultados.Text = "¡¡ERROR!! Producida la excepción de comandos de SQL: " + sqlex;
                }
                catch (Exception ex)
                {
                    Resultados.Visible = true;
                    Resultados.Text = "¡¡ERROR!! Producida la excepción: " + ex;
                }
            }
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            bool todoOK = false;

            if (numpista.Text.Length == 0)
            {
                Resultados.Visible = true;
                Resultados.Text = "El numero de pista no puede estar vacío";
            }
            else
            {
                if (deppista.Text.Equals("-1"))
                {
                    Resultados.Visible = true;
                    Resultados.Text = "El deporte no puede estar vacío";
                }
                else
                {
                    if (descpista.Text.Length < 10)
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "La descripción de la pista no puede contener menos de 10 caráceteres";
                    }
                    else
                    {
                        if (cubpista.Text.Equals("-1"))
                        {
                            Resultados.Visible = true;
                            Resultados.Text = "La pista debe ser cubierta(1) o no cubierta(0)";
                        }
                        else
                        {
                            todoOK = true;
                        }
                    }
                }
            }

            if (todoOK)
            {
                try
                {
                    ENPista en = new ENPista();
                    en.numeroPista = Convert.ToInt32(numpista.Text);
                    en.deportePista = deppista.Text;
                    en.descripcionPista = descpista.Text;
                    if (cubpista.Text == "0")
                    {
                        en.cubiertaPista = false;
                    }
                    else
                    {
                        en.cubiertaPista = true;
                    }

                    if (en.updatePista())
                    {
                        Resultados.Visible = true;
                        Resultados.ForeColor = Color.Green;
                        Resultados.Text = "Actualizada correctamete la pista con el número: " + en.numeroPista + " y el deporte: " + en.deportePista;
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "¡¡ERROR!! No hemos podido Actualizar la Pista con el Número: " + en.numeroPista + " y el Deporte: " + en.deportePista + "porque no existe en nuestra base de datos.";
                    }
                }
                catch (SqlException sqlex)
                {
                    Resultados.Visible = true;
                    Resultados.Text = "¡¡ERROR!! Producida la excepción de comandos de SQL: " + sqlex;
                }
                catch (Exception ex)
                {
                    Resultados.Visible = true;
                    Resultados.Text = "¡¡ERROR!! Producida la excepción: " + ex;
                }
            }
        }

        protected void Leer_Click(object sender, EventArgs e)
        {
            bool todoOK = false;

            if (numpista.Text.Length == 0)
            {
                Resultados.Visible = true;
                Resultados.Text = "El numero de pista no puede estar vacío";
            }
            else
            {
                todoOK = true;
            }

            if (todoOK)
            {
                try
                {
                    ENPista en = new ENPista();
                    en.numeroPista = Convert.ToInt32(numpista.Text);
                    en.deportePista = deppista.Text;

                    if (en.readPista())
                    {
                        Resultados.Visible = true;
                        Resultados.ForeColor = Color.Green;
                        Resultados.Text = "Leída correctamete la pista con el número: " + en.numeroPista + ", el deporte: " + en.deportePista + ", la descripción: " + en.descripcionPista + " y cubierta: " + en.cubiertaPista;
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "¡¡ERROR!! No hemos podido leer la Pista con el Número: " + en.numeroPista + " y el Deporte: " + en.deportePista + "porque no existe en nuestra base de datos.";
                    }
                }
                catch (SqlException sqlex)
                {
                    Resultados.Visible = true;
                    Resultados.Text = "¡¡ERROR!! Producida la excepción de comandos de SQL: " + sqlex;
                }
                catch (Exception ex)
                {
                    Resultados.Visible = true;
                    Resultados.Text = "¡¡ERROR!! Producida la excepción: " + ex;
                }
            }
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            bool todoOK = false;

            if (numpista.Text.Length == 0)
            {
                Resultados.Visible = true;
                Resultados.Text = "El numero de pista no puede estar vacío";
            }
            else
            {
                todoOK = true;
            }

            if (todoOK)
            {
                try
                {
                    ENPista en = new ENPista();
                    en.numeroPista = Convert.ToInt32(numpista.Text);
                    en.deportePista = deppista.Text;

                    if (en.deletePista())
                    {
                        Resultados.Visible = true;
                        Resultados.ForeColor = Color.Green;
                        Resultados.Text = "Borrada correctamete la pista con el número: " + en.numeroPista + " y el deporte: " + en.deportePista;
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "¡¡ERROR!! No hemos podido Borrar la Pista con el Número: " + en.numeroPista + " y el Deporte: " + en.deportePista + "porque no existe en nuestra base de datos.";
                    }
                }
                catch (SqlException sqlex)
                {
                    Resultados.Visible = true;
                    Resultados.Text = "¡¡ERROR!! Producida la excepción de comandos de SQL: " + sqlex;
                }
                catch (Exception ex)
                {
                    Resultados.Visible = true;
                    Resultados.Text = "¡¡ERROR!! Producida la excepción: " + ex;
                }
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}