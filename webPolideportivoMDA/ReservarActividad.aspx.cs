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
    
   
    public partial class ReservarActividad : System.Web.UI.Page
    {
		ENUsuario enu = new ENUsuario();
		protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
				Imagen.ImageUrl = "/Imagenes/fondo.jpg";
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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lbFechaSeleccionada.Text = Calendar1.SelectedDate.ToString("d");
			buReservar.Visible = false;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void buReservar_Click(object sender, EventArgs e)
        {
            
			try
			{
				ENActividad ac = new ENActividad();
				ac.Nombre = GridView1.SelectedRow.Cells[1].Text;
				ac.Fecha = GridView1.SelectedRow.Cells[2].Text;
				ac.Hora = GridView1.SelectedRow.Cells[3].Text;

				bool existeActividad = ac.readActividad();//Bajamos a ENActividad
				

				if (existeActividad) {//La actividad existe

					ENReservaActividad re = new ENReservaActividad();
					re.Correo = lbCorreo.Text;
					re.Actividad = ac.Index;

					int plazasOcupadas = re.plazasOcupadas();
					if (plazasOcupadas < Int16.Parse((GridView1.SelectedRow.Cells[5].Text)))
					{

						try
						{
							
							bool reservado = re.readReserva();

							if (reservado)
							{

								lbSalida.Text = " YA está Inscrito en esta Actividad. Acceda a Mis Reservas para más información";
								Console.WriteLine("Error, Actividad YA reservad por el user");
							}
							else // Si no existe, procedemos y la creamos la reserva
							{
								bool creada = re.createReserva();
								if (creada)
								{
									lbSalida.Text = " Reserva creada CORRECTAMENTE";
									Console.WriteLine("Reserva creada correctamente");

								}
								else
								{
									lbSalida.Text = " Error, No se ha podido crear la reserva";
									Console.WriteLine("Error, No se h apodido crear la reserva");
								}

							}
						}
						catch (SqlException s)
						{
							lbSalida.Text = s.Message;
							Console.WriteLine("User operation has failed. Error: {0}", s.Message);
						}
						catch (Exception ex)
						{
							lbSalida.Text = ex.Message;
							Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
						}
					}
					else
					{
						lbSalida.Text = "Esta Actividad esta COMPLETA. Lo sentimos, busca otra con plazas libres.";
						Console.WriteLine("Actividad COMPLETA");
					}

					
				}
				else
				{
					lbSalida.Text = "Actividad no válida o no existente";
				}

				
			}
			catch (SqlException s)
			{
				lbSalida.Text = s.Message;
				Console.WriteLine("User operation has failed. Error: {0}", s.Message);
			}
			catch (Exception ex)
			{
				lbSalida.Text = ex.Message;
				Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
			}

		}

		protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			buReservar.Visible = true;
			lbSalida.Text = "";
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			buReservar.Visible = false;
			lbSalida.Text = "";
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

		protected void LinkButton1_Click(object sender, EventArgs e)
		{
			Response.Redirect("AdminReservaActividad.aspx");
		}

		protected void LinkButton2_Click(object sender, EventArgs e)
		{
			Response.Redirect("actividades.aspx");
		}
	}
}