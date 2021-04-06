using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class conexion
    {
        public static MySqlConnection Conexion()
        {
            string servidor = "localhost";
            string bd = "dual";
            string usuario = "root";
            string pass = "Mariogerman9";

            string cadenaConexion = "Database= " + bd + "; Data Source=" + servidor + "; User Id= " + usuario + "; Password=" + pass + "";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
