using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CADPista
    {
        private string constring = ConfigurationManager.ConnectionStrings["conexion_PolideportivoMDA"].ToString();

        public CADPista()
        {
            SqlConnection conn = null;
            conn = new SqlConnection(constring);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("¡¡¡Excepcion!!!  --> " + ex);
                throw ex;
            }
            finally { if (conn != null) conn.Close(); }
        }

        public bool CreatePista(ENPista en)
        {
            bool create = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();

                String select_pista = "select * from Pista where NumeroPista = '" + en.numeroPista + "' AND Deporte = '" + en.deportePista + "'";
                SqlCommand cmd_select = new SqlCommand(select_pista, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();
                if (dr.Read() == false)
                {
                    dr.Close();
                    string insert_pista = "Insert Into Pista(numeropista, deporte, descripcion, cubierta) VALUES ('" + en.numeroPista + "','" + en.deportePista + "','" + en.descripcionPista + "','" + en.cubiertaPista + "')";
                    SqlCommand cmd = new SqlCommand(insert_pista, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    create = false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("¡¡¡Excepcion de SQL!!! --> " + sqlex);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("¡¡¡Excepcion!!!  --> " + ex);
                throw ex;
            }
            finally { if (conn != null) conn.Close(); }

            return create;
        }

        public bool UpdatePista(ENPista en)
        {
            bool update = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_all = "select * from Pista where numeropista = '" + en.numeroPista + "' AND Deporte = '" + en.deportePista + "'";
                SqlCommand cmd_select = new SqlCommand(select_all, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read() == true)
                {
                    dr.Close();
                    string update_pista = "Update Pista SET descripcion = @descripcionPista, cubierta = @cubiertaPista where numeropista = @numeroPista and deporte = @deportePista";
                    SqlCommand cmd = new SqlCommand(update_pista, conn);
                    cmd.Parameters.AddWithValue("@numeroPista", en.numeroPista);
                    cmd.Parameters.AddWithValue("@deportePista", en.deportePista);
                    cmd.Parameters.AddWithValue("@descripcionPista", en.descripcionPista);
                    cmd.Parameters.AddWithValue("@cubiertaPista", en.cubiertaPista);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    update = false;
                }

            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("¡¡¡Excepcion de SQL!!! --> " + sqlex);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("¡¡¡Excepcion!!!  --> " + ex);
                throw ex;
            }
            finally { if (conn != null) conn.Close(); }


            return update;
        }

        public bool DeletePista(ENPista en)
        {
            bool delete = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_all = "select * from Pista where numeropista = '" + en.numeroPista + "' AND Deporte = '" + en.deportePista + "'";
                SqlCommand cmd_select = new SqlCommand(select_all, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read() == true)
                {
                    dr.Close();
                    string delete_pista = "Delete from Pista where numeropista = '" + en.numeroPista + "' AND deporte = '" + en.deportePista + "'";
                    SqlCommand cmd = new SqlCommand(delete_pista, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    delete = false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("¡¡¡Excepcion de SQL!!! --> " + sqlex);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("¡¡¡Excepcion!!!  --> " + ex);
                throw ex;
            }
            finally { if (conn != null) conn.Close(); }


            return delete;
        }

        public bool ReadPista(ENPista en)
        {
            bool read = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_all = "select * from Pista where numeropista = '" + en.numeroPista + "' AND Deporte = '" + en.deportePista + "'";
                SqlCommand cmd_select = new SqlCommand(select_all, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read())
                {
                    en.descripcionPista = dr.GetString(2);
                    en.cubiertaPista = dr.GetBoolean(3);
                    dr.Close();
                }
                else
                {
                    read = false;
                }

            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("¡¡¡Excepcion de SQL!!! --> " + sqlex);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("¡¡¡Excepcion!!!  --> " + ex);
                throw ex;
            }
            finally { if (conn != null) conn.Close(); }

            return read;
        }
    }
}
