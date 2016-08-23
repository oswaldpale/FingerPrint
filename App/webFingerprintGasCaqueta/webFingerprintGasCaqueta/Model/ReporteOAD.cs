using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace webFingerprintGasCaqueta.Model
{
    public class ReporteOAD
    {
        private Conexion connection = new Conexion();
        #region REPORTES 
        public DataTable reporteControlAsitenciasEmpleados(string fechaInicio, string fechaFin)
        {
            string sql = @"SELECT
                                 e.Cod_empleado as CODIGO,
                                 e.Identificacion as IDENTIFICACION,
                                 CONCAT(e.Nombres, ' ', e.Apellido1, ' ', e.Apellido2) AS EMPLEADO,
                                 DATE_FORMAT(c.circu_fecha, '%Y-%m-%d')                AS FECHA,
                                 TIME_FORMAT(c.circu_horaentrada, '%r')                AS HORAINICIO,
                                 TIME_FORMAT(c.circu_horasalida, '%r')                 AS HORAFIN,
                                 timediff(c.circu_horasalida, c.circu_horaentrada)     AS DURACION,
                                 UPPER(tp.Tipo)                                        AS CARGO
                            FROM
                                control_acceso.circulacion c
                            INNER JOIN control_acceso.empleado e
                            ON
                                c.circu_idusuario = e.Cod_empleado
                            LEFT JOIN sigc972008.tipoempleado tp
                            ON 
                                e.cod_tipo = tp.cod_tipo
                            WHERE
                                DATE_FORMAT(c.circu_fecha, '%Y-%m-%d') BETWEEN DATE_FORMAT('" + fechaInicio + @"', '%Y-%m-%d') AND
                                  DATE_FORMAT('" + fechaFin + "', '%Y-%m-%d') AND c.circu_horasalida IS NOT NULL ";

            return connection.getDataMariaDB(sql).Tables[0];
        }

        public DataTable reporteControlIngresoActual() {
           string sql = @"SELECT
                            u.CODIGO,
                            u.IDENTIFICACION,
                            u.NOMBRE,
                            u.USUARIO,
                            u.TELEFONO,
                            UPPER(IF(u.TIPO = '', 'NO APLICA', u.Tipo)) AS TIPO,
                            TIME_FORMAT(c.circu_horaentrada,'%r') AS HORAENTRADA,
                            CONCAT(area.Area, ' ext:', area.Ext)          AS DEPENDENCIA,
                            c.observacion_visitante AS OBSERVACION
                        FROM
                            (
                                SELECT
                                    e.Cod_empleado                                         AS CODIGO,
                                    e.Identificacion                                       AS IDENTIFICACION,
                                    'EMPLEADO'                                             AS USUARIO,
                                    CONCAT(e.Nombres, ' ', e.Apellido1, ' ', e.Apellido2) AS NOMBRE,
                                    e.telefono  AS TELEFONO,
                                    t.Tipo                                                 AS TIPO
                                FROM
                                    control_acceso.empleado e
                                LEFT JOIN sigc972008.tipoempleado t
                                ON
                                    e.cod_tipo = t.cod_tipo
                                UNION ALL
                                SELECT
                                    v.visi_identificacion                                                AS CODIGO,
                                    v.visi_identificacion                                                AS IDENTIFICACION,
                                    'VISITANTE'                                                          AS USUARIO,
                                    CONCAT(v.visi_nombre, ' ', v.visi_apellido1, ' ', v.visi_apellido2)  AS NOMBRE,
                                    v.visi_telefono                                                      AS TELEFONO,
                                    ''                                                                   AS TIPO
                                FROM
                                    visitante v
                            )
                            u
                        INNER JOIN circulacion c
                        ON
                            u.IDENTIFICACION = c.circu_idusuario
                        LEFT JOIN sigc972008.tb_areatrabajo area
                        ON
                            c.circu_idarea = area.Cod_AreaT
                        WHERE
                            c.circu_fecha = CURDATE()
                        AND c.circu_horasalida IS NULL";

            return connection.getDataMariaDB(sql).Tables[0];
        }
        #endregion
    }
}