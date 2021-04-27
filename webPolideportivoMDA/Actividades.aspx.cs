using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webPolideportivoMDA
{
    public partial class AdminActividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Imagen.ImageUrl = "/Imagenes/fondo.jpg";
        }

        protected void buBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lbFechaSelected.Text = Calendar1.SelectedDate.ToString("d");
        }

        protected void buReservar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReservarActividad.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminActividades.aspx");
        }

        protected void ListaActividades_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = DropDownList1.SelectedValue;
            Imagen.Visible = true;

            if (opcion == "Padel")
            {
                Imagen.ImageUrl = "/Imagenes/Pista-de-Padel.jpg";
            }

            if (opcion == "Futbol")
            {
                Imagen.ImageUrl = "/Imagenes/Campo-de-Futbol.jpg";
            }

            if (opcion == "Tenis")
            {
                
                Imagen.ImageUrl = "/Imagenes/Pista-de-Tenis.jpg";
            }

            if (opcion == "Baloncesto")
            {
                Imagen.ImageUrl = "/Imagenes/Pista-de-Baloncesto.jpg";
            }
        }
    }
}