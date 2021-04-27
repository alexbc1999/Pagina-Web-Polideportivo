using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace webPolideportivoMDA
{
    public partial class Addadmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] == null)
            {
                Response.Redirect("Default.aspx");
            } else
            {
                ENUsuario en = new ENUsuario();
                en.usuario = Session["USER_ID"].ToString();
                try
                {
                    en.getCorreo();
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

                if (en.admin)
                {
                    Master.FindControl("login").Visible = false;
                } else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
        protected void buscar_Click(object sender, EventArgs e)
        {
             crear.Visible = true;
             departamento.Enabled = true;
        }

        protected void crear_Click(object sender, EventArgs e)
        {
            ENAdministrador en = new ENAdministrador();
            try
            {
                if (DropDownList1.Items.Count != 0)
                {
                    if (departamento.Text.Length != 0)
                    {
                        en.depart = departamento.Text;
                        en.usuario = DropDownList1.SelectedValue;
                        en.getCorreo();
                        en.admin = true;

                        if (en.createAdmin())
                        {
                            error.Text = "Usuario cambiado a Administrador correctamente";
                        }
                        else
                        {
                            error.Text = "No se ha podido añadir el usuario como Administrador!!";
                        }
                    }
                    else
                    {
                        error.Text = "Rellene el campo de departamento!!!";
                    }

                }
                else
                {
                    error.Text = "No se han encontrado usuarios como el especificado!!";
                }
            }
            catch (SqlException sqlex)
            {
                error.Text = "No hemos podido añadir el usuario, ha ocurrido la siguiente excepción: " + sqlex.Message;
                error.Visible = true;
            }
            catch (Exception ex)
            {
                error.Text = "No hemos podido añadir el usuario, ha ocurrido la siguiente excepción: " + ex.Message;
                error.Visible = true;
            }

        }

        protected void volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}