using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace webFingerprintGasCaqueta.Model
{
    public class CargoOAD
    {
        private Conexion connection = new Conexion();
        public DataTable consultarCargo()
        {
            string sql = @"SELECT
                                codigo AS CODIGO,
                                cargo AS CENTROCOSTO
                            FROM
                                sigc972008.tb_cargo";

            return connection.getDataMariaDB(sql).Tables[0];
        }
    }
}