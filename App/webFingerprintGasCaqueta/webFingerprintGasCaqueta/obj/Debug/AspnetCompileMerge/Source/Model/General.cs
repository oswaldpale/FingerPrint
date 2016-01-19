using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Controller
{
    public class General
    {
        private Conexion connection = new Conexion();

        public string nextPrimaryKey(string TABLA, string TABL_ID)
        {
         
            string sql = " SELECT"
                         + "    COALESCE(MAX(E." + TABL_ID + "), 0) + 1 AS PK"
                         + " FROM "
                         + TABLA + " E";
            return connection.getDataMariaDB(sql).Tables[0].Rows[0]["PK"].ToString();
        }
    }
}