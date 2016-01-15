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
            MySqlConnection conectar = new MySqlConnection("server=192.168.0.91; database=control_acceso; Uid=planta; pwd=planta123;");
            conectar.Open();
            return conectar;
        }
    }
}
