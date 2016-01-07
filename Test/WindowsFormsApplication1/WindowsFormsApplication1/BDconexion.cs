using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    class BDconexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=parqueadero; Uid=root; pwd=root;");
            conectar.Open();
            return conectar;
        }
    }
}
