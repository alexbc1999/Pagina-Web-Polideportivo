using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Library;

namespace webPolideportivoMDA
{
    public partial class Pistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Imagen.Visible = false;
            Reservar.Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = DropDownList1.SelectedValue;
            Reservar.Visible = true;

            if (opcion == "Padel")
            {
                Imagen.Visible = true;
                Imagen.ImageUrl = "/Imagenes/Pista-de-Padel.jpg";
            }

            if(opcion == "Futbol")
            {
                Imagen.Visible = true;
                Imagen.ImageUrl = "/Imagenes/Campo-de-Futbol.jpg";
            }

            if (opcion == "Tenis")
            {
                Imagen.Visible = true;
                Imagen.ImageUrl = "/Imagenes/Pista-de-Tenis.jpg";
            }

            if (opcion == "Baloncesto")
            {
                Imagen.Visible = true;
                Imagen.ImageUrl = "/Imagenes/Pista-de-Baloncesto.jpg";
            }

        }

        protected void Reservar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReservarPista.aspx");
        }
    }
}