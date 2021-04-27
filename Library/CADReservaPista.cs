using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CADReservaPista
    {
        private string constring = ConfigurationManager.ConnectionStrings["conexion_PolideportivoMDA"].ToString();

        public CADReservaPista()
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

        public int obtenerNumero(string hora, string deporte, string fecha, int pista)
        {
            int n = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(constring);
            conn.Open();
            String select_numero = "select numero from ReservaPista where HoraReserva = '" + hora + "' and Deporte = '" + deporte + "' and FechaReserva = '" + fecha + "' and NumeroPista = '" + pista + "'";
            SqlCommand cmd = new SqlCommand(select_numero, conn);
            SqlDataReader dr2 = cmd.ExecuteReader();
            
            if (dr2.Read() == true)
            {
                n = dr2.GetInt32(0);
                dr2.Close();
                return n;
            }
            else return n;
        }
        public bool CreateReserva(ENReservaPista en, string correo, int numeropista, string deporte)
        {
            bool create = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try { 
                conn.Open();
                String select_reserva = "select * from ReservaPista where HoraReserva = '" + en.HoraReserva + "' and Deporte = '" + deporte + "' and FechaReserva = '" + en.FechaReserva + "' and NumeroPista = '" + numeropista + "'";
                SqlCommand cmd_select = new SqlCommand(select_reserva, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read() == false)
                {
                    dr.Close();
                    en.EstadoReserva = "Ocupado";
                    string insert_reserva = "Insert Into ReservaPista(horareserva, fechareserva, estado, correo, numeropista, deporte) VALUES ('" + en.HoraReserva + "','" + en.FechaReserva + "','" + en.EstadoReserva + "','" + correo + "','" + numeropista + "','" + deporte + "')";
                    SqlCommand cmd = new SqlCommand(insert_reserva, conn);
                    
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

        public bool UpdateReserva(ENReservaPista en, string correo, int numeropista, string deporte)
        {
            bool update = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_reserva = "select * from ReservaPista where Numero = '" + en.NumeroReserva + "' and Correo = '" + correo + "'"; 
                SqlCommand cmd_select = new SqlCommand(select_reserva, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read() == true)
                {
                    dr.Close();
                    string update_pista = "Update ReservaPista SET HoraReserva = @HoraReserva, FechaReserva = @FechaReserva, Correo = @CorreoUsuario, NumeroPista = @NumeroPista, Deporte = @DeportePista where Numero = @NumeroReserva";
                    SqlCommand cmd = new SqlCommand(update_pista, conn);
                    cmd.Parameters.AddWithValue("@NumeroReserva", en.NumeroReserva);
                    cmd.Parameters.AddWithValue("@HoraReserva", en.HoraReserva);
                    cmd.Parameters.AddWithValue("@FechaReserva", en.FechaReserva);
                    cmd.Parameters.AddWithValue("@CorreoUsuario", correo);
                    cmd.Parameters.AddWithValue("@NumeroPista", numeropista);
                    cmd.Parameters.AddWithValue("@DeportePista", deporte);
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

        public bool DeleteReserva(ENReservaPista en)
        {
            bool delete = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_reserva = "select * from ReservaPista where Numero = '" + en.NumeroReserva + "'";
                SqlCommand cmd_select = new SqlCommand(select_reserva, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read() == true)
                {
                    dr.Close();
                    string delete_reserva = "Delete from ReservaPista where Numero = '" + en.NumeroReserva + "'";
                    SqlCommand cmd = new SqlCommand(delete_reserva, conn);
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

        public bool ReadReserva(ENReservaPista en)
        {
            bool read = true;
            SqlConnection conn;
            conn = new SqlConnection(constring);
           
            try
            {
                conn.Open();
                String select_reserva = "select * from ReservaPista where Numero = '" + en.NumeroReserva + "'";
                SqlCommand cmd_select = new SqlCommand(select_reserva, conn);
                SqlDataReader dr = cmd_select.ExecuteReader();

                if (dr.Read())
                {
                    en.HoraReserva = dr.GetString(1);
                    en.FechaReserva = dr.GetString(2);
                    en.EstadoReserva = dr.GetString(3);
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

        public bool ObtenerEstado(ENReservaPista en, string deporte, string hora, string fecha, int pista)
        {
            bool estado = false;
            SqlConnection conn = null;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_numero = "select estado from ReservaPista where HoraReserva = '" + hora + "' and Deporte = '" + deporte + "' and FechaReserva = '" + fecha + "' and NumeroPista = '" + pista + "'";
                SqlCommand cmd = new SqlCommand(select_numero, conn);
                SqlDataReader dr2 = cmd.ExecuteReader();

                if (dr2.Read() == true)
                {
                    estado = true;
                    dr2.Close();
                    return estado;
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
            return estado;
        }

        public bool ObtenerFecha(ENReservaPista en, string hora, string fecha)
        {
            bool estado = false;
            SqlConnection conn = null;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_estado = "select estado from ReservaPista where HoraReserva = '" + hora +  "' and FechaReserva = '" + fecha + "'";
                SqlCommand cmd = new SqlCommand(select_estado, conn);
                SqlDataReader dr2 = cmd.ExecuteReader();

                if (dr2.Read() == true)
                {
                    estado = true;
                    dr2.Close();
                    return estado;
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
            return estado;
        }

        public string ObtenerDeporte(ENReservaPista en, string deporte, int numero)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_numero = "select Deporte from ReservaPista where Numero = '" + numero + "'";
                SqlCommand cmd = new SqlCommand(select_numero, conn);
                SqlDataReader dr2 = cmd.ExecuteReader();

                if (dr2.Read() == true)
                {
                    deporte = dr2.GetString(0);
                    dr2.Close();
                    return deporte;
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
            return deporte;
        }



        public int ObtenerNumPista(ENReservaPista en, int numeropista, int numero)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                String select_numero = "select NumeroPista from ReservaPista where Numero = '" + numero + "'";
                SqlCommand cmd = new SqlCommand(select_numero, conn);
                SqlDataReader dr2 = cmd.ExecuteReader();

                if (dr2.Read() == true)
                {
                    numeropista = dr2.GetInt32(0);
                    dr2.Close();
                    return numeropista;
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
            return numeropista;
        }
    }
}
