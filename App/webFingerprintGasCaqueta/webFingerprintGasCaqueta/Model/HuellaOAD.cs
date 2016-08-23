using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace webFingerprintGasCaqueta.Model
{
    public class HuellaOAD
    {
        private Conexion connection = new Conexion();
       

        public DataTable consultarHuellaPorUsuario(string filtroUsuario)
        {

            string sql ="SELECT "
                        + "    h.huell_identificacion, "
                        + "    h.huell_huella, "
                        + "    h.huell_dedo "
                        + "FROM "
                        + "    huella h "
                        + "INNER JOIN empleado e "
                        + "ON "
                        + "    h.huell_identificacion = e.Cod_empleado "
                        + "WHERE "
                        + "    e.Identificacion='"+ filtroUsuario + "'";
                  

            return connection.getDataMariaDB(sql).Tables[0];
        }
        // Este metodo lo translado a la Dll por inconventiene en la serializacion de la huella en javascript
        public bool registrarHuella(string primaryKey,string huella, string empleado,string dedo)
        {
         
            string sql = "INSERT "
                        + "INTO "
                        + "    control_acceso.huella "
                        + "    ( "
                        + "        huell_id, "
                        + "        huell_identificacion, "
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

        public bool consultarEstadoHuella(string identificacion, string dedo) {
            string sql = "SELECT "
                        + "    * "
                        + "FROM "
                        + "    huella h "
                        + "WHERE "
                        + "    h.huell_identificacion = '" + identificacion + "' "
                        + "AND h.huell_dedo = '" + dedo + "'";
            return  connection.getDataMariaDB(sql).Tables[0].Rows.Count!=0 ? true : false;
        }

        public bool eliminarHuellaVisitante(string identificacion, string dedo)
        {
            string sql = "DELETE "
                            + "FROM "
                            + "    huella "
                            + "WHERE "
                            + "    huell_identificacion = '" + identificacion + "' "
                            + "AND huell_dedo='" + dedo + "'";
            return connection.sendSetDataMariaDB(sql);
        }
        public bool eliminarHuellaEmpleado(string identificacion, string dedo)
        {
            string sql =  @"DELETE
                                h.*
                            FROM
                                huella h
                            INNER JOIN empleado e
                            ON
                                h.huell_identificacion = e.Cod_empleado
                            WHERE
                                e.Identificacion = '"+ identificacion +@"'
                            AND h.huell_dedo = '" + dedo + @"'";
            return connection.sendSetDataMariaDB(sql);
        }

    }
}