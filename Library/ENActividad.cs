using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENActividad
    {
        private int index;
        private string nombre;
        private string descripcion;
        private int maxPersonas;
        private string profesor;
        private string fecha;
        private string hora;

        //  Getter y Setters de los atributos
        public int Index
        {
            get;set;
        }
        public string Nombre
        {
            get; set;
        }
        public string Descripcion
        {
            get; set;
        }
        public string Hora
        {
            get; set;
        }
        public string Fecha
        {
            get; set;
        }
        public int MaxPersonas
        {
            get;set;
        }
        public string Profesor
        {
            get;set;
        }

        // Constructor y acciones
        public ENActividad()
        {

        }

        public ENActividad(string nombre, string descripcion, int MaxPersonas, string Profesor, string Fecha, string Hora)
        {

        }

        public bool createActividad()
        {
            try
            {
                CADActividad r = new CADActividad();
                if (r.createActividad(this))
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

        public bool deleteActividad()
        {
            try
            {
                CADActividad r = new CADActividad();
                if (r.deleteActividad(this))
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

        public bool updateActividad()
        {
            try
            {
                CADActividad r = new CADActividad();
                if (r.updateActividad(this))
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

        public bool readActividad()
        {
            try
            {
                CADActividad r = new CADActividad();
                if (r.readActividad(this))
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

        
    }
}
