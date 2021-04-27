using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class CADActividad
    {
        private string constring;

       public CADActividad()
       {
           constring = ConfigurationManager.ConnectionStrings["conexion_PolideportivoMDA"].ToString();
       }

        public bool createActividad(ENActividad en)
        {

            SqlConnection dr = new SqlConnection(constring);
            try
            {

                dr.Open();
                SqlCommand coma = new SqlCommand("Insert INTO Actividad (Nombre,Descripcion,MaxPersonas,Profesor,Fecha,Hora) VALUES ('" + en.Nombre + "','" + en.Descripcion + "','" + en.MaxPersonas + "','" + en.Profesor + "','" + en.Fecha + "','" + en.Hora + "')", dr);
                coma.ExecuteNonQuery();
                dr.Close();
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool deleteActividad(ENActividad en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete from Actividad where (Nombre = '" + en.Nombre + "') AND (Fecha = '" + en.Fecha + "') AND (Hora = '" + en.Hora + "')", c);
                com.ExecuteNonQuery();

                c.Close();
                return true;
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

        public bool updateActividad(ENActividad en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Actividad where (Nombre = '" + en.Nombre + "') AND (Fecha = '" + en.Fecha + "') AND (Hora = '" + en.Hora + "')", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                   
                        dr.Close();
                        SqlCommand coma = new SqlCommand("UPDATE Actividad SET Descripcion = '" + en.Descripcion + "', MaxPersonas = '" + en.MaxPersonas + "', Profesor = '" + en.Profesor + "'  where (Nombre = '" + en.Nombre + "') AND (Fecha = '" + en.Fecha + "') AND (Hora = '" + en.Hora + "')", c);
                    coma.ExecuteNonQuery();

                        dr.Close();
                        c.Close();
                        return true;
                    
                }
                dr.Close();
                return false;// La actividad no existe, no se puede actualizar
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool readActividad(ENActividad en)
        {

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Actividad where (Nombre = '" + en.Nombre + "') AND (Fecha = '" + en.Fecha + "') AND (Hora = '" + en.Hora + "')", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Index = Int16.Parse(dr["Id"].ToString());
                    en.Descripcion = dr["Descripcion"].ToString();
                    en.MaxPersonas = Int16.Parse(dr["MaxPersonas"].ToString());
                    en.Profesor = dr["Profesor"].ToString();
                    dr.Close();
                    c.Close();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }

        }

       
    }

}
