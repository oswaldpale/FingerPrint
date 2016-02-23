using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

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
                                 DATE_FORMAT(c.circu_fecha, '%Y-%m-%d') AS FECHA,
                                 TIME_FORMAT(c.circu_horaentrada, '%r')                  AS HORAINICIO,
                                 TIME_FORMAT(c.circu_horasalida, '%r')                   AS HORAFIN,
                                 timediff(c.circu_horasalida, c.circu_horaentrada)      AS DURACION
                            FROM
                                control_acceso.circulacion c
                            INNER JOIN control_acceso.empleado e
                            ON
                                c.circu_idusuario = e.Cod_empleado
                            WHERE
                                DATE_FORMAT(c.circu_fecha, '%Y-%m-%d') BETWEEN DATE_FORMAT('" + fechaInicio + @"', '%Y-%m-%d') AND
                                  DATE_FORMAT('" + fechaFin + "', '%Y-%m-%d')";
            return connection.getDataMariaDB(sql).Tables[0];
        }
        #endregion
    }
}