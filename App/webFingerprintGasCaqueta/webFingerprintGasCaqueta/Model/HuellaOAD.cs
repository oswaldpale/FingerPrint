using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class HuellaOAD
    {
        private Conexion connection = new Conexion();
       

        public DataTable consultarHuella(string filtroUsuario)
        {

            string sql = "SELECT "
                        + "    V.VEHI_ID, "
                        + "    V.VEHI_PLACA, "
                        + "    V.VEHI_MARCA, "
                        + "    V.VEHI_MODELO, "
                        + "    V.VEHI_OBSERVACION "
                        + "FROM "
                        + "    BOOTPARK.AUTORIZACION A "
                        + "INNER JOIN BOOTPARK.VEHICULO V "
                        + "ON "
                        + "    ( "
                        + "        A.VEHI_ID=V.VEHI_ID "
                        + "    ) "
                        + " WHERE A.USUA_ID='" + filtroUsuario + "'";
                  

            return connection.getDataMariaDB(sql).Tables[0];
        }

        public bool registrarHuella(string primaryKey,string huella, string empleado,string dedo)
        {
            string sql = "INSERT "
                        + "INTO "
                        + "    control_acceso.huella "
                        + "    ( "
                        + "        huell_id, "
                        + "        emple_codempleado, "
                        + "        huell_huella,"
                        + "        huell_dedo"
                        + "    ) "
                        + "    VALUES "
                        + "    ( "
                        + "        '" + primaryKey + "', "
                        + "        '" + empleado + "', "
                        + "        '" + huella + "', "
                        + "        '" + dedo + "' "
                        + "    )";

            return connection.sendSetDataMariaDB(sql);
        }
        public bool eliminarHuella(string idhuella)
        {
            string sql = "DELETE "
                         + "FROM "
                         + "    BOOTPARK.AUTORIZACION "
                         + "WHERE "
                         + "    USUA_ID ='" + idhuella + "' ";
                        
            return connection.sendSetDataMariaDB(sql);
        }
    }
}