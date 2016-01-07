using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class TipoPersonaDal
    {
       

         public DataSet ListaTipoPersona()
        {
            using (MySqlConnection conn = BDconexion.ObtenerConexion())
            {
                using (MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT * FROM tipopersona", conn))
                {
                    DataSet lista = new DataSet();
                    cmd.Fill(lista, "tipopersona");
                    return lista;
                }
            }
        }

    }
}

