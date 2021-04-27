using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CADTarjetaSocio
    {
        private string constring = ConfigurationManager.ConnectionStrings["conexion_PolideportivoMDA"].ToString();

        public CADTarjetaSocio() { }

        public int getNumero()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select Numero_Tarjeta from TarjetaSocio order by Numero_Tarjeta desc";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    int numero = int.Parse(dr["Numero_Tarjeta"].ToString());
                    return numero;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Tarjeta socio operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tarjeta socio operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            
        }

        public bool createTarjetaSocio(ENTarjetaSocio en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();

                string insert = "Insert into TarjetaSocio(Numero_Tarjeta,Categoria,Puntuacion) " +
                        "values ('" + en.numero + "','" + en.categoriaTarjeta + "','" + en.puntos + "')";

                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Tarjeta socio operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tarjeta socio operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            
        }

        public bool readTarjetaSocio(ENTarjetaSocio en)
        {
            SqlConnection conn = null;
            try
            {

                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select * from TarjetaSocio where Numero_Tarjeta ='" + en.numero + "'"; 
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {

                    en.categoriaTarjeta = dr["Categoria"].ToString();
                    en.puntos = int.Parse(dr["Puntuacion"].ToString());
                    
                    dr.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Read Tarjeta operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Read Tarjeta operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool updateTarjeta(ENTarjetaSocio en, int points)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select Numero_Tarjeta from TarjetaSocio where Numero_Tarjeta ='" + en.numero + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    en.puntos += points;
                    if (en.puntos <= 10)
                    {
                        en.categoriaTarjeta = "Bronce";
                    }
                    else if (en.puntos > 10 && en.puntos < 20)
                    {
                        en.categoriaTarjeta = "Plata";
                    }
                    else
                    {
                        en.categoriaTarjeta = "Oro";
                    }
                    string update_user = "update TarjetaSocio set Categoria  = '" + en.categoriaTarjeta + "', Puntuacion = " + en.puntos + " where Numero_Tarjeta ='" + en.numero + "'";
                    dr.Close();
                    SqlCommand cmd = new SqlCommand(update_user, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("update Tarjeta operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("update Tarjeta operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool deleteTarjetaSocio(ENTarjetaSocio en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select Numero_Tarjeta from TarjetaSocio where Numero_Tarjeta ='" + en.numero + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    string delete = "delete from TarjetaSocio where Numero_Tarjeta ='" + en.numero + "'";
                    dr.Close();
                    SqlCommand cmd = new SqlCommand(delete, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Delete Tarjeta operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Tarjeta operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

    }
}
