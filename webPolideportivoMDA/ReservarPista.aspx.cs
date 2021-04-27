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
    public partial class ReservarPista : System.Web.UI.Page
    {
        ENUsuario enu = new ENUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                
                enu.usuario = Session["USER_ID"].ToString();
                enu.getCorreo();
                TextBox1.Text = enu.CorreoUsuario;
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

            if (ListaHoras.Text.Equals("-1"))
            {
                Resultados.Visible = true;
                Resultados.Text = "Debes seleccionar una hora para realizar la reserva";
            }

            else
            {
                if (ListaDeportes.SelectedValue.Equals("-1"))
                {
                    Resultados.Visible = true;
                    Resultados.Text = "Debes seleccionar una deporte para realizar la reserva";
                }

                else
                {
                    if (Fecha.Text.Length == 0)
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "Debes seleccionar una fecha para realizar la reserva";
                    }

                    else
                    {
                        if (ListaPistas.SelectedValue.Equals("-1"))
                        {
                            Resultados.Visible = true;
                            Resultados.Text = "Debes seleccionar una pista para realizar la reserva";
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
                    ENReservaPista en = new ENReservaPista();
                    en.HoraReserva = ListaHoras.Text;
                    en.FechaReserva = Fecha.Text;
                    string correo = TextBox1.Text;
                    int numeropista = Convert.ToInt32(ListaPistas.Text);
                    string deporte = ListaDeportes.Text;

                    if (en.CreateReserva(correo, numeropista, deporte))
                    {
                        CADReservaPista cAD = new CADReservaPista();
                        en.NumeroReserva = cAD.obtenerNumero(en.HoraReserva, deporte, en.FechaReserva, numeropista);
                        enu.tarjetaSocio.updateTarjetaSocio(3);
                        Resultados.Visible = true;
                        Resultados.ForeColor = Color.Green;
                        Resultados.Text = "Reserva hecha con éxito con el numero de reserva: " + en.NumeroReserva + " añadidos 3 puntos a tu cuenta";
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "No hemos podido crear la reserva, porque ya hay una reserva asociada a la hora: " + en.HoraReserva + " y la fecha: " + en.FechaReserva + " para el deporte: " + deporte + " con la pista: " + numeropista;
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

            if (ListaHoras.Text.Equals("-1"))
            {
                Resultados.Visible = true;
                Resultados.Text = "Debes seleccionar una hora para realizar la reserva";
            }

            else
            {
                if (ListaDeportes.SelectedValue.Equals("-1"))
                {
                    Resultados.Visible = true;
                    Resultados.Text = "Debes seleccionar una deporte para realizar la reserva";
                }

                else
                {
                    if (Fecha.Text.Length == 0)
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "Debes seleccionar una fecha para realizar la reserva";
                    }

                    else
                    {
                        if (ListaPistas.SelectedValue.Equals("-1"))
                        {
                            Resultados.Visible = true;
                            Resultados.Text = "Debes seleccionar una pista para realizar la reserva";
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
                    ENReservaPista en = new ENReservaPista();
                    en.NumeroReserva = Convert.ToInt32(Reservado.Text);
                    en.HoraReserva = ListaHoras.Text;
                    en.FechaReserva = Fecha.Text;
                    string correo = TextBox1.Text;
                    int numeropista = Convert.ToInt32(ListaPistas.Text);
                    string deporte = ListaDeportes.Text;

                    if (en.UpdateReserva(correo, numeropista, deporte))
                    {
                        Resultados.Visible = true;
                        Resultados.ForeColor = Color.Green;
                        Resultados.Text = "Actualización hecha con éxito con el numero: " + en.NumeroReserva;
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "No hemos podido actualizar la reserva, no hay ninguna reserva asociada a la hora: " + en.HoraReserva + " y la fecha: " + en.FechaReserva + " para el deporte: " + deporte + " con la pista: " + numeropista;
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

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            Fecha.Text = Calendar1.SelectedDate.ToLongDateString();
        }

        protected void Fecha_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            bool todoOK = false;

            if (Reservado.SelectedValue.Equals("-1"))
            {
                Resultados.Visible = true;
                Resultados.Text = "Debes introducir un numero de reserva";
            }
            else
            {
                todoOK = true;
            }

            if (todoOK) {
                try
                {
                    ENReservaPista en = new ENReservaPista();
                    en.NumeroReserva = Convert.ToInt32(Reservado.Text);

                    if (en.DeleteReserva())
                    {
                        Resultados.Visible = true;
                        Resultados.ForeColor = Color.Green;
                        Resultados.Text = "Reserva borrada con éxito con el numero: " + en.NumeroReserva;
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "No hemos podido borrar la reserva, no hay ninguna reserva asociada a el número: " + en.NumeroReserva;
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

            if (Reservado.SelectedValue.Equals("-1"))
            {
                Resultados.Visible = true;
                Resultados.Text = "Debes introducir un numero de reserva";
            }
            else
            {
                todoOK = true;
            }

            if (todoOK)
            {
                try
                {
                    ENReservaPista en = new ENReservaPista();
                    en.NumeroReserva = Convert.ToInt32(Reservado.Text);
                    int numeropista = 0;
                    string deporte = "";

                    if (en.ReadReserva())
                    {
                        deporte = en.ObtenerDeporte(deporte, en.NumeroReserva);
                        numeropista = en.ObtenerNumPista(numeropista, en.NumeroReserva);
                        Resultados.Visible = true;
                        Resultados.ForeColor = Color.Green;
                        Resultados.Text = "Lectura hecha con éxito con el numero: " + en.NumeroReserva + ", con la hora: " + en.HoraReserva + " y la fecha: " + en.FechaReserva + " para el deporte: " + deporte + " con la pista: " + numeropista; ;
                    }
                    else
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "No hemos podido leer la reserva, no hay ninguna reserva asociada a el número: " + en.NumeroReserva;
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

       
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            bool todoOK = false;

            if (ListaHoras.Text.Equals("-1"))
            {
            }

            else
            {
                if (ListaDeportes.SelectedValue.Equals("-1"))
                {
                }

                else
                {
                    if (Fecha.Text.Length == 0)
                    {
                    }

                    else
                    {
                        if (ListaPistas.SelectedValue.Equals("-1"))
                        {
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
                    ENReservaPista en = new ENReservaPista();
                    if (en.ObtenerEstado(ListaDeportes.SelectedValue, ListaHoras.SelectedValue, e.Day.Date.ToLongDateString(), Convert.ToInt32(ListaPistas.SelectedValue)))
                    {
                        e.Cell.BackColor = Color.Red;
                        e.Cell.Text = "x";
                        e.Cell.ToolTip = "Ocupado";
                    }
                    else
                    {
                        e.Cell.ToolTip = "Disponible";
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
            ENUsuario enu = new ENUsuario();
            enu.usuario = Session["USER_ID"].ToString();
            enu.getCorreo();
            if (enu.admin)
            {
                Response.Redirect("Admin.aspx");
            }
            else
            {
                Response.Redirect("Usuario.aspx");
            }
            
        }
    }
}