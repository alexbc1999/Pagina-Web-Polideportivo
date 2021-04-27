using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENAdministrador: ENUsuario
    {
        private string Departamento;

        public string depart
        {
            get
            {
                return Departamento;
            } 
            set
            {
                Departamento = value;
            }
        }

        public ENAdministrador() {
            this.admin = true;
        }

        public ENAdministrador(string dep)
        {
            Departamento = dep;
            this.admin = true;
        }

        public bool createAdmin()
        {
            CADAdministrador ad = new CADAdministrador();
            try
            {
                if (ad.createAdmin(this))
                {
                    return ad.changetoAdmin(this);
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

        public bool readAdmin()
        {
            CADAdministrador ad = new CADAdministrador();
            try
            {
                return ad.readAdmin(this);
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

        public bool updateAdmin()
        {
            CADAdministrador ad = new CADAdministrador();
            try
            {
                this.updateUsuario();
                return ad.updateAdmin(this);
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
        
        public bool deleteAdmin()
        {
            CADAdministrador ad = new CADAdministrador();
            try
            {
                if(ad.deleteAdmin(this))
                {
                    return ad.changetoAdmin(this);
                }
                return false;
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
