using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENTarjetaSocio
    {
        private int numeroTarjeta;
        private string categoria;
        private int puntuacion;

        public int numero
        {
            get
            {
                return numeroTarjeta;
            }
            set
            {
                numeroTarjeta = value;
            }
        }

        public string categoriaTarjeta
        {
            get
            {
                return categoria;
            }
            set
            {
                categoria = value;
            }
        }

        public int puntos
        {
            get
            {
                return puntuacion;
            }
            set
            {
                puntuacion = value;
            }
        }

        public ENTarjetaSocio() {
            CADTarjetaSocio ts = new CADTarjetaSocio();
            int numero_anterior = ts.getNumero();
            numero_anterior++;
            numeroTarjeta = numero_anterior;
            categoria = "Bronce";
            puntuacion = 0;
            
        }

        public bool createTarjetaSocio()
        {
            CADTarjetaSocio ts = new CADTarjetaSocio();
            try
            {
                return ts.createTarjetaSocio(this);
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
        
        public bool readTarjetaSocio()
        {
            CADTarjetaSocio ts = new CADTarjetaSocio();
            try
            {
                return ts.readTarjetaSocio(this);
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

        public bool updateTarjetaSocio(int points)
        {
            CADTarjetaSocio ts = new CADTarjetaSocio();
            try
            {
                return ts.updateTarjeta(this, points);
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

        public bool deleteTarjetaSocio()
        {
            CADTarjetaSocio ts = new CADTarjetaSocio();
            try
            {
                return ts.deleteTarjetaSocio(this);
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
