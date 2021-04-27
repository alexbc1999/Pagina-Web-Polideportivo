using Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webPolideportivoMDA
{
    public partial class Calendario : System.Web.UI.Page
    {
        private string constring = ConfigurationManager.ConnectionStrings["conexion_PolideportivoMDA"].ToString();
        ENUsuario enu = new ENUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                enu.usuario = Session["USER_ID"].ToString();
                enu.getCorreo();
                Master.FindControl("login").Visible = false;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            Resultados.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                ENReservaPista en = new ENReservaPista();
                enu.usuario = Session["USER_ID"].ToString();
                enu.getCorreo();
                string select_reserva = "select horareserva from reservapista where correo = '" + enu.CorreoUsuario + "'";
                SqlCommand cmd_select = new SqlCommand(select_reserva, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read())
                {
                    en.HoraReserva = dr.GetString(0);
                    dr.Close();
                }

                if (en.ObtenerFecha(en.HoraReserva, e.Day.Date.ToLongDateString()))
                {
                    e.Cell.BackColor = Color.Coral;
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
                Resultados.ForeColor = Color.Red;
                Resultados.Visible = true;
                Resultados.Text = "¡¡ERROR!! Producida la excepción de comandos de SQL: " + sqlex;
            }
            catch (Exception ex)
            {
                Resultados.ForeColor = Color.Red;
                Resultados.Visible = true;
                Resultados.Text = "¡¡ERROR!! Producida la excepción: " + ex;
            }
        }
    }
}
