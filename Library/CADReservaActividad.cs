using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class CADReservaActividad
    {
        private string constring;

        public CADReservaActividad()
        {
            constring = ConfigurationManager.ConnectionStrings["conexion_PolideportivoMDA"].ToString();
        }

        public bool createReserva(ENReservaActividad re)
        {

            SqlConnection dr = new SqlConnection(constring);
            try
            {

                dr.Open();
                SqlCommand coma = new SqlCommand("Insert INTO ReservaActividad (Correo,Actividad) VALUES ('" + re.Correo + "','" + re.Actividad + "')", dr);
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

        public bool deleteReserva(ENReservaActividad re)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete from ReservaActividad where (Correo = '" + re.Correo + "') AND (Actividad = '" + re.Actividad + "')", c);
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

        public bool updateReserva(ENReservaActividad re)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from ReservaActividad where (Correo = '" + re.Correo + "') AND (Actividad = '" + re.Actividad + "')", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    
                    dr.Close();
                    SqlCommand coma = new SqlCommand("UPDATE ReservaActividad SET Correo = '" + re.Correo + "')", c);

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
       
        public bool readReserva(ENReservaActividad re)
        {

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from ReservaActividad where (Correo = '" + re.Correo + "') AND (Actividad = '" + re.Actividad + "')", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {

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

        public bool tieneReservas(ENReservaActividad re)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from ReservaActividad where (Actividad = '" + re.Actividad + "')", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read()) //Hay Reservas
                {

                    dr.Close();
                    c.Close();

                    return true;
                }
                else//No hay reservas s epuede borrar con facilidad
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

        public bool borradoActividadEntera(ENReservaActividad re)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                
                
                    c.Open();
                    SqlCommand com = new SqlCommand("Delete from ReservaActividad where (Actividad = '" + re.Actividad + "')", c);
                    com.ExecuteNonQuery();

                    
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

        public int plazasOcupadas(ENReservaActividad re)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select COUNT (*) from ReservaActividad where (Actividad = '" + re.Actividad + "')", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read()) 
                {
                    int n = dr.GetInt32(0);
                    dr.Close();
                    c.Close();
                    return n;

                }
                else
                {
                    return 5000;
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
