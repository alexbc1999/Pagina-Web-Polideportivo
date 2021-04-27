using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENReservaPista
    {
        private int numero;
        private string fecha;
        private string estado;
        private string hora;

        public int NumeroReserva
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public string FechaReserva
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string EstadoReserva
        {
            get
            {
                return estado;
            }

            set
            {
               estado = value;
            }
        }

        public string HoraReserva
        {
            get
            {
                return hora;
            }

            set
            {
                hora = value;
            }
        }
        public ENReservaPista()
        {

        }

        public ENReservaPista(int numeroreserva, string fechareserva, string estado, string horareserva)
        {
            this.numero = numeroreserva;
            this.fecha = fechareserva;
            this.estado = estado;
            this.hora = horareserva;
        }

        public bool CreateReserva(string correo, int numeropista, string deporte)
        {
            try
            {
                CADReservaPista cAD = new CADReservaPista();
                return cAD.CreateReserva(this, correo, numeropista, deporte);
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

        public bool UpdateReserva(string correo, int numeropista, string deporte)
        {
            try
            {
                CADReservaPista cAD = new CADReservaPista();
                return cAD.UpdateReserva(this, correo, numeropista, deporte);
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

        public bool DeleteReserva()
        {
            try
            {
                CADReservaPista cAD = new CADReservaPista();
                return cAD.DeleteReserva(this);
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

        public bool ReadReserva()
        {
            try
            {
                CADReservaPista cAD = new CADReservaPista();
                return cAD.ReadReserva(this);
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

        public bool ObtenerEstado(string deporte,string hora, string fecha, int numeropista)
        {
            try
            {
                CADReservaPista cAD = new CADReservaPista();
                return cAD.ObtenerEstado(this, deporte, hora, fecha, numeropista);
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

        public bool ObtenerFecha(string hora, string fecha)
        {
            try
            {
                CADReservaPista cAD = new CADReservaPista();
                return cAD.ObtenerFecha(this, hora, fecha);
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

        public string ObtenerDeporte(string deporte, int numeropista)
        {
            try
            {
                CADReservaPista cAD = new CADReservaPista();
                return cAD.ObtenerDeporte(this, deporte, numeropista);
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

        public int ObtenerNumPista(int numeropista, int numero)
        {
            try
            {
                CADReservaPista cAD = new CADReservaPista();
                return cAD.ObtenerNumPista(this,numeropista, numero);
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

    }
}
