using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class SemanaOAD
    {
        private Conexion connection = new Conexion();
        public DataTable consultarSemana()
        {
            string sql = @"SELECT
                            sema_id AS ID,
                            sema_dia AS DIA
                        FROM
                            semana";
            return connection.getDataMariaDB(sql).Tables[0];
        }
    }
}