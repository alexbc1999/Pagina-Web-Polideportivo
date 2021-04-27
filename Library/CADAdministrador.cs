using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CADAdministrador
    {
        private string constring = ConfigurationManager.ConnectionStrings["conexion_PolideportivoMDA"].ToString();

        public CADAdministrador() { }

        public bool createAdmin(ENAdministrador en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select * from Admin where Correo = '" + en.CorreoUsuario + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read() == false)
                {
                    string insert_user = "Insert into Admin(Correo,Departamento) " +
                        "values ('" + en.CorreoUsuario + "','" + en.depart + "')";
                    dr.Close();
                    SqlCommand cmd = new SqlCommand(insert_user, conn);
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
                Console.WriteLine("Admin creation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Admin creation has failed.Error: { 0}", ex.Message);
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

        public bool changetoAdmin(ENAdministrador en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select * from Usuario where Correo ='" + en.CorreoUsuario + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    string update_user = "update Usuario set Administrador = '" + en.admin + "' where Correo ='" + en.CorreoUsuario + "'";
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
                Console.WriteLine("Admin operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Admin operation has failed.Error: { 0}", ex.Message);
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

        public bool readAdmin(ENAdministrador en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select * from Admin where Correo ='" + en.CorreoUsuario + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    en.CorreoUsuario = dr["Correo"].ToString();
                    en.depart = dr["Departamento"].ToString();
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
                Console.WriteLine("Admin operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Admin operation has failed.Error: { 0}", ex.Message);
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

        public bool updateAdmin(ENAdministrador en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select Correo from Admin where Correo ='" + en.CorreoUsuario + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    string update_user = "update Admin set Departamento = '" + en.depart + "' where Correo ='" + en.CorreoUsuario + "'";
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
                Console.WriteLine("Update admin operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update admin operation has failed.Error: { 0}", ex.Message);
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

        public bool deleteAdmin(ENAdministrador en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select Correo from Admin where Correo ='" + en.CorreoUsuario + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    string delete_user = "delete from Admin where Correo ='" + en.CorreoUsuario + "'";
                    dr.Close();
                    SqlCommand cmd = new SqlCommand(delete_user, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Update admin operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update admin operation has failed.Error: { 0}", ex.Message);
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
