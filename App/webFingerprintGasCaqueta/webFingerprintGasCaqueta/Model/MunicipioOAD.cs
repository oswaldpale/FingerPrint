using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace webFingerprintGasCaqueta.Model
{
    public class MunicipioOAD
    {
        private Conexion connection = new Conexion();
       
        public DataTable consultarMunicipio() {
            string sql = @"SELECT
                            Cod_Muni AS CODIGO,
                            Municipio AS DESTINO
                        FROM
                            sigc972008.municipio";
            return connection.getDataMariaDB(sql).Tables[0];
        }
    }
}