using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Library
{
    public class ENNoticia
    {
        private string titulo;
        private string descripcion;
        private string fecha;
        private string autor;

        public string TituloNoticia
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
            }
        }

        public string DescripcionNoticia
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string FechaNoticia
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

        public string AutorNoticia
        {
            get
            {
                return autor;
            }

            set
            {
                autor = value;
            }
        }

        public ENNoticia()
        {

        }

        public ENNoticia(string titulo, string descripcion, string fecha)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha = fecha;
        }

        public bool CreateNoticia()
        {
            try
            {
                CADNoticia cAD = new CADNoticia();
                return cAD.CreateNoticia(this);
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

        public bool UpdateNoticia()
        {
            try
            {
                CADNoticia cAD = new CADNoticia();
                return cAD.UpdateNoticia(this);
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

        public bool DeleteNoticia()
        {
            try
            {
                CADNoticia cAD = new CADNoticia();
                return cAD.DeleteNoticia(this);
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

        public bool ReadNoticia()
        {
            try
            {
                CADNoticia cAD = new CADNoticia();
                return cAD.ReadNoticia(this);
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
