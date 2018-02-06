using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo3
{
    class ObtenerConexion
    {
        public static MySqlConnection Conexion()
        {
            MySqlConnection conectar = new MySqlConnection("Server=localhost; database=palabrasclave; Uid=root; pwd=;");
            conectar.Open();
            return conectar;
        }
    }
}
