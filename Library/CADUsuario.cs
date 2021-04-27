using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CADUsuario
    {
        private string constring = ConfigurationManager.ConnectionStrings["conexion_PolideportivoMDA"].ToString();

        public CADUsuario()
        {
        }
        public bool createUsuario(ENUsuario en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select * from Usuario where Correo = '" + en.CorreoUsuario + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read() == false)
                {

                    string insert_user = "Insert into Usuario(Correo,Nombre,Apellidos,Username,Contrasenya,Edad,Administrador,Numero_Tarjeta) " +
                        "values ('" + en.CorreoUsuario + "','" + en.NombreUsuario + "','" + en.ApellidosUsuario + "','" + en.usuario + "','" + en.ContrasenaUsuario + "','" + en.EdadUsuario + "','" + en.admin + "','" + en.numeroTarjeta + "')";
                    dr.Close();
                    SqlCommand cmd = new SqlCommand(insert_user, conn);
                    en.tarjetaSocio.createTarjetaSocio();
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("User creation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User creation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return true;
        }

        public bool readUsuario(ENUsuario en)
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

                    en.NombreUsuario = dr["Nombre"].ToString();
                    en.ApellidosUsuario = dr["Apellidos"].ToString();
                    en.EdadUsuario = int.Parse(dr["Edad"].ToString());
                    en.usuario = dr["Username"].ToString();
                    en.ContrasenaUsuario = dr["Contrasenya"].ToString();
                    en.admin = bool.Parse(dr["Administrador"].ToString());
                    en.numeroTarjeta = int.Parse(dr["Numero_Tarjeta"].ToString());
                    
                    dr.Close();

                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return true;
        }
        public bool getCorreo(ENUsuario en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select * from Usuario where Username ='" + en.usuario + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    en.CorreoUsuario = dr["Correo"].ToString();
                    en.NombreUsuario = dr["Nombre"].ToString();
                    en.ApellidosUsuario = dr["Apellidos"].ToString();
                    en.EdadUsuario = int.Parse(dr["Edad"].ToString());
                    en.ContrasenaUsuario = dr["Contrasenya"].ToString();
                    en.admin = bool.Parse(dr["Administrador"].ToString());
                    en.numeroTarjeta = int.Parse(dr["Numero_Tarjeta"].ToString());
                    dr.Close();
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return true;
        }

        public bool checkUsuario(ENUsuario en, string contrasena)
        {
            try
            {
                if(readUsuario(en))
                {
                    if (en.ContrasenaUsuario.Equals(contrasena))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateUsuario(ENUsuario en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select Correo from Usuario where Correo ='" + en.CorreoUsuario + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    string update_user = "update Usuario set Nombre = '" + en.NombreUsuario + "', Apellidos = '" + en.ApellidosUsuario + "', Edad = '" + en.EdadUsuario + "' where Correo ='" + en.CorreoUsuario + "'";
                    dr.Close();
                    SqlCommand cmd = new SqlCommand(update_user, conn);
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return true;
        }

        public bool updatePassword(ENUsuario en, string newpass)
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
                    string comprobarcontrasena;
                    comprobarcontrasena = dr["Contrasenya"].ToString();
                    if (en.ContrasenaUsuario.Equals(comprobarcontrasena))
                    {
                        string update_user = "update Usuario set Contrasenya = '" + newpass + "' where Correo ='" + en.CorreoUsuario + "'";
                        dr.Close();
                        SqlCommand cmd = new SqlCommand(update_user, conn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return true;
        }
        
        public bool deleteUsuario(ENUsuario en)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                string search = "select Correo from Usuario where Correo ='" + en.CorreoUsuario + "'";
                SqlCommand sea = new SqlCommand(search, conn);
                SqlDataReader dr = sea.ExecuteReader();
                if (dr.Read())
                {
                    string delete_user = "delete from Usuario where Correo ='" + en.CorreoUsuario + "'";
                    dr.Close();
                    SqlCommand cmd = new SqlCommand(delete_user, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", sqlex.Message);
                throw sqlex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            try
            {
                en.tarjetaSocio.deleteTarjetaSocio();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
