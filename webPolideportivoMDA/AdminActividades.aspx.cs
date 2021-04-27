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
	public partial class Actividades : System.Web.UI.Page
	{
		
		bool algoParaActualizar = false;
		protected void Page_Load(object sender, EventArgs e)
		{
			ENUsuario enu = new ENUsuario();
			enu.usuario = Session["USER_ID"].ToString();
			enu.getCorreo();
			
			if (Session["USER_ID"] != null && enu.admin)//Comprueba que ademas de estar logeado es un Admin
			{ 
				Master.FindControl("login").Visible = false;
			}
			else
			{
				Response.Redirect("login.aspx");
			}

		}

		protected void Calendar1_SelectionChanged(object sender, EventArgs e)
		{
			Button1.Visible = false;
			lbFechaSelected.Text = Calendar1.SelectedDate.ToString("d");
			DropDownList4.Visible = true;
			lbHora.Visible = true;
			buCrear.Visible = true;
			buActualizar.Visible = false;
			buBorrar.Visible = false;
			tbDescripcion.Text = "";
			tbProfesor.Text = "";
			tbMaxPersonas.Text = "";
			lbExit.Text = "";
		}
		

		protected void ddlAdminHora_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		
		protected void buActualizar_Click(object sender, EventArgs e)
		{
			if (algoParaActualizar)
			{
				try
				{
					if (tbDescripcion.Text.Length > 0 && tbDescripcion.Text.Length <= 16) //Si hemos introducido una DESC correcta Entra
					{
						if (tbProfesor.Text.Length > 0 && tbProfesor.Text.Length <= 16)//Si introducimos un Profe valido ENTRA
						{
							if (Page.IsValid)//Si introducimos un MaxPerosnas valida ENTRA
							{

								ENActividad ac = new ENActividad();
								ac.Nombre = GridView1.SelectedRow.Cells[2].Text;
								ac.Fecha = GridView1.SelectedRow.Cells[3].Text;
								ac.Hora = GridView1.SelectedRow.Cells[4].Text;
								ac.Descripcion = tbDescripcion.Text; 
								ac.Profesor = tbProfesor.Text;
								ac.MaxPersonas = Int16.Parse(tbMaxPersonas.Text.ToString());

								bool b = ac.updateActividad(); 
								if (b)
								{
									lbExit.Text = " Actividad actualizada CORRECTAMENTE";
									Console.WriteLine("Actividad actualizadocorrectamente");
									buActualizar.Visible = false;
									buBorrar.Visible = false;
									tbDescripcion.Text = "";
									tbProfesor.Text = "";
									tbMaxPersonas.Text = "";
									algoParaActualizar = false;
								}
								else
								{
									lbExit.Text = " Error, Actividad NO existente en la BD";
									Console.WriteLine("Error, Actividad NO existente en la BD");
								}
							}
							else
							{
								lbExit.Text = " Error, campo MaxPersoans rellenado INCORRECTAMENTE (valen de 0 a 50) TODOS los campos deben de estar rellenados para poder actualizar";
								Console.WriteLine("Error, campo MaxPErosnas rellenado INCORRECTAMENTE");
							}
						}
						else
						{
							lbExit.Text = " Error, campo Profesor rellenado INCORRECTAMENTE, TODOS los campos deben de estar rellenados para poder actualizar";
							Console.WriteLine("Error, campo Profesor rellenado INCORRECTAMENTE");
						}
					}
					else
					{
						lbExit.Text = " Error, campo Descripcion rellenado INCORRECTAMENTE";
						Console.WriteLine("Error, campo Descripcionrellenado INCORRECTAMENTE");
					}

				}
				catch (SqlException s)
				{
					lbExit.Text = s.Message;
					Console.WriteLine("User operation has failed. Error: {0}", s.Message);
				}
				catch (Exception ex)
				{
					lbExit.Text = ex.Message;
					Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
				}
			}
			else
			{
				lbExit.Text = "Debe modificar algun parametro antes de actualizar!!";
			}
		}

		protected void buBorrar_Click(object sender, EventArgs e)
		{
			try
			{
				ENReservaActividad rs = new ENReservaActividad();
				rs.Actividad = Int16.Parse(GridView1.SelectedRow.Cells[1].Text);
				if (rs.tieneReservas())
				{
					lbExit.Text = "La Actividad tiene Resrvas asignadas, ¿está seguro de que quiere borrar TODAS las reservas asignadas a esta Actividad?";
					Button1.Visible = true;
					buActualizar.Visible = false;
					buBorrar.Visible = false;
					tbDescripcion.Text = "";
					tbProfesor.Text = "";
					tbMaxPersonas.Text = "";
					algoParaActualizar = false;
				}
				else
				{
					ENActividad ac = new ENActividad();
					ac.Nombre = GridView1.SelectedRow.Cells[2].Text;
					ac.Fecha = GridView1.SelectedRow.Cells[3].Text;
					ac.Hora = GridView1.SelectedRow.Cells[4].Text;
					bool b = ac.deleteActividad();
					lbExit.Text = "Actividad BORRADA con éxito";
					buActualizar.Visible = false;
					buBorrar.Visible = false;
					tbDescripcion.Text = "";
					tbProfesor.Text = "";
					tbMaxPersonas.Text = "";
					algoParaActualizar = false;
				}
			}
			catch (SqlException s)
			{
				lbExit.Text = s.Message;
				Console.WriteLine("User operation has failed. Error: {0}", s.Message);
			}
			catch (Exception ex)
			{
				lbExit.Text = ex.Message;
				Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
			}

		}

		protected void tbDescripcion_TextChanged(object sender, EventArgs e)
		{
			algoParaActualizar = true;
		}

		protected void tbProfesor_TextChanged(object sender, EventArgs e)
		{
			algoParaActualizar = true;
		}

		protected void tbMaxPersonas_TextChanged(object sender, EventArgs e)
		{
			algoParaActualizar = true;
		}

		

		protected void buCrear_Click(object sender, EventArgs e)
		{
			if (DropDownList1.SelectedValue != "-1" && lbFechaSelected.Text.Length < 11 && DropDownList4.SelectedValue != "-1")
			{
				try
				{
					ENActividad ac = new ENActividad();
					ac.Nombre = DropDownList1.SelectedValue;
					ac.Fecha = lbFechaSelected.Text;
					ac.Hora = DropDownList4.SelectedValue;

					bool existeActividad = ac.readActividad();//Bajamos a ENActividad

					if (existeActividad) //La actividad YA existe, no s epuede crear
					{
						lbExit.Text = " Error, Actividad YA existente en la BD";
						Console.WriteLine("Error, Actividad YA existente en la BD");
					}
					else // Si no existe, procedemos y la creamos
					{

						if (tbDescripcion.Text.Length > 0 && tbDescripcion.Text.Length <= 16) //Si hemos introducido una DESC correcta Entra
						{
							if (tbProfesor.Text.Length > 0 && tbProfesor.Text.Length <= 16)//Si introducimos un Profe valido ENTRA
							{
								if (Page.IsValid)//Si introducimos un MaxPerosnas valida ENTRA
								{
									

										ac.Descripcion = tbDescripcion.Text;
										ac.Profesor = tbProfesor.Text;
										ac.MaxPersonas = Int16.Parse(tbMaxPersonas.Text.ToString());

										bool b = ac.createActividad();
										if (b)
										{
											lbExit.Text = " Actividad creada CORRECTAMENTE";
											Console.WriteLine("Actividad creada correctamente");
											tbDescripcion.Text = "";
											tbProfesor.Text = "";
											tbMaxPersonas.Text = "";
											lbFechaSelected.Text = " -- Seleccione del Calendario --";
										}
										else
										{
											lbExit.Text = " Error, No se ha podido crear la actividad";
											Console.WriteLine("Error, No se h apodido crear la actividad");
										}
									
								}
								else
								{
									lbExit.Text = " Error, campo MaxPersoans rellenado INCORRECTAMENTE (valen de 0 a 50)";
									Console.WriteLine("Error, campo MaxPErosnas rellenado INCORRECTAMENTE");
								}
							}
							else
							{
								lbExit.Text = " Error, campo Profesor rellenado INCORRECTAMENTE";
								Console.WriteLine("Error, campo Profesor rellenado INCORRECTAMENTE");
							}
						}
						else
						{
							lbExit.Text = " Error, campo Descripcion rellenado INCORRECTAMENTE";
							Console.WriteLine("Error, campo Descripcionrellenado INCORRECTAMENTE");

						}
					}
				}
				catch (SqlException s)
				{
					lbExit.Text = s.Message;
					Console.WriteLine("User operation has failed. Error: {0}", s.Message);
				}
				catch (Exception ex)
				{
					lbExit.Text = ex.Message;
					Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
				}
			}
			else
			{
				lbExit.Text = "La Actividad necesita un Deporte, Fecha y Hora correctos para ser creada";
				Console.WriteLine("La Actividad necesita un Deporte, Fecha y Hora correctos para ser creada");
			}
		}

		protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Button1.Visible = false;
			DropDownList4.Visible = true;
			lbHora.Visible = true;
			buCrear.Visible = true;
			buActualizar.Visible = false;
			buBorrar.Visible = false;
			tbDescripcion.Text = "";
			tbProfesor.Text = "";
			tbMaxPersonas.Text = "";
			lbExit.Text = "";
		}

		protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
		{
			Button1.Visible = false;
			lbExit.Text = "";
			lbSalida.Text = "";
		}

		protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				Button1.Visible = false;
				lbExit.Text = "";
				ENActividad ac = new ENActividad();
				ac.Nombre = GridView1.SelectedRow.Cells[2].Text;
				ac.Fecha = GridView1.SelectedRow.Cells[3].Text;
				ac.Hora = GridView1.SelectedRow.Cells[4].Text;
				buCrear.Visible = false;
				lbHora.Visible = false;
				DropDownList4.Visible = false;

				bool existeActividad = ac.readActividad();//Bajamos a ENActividad
				if (existeActividad)
				{
					buActualizar.Visible = true;
					buBorrar.Visible = true;
					tbDescripcion.Text = ac.Descripcion;
					tbProfesor.Text = ac.Profesor;
					tbMaxPersonas.Text = ac.MaxPersonas.ToString();
					
					algoParaActualizar = false;
				}
				else
				{
					buActualizar.Visible = false;
					buBorrar.Visible = false;
					lbExit.Text = "Error , no existe esa Actividad";
				}
			}
			catch (SqlException s)
			{
				throw s;
			}
			catch (Exception m)
			{
				lbExit.Text = m.Message;
			}
		}

		protected void Lista1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				ENReservaActividad rs = new ENReservaActividad();
				rs.Actividad = Int16.Parse(GridView1.SelectedRow.Cells[1].Text);
				if (rs.borradoActividadEntera())
				{
					ENActividad ac = new ENActividad();
					ac.Nombre = GridView1.SelectedRow.Cells[2].Text;
					ac.Fecha = GridView1.SelectedRow.Cells[3].Text;
					ac.Hora = GridView1.SelectedRow.Cells[4].Text;
					bool b = ac.deleteActividad();
					buActualizar.Visible = false;
					lbExit.Text = "La Actividad ha sido BORRADA con éxito";
					Button1.Visible = false;
					tbDescripcion.Text = "";
					tbProfesor.Text = "";
					tbMaxPersonas.Text = "";
					algoParaActualizar = false;
				}
				else
				{
					lbExit.Text = "No ha sido posible borrar la Actividad vete tu a saber porque";
				}
			}
			catch (SqlException s)
			{
				lbExit.Text = s.Message;
				Console.WriteLine("User operation has failed. Error: {0}", s.Message);
			}
			catch (Exception ex)
			{
				lbExit.Text = ex.Message;
				Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
			}
		}

		protected void LinkButton1_Click(object sender, EventArgs e)
		{
			Response.Redirect("Admin.aspx");
		}
	}
}