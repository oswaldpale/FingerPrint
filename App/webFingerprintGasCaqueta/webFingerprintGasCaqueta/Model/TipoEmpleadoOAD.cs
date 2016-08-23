using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace webFingerprintGasCaqueta.Model
{
    public class TipoEmpleadoOAD
    {
        private Conexion connection = new Conexion();

        public DataTable consultarTipoEmpleado() {

            string sql = @"SELECT
                                cod_tipo AS CODIGO,
                                UPPER(Tipo)     AS CARGO
                            FROM
                                sigc972008.tipoempleado";

            return connection.getDataMariaDB(sql).Tables[0];

        }


    }
}