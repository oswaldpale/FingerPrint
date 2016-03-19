using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class HorarioEmpleado
    {
        private Conexion connection = new Conexion();
        public DataTable consultarHorarioporDia(string idempleado, string fechaserver, string diaserver)
        {
            
            string sql = "";
            return connection.getDataMariaDB(sql).Tables[0];
        }

    }
}