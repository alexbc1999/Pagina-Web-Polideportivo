using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENPista
    {
        private int numero;
        private string deporte;
        private string descripcion;
        private bool cubierta;

        public int numeroPista
        {
            get{
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public string deportePista
        {
            get
            {
                return deporte;
            }

            set
            {
                deporte = value;
            }
        }

        public string descripcionPista
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

        public bool cubiertaPista
        {
            get
            {
                return cubierta;
            }

            set
            {
                cubierta = value;
            }
        }
        public ENPista()
        {

        }

        public ENPista(int numero, string deporte, string descripcion, bool cubierta)
        {
            this.numero = numero;
            this.deporte = deporte;
            this.descripcion = descripcion;
            this.cubierta = cubierta;
        }

        public bool createPista()
        {
            try
            {
                CADPista cAD = new CADPista();
                return cAD.CreatePista(this);
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

        public bool updatePista()
        {
            try
            {
                CADPista cAD = new CADPista();
                return cAD.UpdatePista(this);
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

        public bool deletePista()
        {
            try
            {
                CADPista cAD = new CADPista();
                return cAD.DeletePista(this);
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

        public bool readPista()
        {
            try
            {
                CADPista cAD = new CADPista();
                return cAD.ReadPista(this);
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
