using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class VisitanteCOD
    {
        private Conexion connection = new Conexion();
        public bool registrarVisitante(string identificacion, string nombre, string apellido1, string apellido2, string observacion, string foto)
        {
            string sql = "INSERT "
                            + "INTO "
                            + "    visitante "
                            + "    ( "
                            + "        visi_identificacion, "
                            + "        visi_nombre, "
                            + "        visi_apellido1, "
                            + "        visi_apellido2, "
                            + "        visi_observacion, "
                            + "        visi_foto "
                            + "    ) "
                            + "    VALUES "
                            + "    ( "
                            + "        " + identificacion + ", "
                            + "        '" + nombre + "', "
                            + "        '" + apellido1 + "', "
                            + "        '" + apellido2 + "', "
                            + "        '" + observacion + "', "
                            + "        '" + foto + "' "
                            + "    )";
            return connection.sendSetDataMariaDB(sql);
        }
        public DataTable consultarVisitantes() {
            string sql = "SELECT "
                            + "    v.visi_identificacion                                                AS IDENTIFICACION, "
                            + "    CONCAT(v.visi_nombre, ' ', v.visi_apellido1 , ' ', v.visi_apellido2) AS NOMBRE , "
                            + "    v.visi_observacion                                                   AS OBSERVACION, "
                            + "    IF( "
                            + "    ( "
                            + "        SELECT "
                            + "            COUNT(h.huell_identificacion) "
                            + "        FROM "
                            + "            huella h "
                            + "        WHERE "
                            + "            h.huell_identificacion = v.visi_identificacion "
                            + "        AND h.huell_dedo='Primario' "
                            + "    ) "
                            + "    !=0,'true','false') AS EXISTHUEPRIMARY, "
                            + "    IF( "
                            + "    ( "
                            + "        SELECT "
                            + "            COUNT(h.huell_identificacion) "
                            + "        FROM "
                            + "            huella h "
                            + "        WHERE "
                            + "            h.huell_identificacion = v.visi_identificacion "
                            + "        AND h.huell_dedo='Secundario' "
                            + "    ) "
                            + "    !=0,'true','false') AS EXISTHUESECOND "
                            + "FROM "
                            + "    visitante v";
            return connection.getDataMariaDB(sql).Tables[0];

        }
        public bool consultarSiExisteVisitante(string identificacion) {
            string sql = "SELECT "
                            + "   * "
                            + "FROM "
                            + "    (( "
                            + "        SELECT "
                            + "            e.Identificacion AS IDENTIFICACION "
                            + "        FROM "
                            + "            empleado e "
                            + "    ) "
                            + "UNION ALL "
                            + "    ( "
                            + "        SELECT "
                            + "            v.visi_identificacion AS IDENTIFICACION "
                            + "        FROM "
                            + "            visitante v "
                            + "    )) AS u "
                            + "WHERE "
                            + "    u.IDENTIFICACION ='" + identificacion + "'";
            return connection.getDataMariaDB(sql).Tables[0].Rows.Count != 0 ? true : false;
        }
    }
}