using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class EmpleadoOAD
    {
        private Conexion connection = new Conexion();
        public DataTable consultarEmpleados() {
            string sql = @"SELECT
                            e.Cod_empleado                                         AS MCODIGO,
                            e.Identificacion                                       AS MIDENTIFICACION,
                            CONCAT(e.Nombres, ' ', e.Apellido1 , ' ', e.Apellido2) AS MNOMBRE ,
                            UPPER(t.Tipo)                                          AS MTIPO,
                            IF (
                            (
                                SELECT
                                    COUNT(h.huell_identificacion)
                                FROM
                                    huella h
                                WHERE
                                    h.huell_identificacion = e.Cod_empleado
                                AND h.huell_dedo='Primario'
                            )
                            !=0, 'true', 'false') AS EXISTHUEPRIMARY,
                            IF(
                            (
                                SELECT
                                    COUNT(h.huell_identificacion)
                                FROM
                                    huella h
                                WHERE
                                    h.huell_identificacion = e.Cod_empleado
                                AND h.huell_dedo='Secundario'
                            )
                            !=0,'true','false') AS EXISTHUESECOND
                        FROM
                            control_acceso.empleado e
                        INNER JOIN sigc972008.tipoempleado t
                        ON
                            e.cod_tipo = t.cod_tipo
                        WHERE
                            e.Eliminado= 0";
            return  connection.getDataMariaDB(sql).Tables[0];
        }
    }
}