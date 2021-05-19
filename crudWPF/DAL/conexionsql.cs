using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudWPF.DAL
{
    class conexionsql
    {
        private string cadenaconexion;
        MySqlConnection conexion;

        public string SendingData(string sv,string puerto, string user, string passwd, string db)
        {
            this.cadenaconexion = $"server={sv}; port={puerto}; userid={user}; password={passwd}; database={db}";
            return cadenaconexion;
        }

        public MySqlConnection EstablecerConexion()
        {
            this.conexion = new MySqlConnection(this.cadenaconexion);
            return this.conexion;
        }

        public string MostrarDatos()
        {
            return this.cadenaconexion;
        }



        public bool testBD()
        {
            try
            {
                EstablecerConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
