using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    public class CADNoticia
    {

        private string constring = ConfigurationManager.ConnectionStrings["conexion_PolideportivoMDA"].ToString();

        public CADNoticia()
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

        public bool CreateNoticia(ENNoticia en)
        {
            bool create = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();

                String select_titulo = "select titulo from Noticia where titulo = '" + en.TituloNoticia + "'";
                SqlCommand cmd_select = new SqlCommand(select_titulo, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();
                if (dr.Read() == false)
                {
                    dr.Close();
                    string insert_noticia = "Insert Into Noticia(titulo, descripcion, fecha, autor) VALUES ('" + en.TituloNoticia + "','" + en.DescripcionNoticia + "','" + en.FechaNoticia + "','" + en.AutorNoticia + "')";
                    SqlCommand cmd = new SqlCommand(insert_noticia, conn);
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

        public bool DeleteNoticia(ENNoticia en)
        {
            bool delete = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_all = "select * from Noticia where titulo = '" + en.TituloNoticia + "'";
                SqlCommand cmd_select = new SqlCommand(select_all, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read() == true)
                {
                    dr.Close();
                    string delete_user = "Delete from Noticia where titulo = '" + en.TituloNoticia + "'";
                    SqlCommand cmd = new SqlCommand(delete_user, conn);
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

        public bool UpdateNoticia(ENNoticia en)
        {
            bool update = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_all = "select * from Noticia where titulo = '" + en.TituloNoticia + "'";
                SqlCommand cmd_select = new SqlCommand(select_all, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read() == true)
                {
                    dr.Close();
                    string update_noticia = "Update Noticia SET descripcion = @descripcionNoticia, fecha = @fechaNoticia, autor = @autorNoticia where titulo = @tituloNoticia";
                    SqlCommand cmd = new SqlCommand(update_noticia, conn);
                    cmd.Parameters.AddWithValue("@tituloNoticia", en.TituloNoticia);
                    cmd.Parameters.AddWithValue("@descripcionNoticia", en.DescripcionNoticia);
                    cmd.Parameters.AddWithValue("@fechaNoticia", en.FechaNoticia);
                    cmd.Parameters.AddWithValue("@autorNoticia", en.AutorNoticia);
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

        public bool ReadNoticia(ENNoticia en)
        {
            bool read = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_all = "select * from Noticia where titulo = '" + en.TituloNoticia + "'";
                SqlCommand cmd_select = new SqlCommand(select_all, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read())
                {
                    en.DescripcionNoticia = dr.GetString(1);
                    en.FechaNoticia = dr.GetString(2);
                    en.AutorNoticia = dr.GetString(3);
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
