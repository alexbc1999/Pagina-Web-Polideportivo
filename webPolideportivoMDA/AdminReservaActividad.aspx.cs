using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webPolideportivoMDA
{
    public partial class AdminReservaActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ENUsuario enu = new ENUsuario();

            if (Session["USER_ID"] != null)
            {
                
                enu.usuario = Session["USER_ID"].ToString();
            
                enu.getCorreo();
                lbCorreo.Text = enu.CorreoUsuario;
                Master.FindControl("login").Visible = false;
            }
            else
            {
                Response.Redirect("login.aspx");
            }
             
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbIdActividad.Text = GridView1.SelectedRow.Cells[3].Text;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReservarActividad.aspx");
        }
    }
}