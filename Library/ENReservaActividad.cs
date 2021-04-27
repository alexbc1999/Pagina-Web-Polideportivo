using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENReservaActividad
    {
        private string correo;
        private int actividad;

        //  Getter y Setters de los atributos
        public string Correo
        {
            get;set;
        }
        public int Actividad
        {
            get;set;
        }

        // Constructor y acciones
        public ENReservaActividad()
        {

        }
        public ENReservaActividad (string correo, int actividad)
        {

        }

        public bool createReserva()
        {
            try
            {
                CADReservaActividad r = new CADReservaActividad();
                if (r.createReserva(this))
                {
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool deleteReserva()
        {
            try
            {
                CADReservaActividad r = new CADReservaActividad();
                if (r.deleteReserva(this))
                {
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool updateReserva()
        {
            try
            {
                CADReservaActividad r = new CADReservaActividad();
                if (r.updateReserva(this))
                {
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool readReserva()
        {
            try
            {
                CADReservaActividad r = new CADReservaActividad();
                if (r.readReserva(this))
                {
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
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool tieneReservas()
        {
            try
            {
                CADReservaActividad r = new CADReservaActividad();
                if (r.tieneReservas(this))
                {
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
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool borradoActividadEntera()
        {
            try
            {
                CADReservaActividad r = new CADReservaActividad();
                if (r.borradoActividadEntera(this))
                {
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public int plazasOcupadas()
        {
            try
            {
                CADReservaActividad r = new CADReservaActividad();
                return r.plazasOcupadas(this);
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
