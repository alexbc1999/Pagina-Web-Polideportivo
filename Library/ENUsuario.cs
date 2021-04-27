using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENUsuario
    {
        private string Correo;
        private string Nombre;
        private string Apellidos;
        private int Edad;
        private string Username;
        private string Contrasenya;
        private bool Administrador;
        private ENTarjetaSocio tarjeta;
        

        public string CorreoUsuario
        {
            get
            {
                return Correo;
            }
            set
            {
                Correo = value;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return Nombre;
            }
            set
            {
                Nombre = value;
            }
        }

        public string ApellidosUsuario
        {
            get
            {
                return Apellidos;
            }
            set
            {
                Apellidos = value;
            }
        }

        public int EdadUsuario
        {
            get
            {
                return Edad;
            }
            set
            {
                Edad = value;
            }
        }

        public string usuario
        {
            get
            {
                return Username;
            }
            set
            {
               Username = value;
            }
        }

        public string ContrasenaUsuario
        {
            get
            {
                return Contrasenya;
            }
            set
            {
                Contrasenya = value;
            }
        }

        public bool admin
        {
            get
            {
                return Administrador;
            }
            set
            {
                Administrador = value;
            }
        }

        public int numeroTarjeta
        {
            get
            {
                return tarjeta.numero;
            }
            set
            {
                tarjeta.numero = value;
            }
        }
        
        public ENTarjetaSocio tarjetaSocio
        {
            get
            {
                return tarjeta;
            }
        }
        

        public ENUsuario() {
            tarjeta = new ENTarjetaSocio();
            Administrador = false;
        }

        public ENUsuario(string correo, string nombre, string apellidos, string username, string contrasena, int edad)
        {
            this.Correo = correo;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Username = username;
            this.Contrasenya = contrasena;
            this.Edad = edad;
            Administrador = false;
            tarjeta = new ENTarjetaSocio();
        }

        public bool createUsuario()
        {
            CADUsuario us = new CADUsuario();
            try
            {
                return us.createUsuario(this);
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
         public bool readUsuario()
        {
            CADUsuario us = new CADUsuario();
            try
            {
                if (us.readUsuario(this))
                {
                    ENTarjetaSocio n = new ENTarjetaSocio();
                    n.numero = this.numeroTarjeta;
                    n.readTarjetaSocio();
                    this.tarjeta.categoriaTarjeta = n.categoriaTarjeta;
                    this.tarjeta.puntos = n.puntos;
                    return true;
                }
                else
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

        public bool getCorreo()
        {
            CADUsuario us = new CADUsuario();
            try
            {
                if (us.getCorreo(this))
                {
                    ENTarjetaSocio n = new ENTarjetaSocio();
                    n.numero = this.numeroTarjeta;
                    n.readTarjetaSocio();
                    this.tarjeta.categoriaTarjeta = n.categoriaTarjeta;
                    this.tarjeta.puntos = n.puntos;
                    return true;
                }
                else
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

        public bool checkUsuario(string s)
        {
            CADUsuario us = new CADUsuario();
            try
            {
                return us.checkUsuario(this, s);
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

        public bool updateUsuario()
        {
            CADUsuario us = new CADUsuario();
            try
            {
                return us.updateUsuario(this);
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

        public bool updatePassword(string pass)
        {
            CADUsuario us = new CADUsuario();
            try
            {
                return us.updatePassword(this, pass);
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

        public bool deleteUsuario()
        {
            CADUsuario us = new CADUsuario();
            try
            {
                return us.deleteUsuario(this);
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
