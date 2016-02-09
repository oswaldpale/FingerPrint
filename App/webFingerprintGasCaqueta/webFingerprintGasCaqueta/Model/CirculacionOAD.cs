using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class CirculacionOAD
    {
        private Conexion connection = new Conexion();
        public DataTable consultarInformacionUsuario(string identificacion)
        {
            string sql = @"SELECT
                                u.NOMBRE,
                                CAST(u.IDENTIFICACION AS CHAR) AS IDENTIFICACION,
                                IF(u.TIPO = 'No Aplica', 'Visitante', 'Empleado') AS TIPO,
                                u.TIPO AS CARGO,
                                u.FOTO
                            FROM
                                (
                                    SELECT
                                        e.Cod_empleado                                         AS IDENTIFICACION,
                                        CONCAT(e.Nombres, ' ', e.Apellido1, ' ', e.Apellido2) AS NOMBRE,
                                        t.Tipo                                                 AS TIPO,
                                        e.FOTO
                                    FROM
                                        control_acceso.empleado e
                                    INNER JOIN sigc972008.tipoempleado t
                                    ON
                                        e.cod_tipo = t.cod_tipo
                                    WHERE
                                        e.Eliminado = 0
                                    UNION ALL
                                    SELECT
                                        v.visi_identificacion                                                AS IDENTIFICACION,
                                        CONCAT(v.visi_nombre, ' ', v.visi_apellido1, ' ', v.visi_apellido2) AS NOMBRE,
                                        'No Aplica'                                                          AS TIPO,
                                        v.visi_foto
                                    FROM
                                        visitante v
                                )
                                u
                             WHERE u.IDENTIFICACION = '" + identificacion + "'";
            return connection.getDataMariaDB(sql).Tables[0];
        }

        public bool registrarEntrada(string id,string identificacion)
        {
            string sql = @"INSERT
                            INTO
                                circulacion
                                (
                                    circu_id,
                                    circu_idusuario,
                                    circu_fecha,
                                    circu_horaentrada
                                )
                                VALUES
                                (
                                    " + id + @",
                                    '" + identificacion + @"',
                                    CURDATE(),
                                    CURTIME()
                                )";
            return connection.sendSetDataMariaDB(sql);
        }
        public bool registrarSalida(string id, string identificacion) {
            string sql = @"UPDATE
                                circulacion
                            SET
                                circu_horasalida = CURTIME() 
                            WHERE
                                circu_id = '" + id + @"'";
            return connection.sendSetDataMariaDB(sql);
        }

        public DataTable ListarUsuarios() {
            string sql = @"SELECT
                                u.NOMBRE,
                                u.IDENTIFICACION,
                                IF(u.TIPO='No Aplica','Visitante','Empleado') AS TIPO,
                                u.TIPO                                        AS CARGO
                            FROM
                                (
                                    SELECT
                                        e.Cod_empleado                                         AS IDENTIFICACION,
                                        CONCAT(e.Nombres, ' ', e.Apellido1 , ' ', e.Apellido2) AS NOMBRE ,
                                        t.Tipo                                                 AS TIPO
                                    FROM
                                        control_acceso.empleado e
                                    INNER JOIN sigc972008.tipoempleado t
                                    ON
                                        e.cod_tipo = t.cod_tipo
                                    WHERE
                                        e.Eliminado=0
                                    UNION ALL
                                    SELECT
                                        v.visi_identificacion                                                AS IDENTIFICACION,
                                        CONCAT(v.visi_nombre, ' ', v.visi_apellido1 , ' ', v.visi_apellido2) AS NOMBRE,
                                        'No Aplica'                                                          AS TIPO
                                    FROM
                                        visitante v
                                )
                                u";
            return connection.getDataMariaDB(sql).Tables[0];
        }

        public  DataTable consultarTipoIngreso(string identificacion)
        {
            string sql = @"SELECT
                                circu_id AS ID,
                                circu_fecha AS FECHA,
                                IF(circu_horaentrada is not null AND circu_horasalida IS NULL, 'SALIDA', 'ENTRADA')  AS INGRESOESTADO
                            FROM
                                circulacion
                            WHERE
                               circu_idusuario = '" + identificacion + "'"
                            + "ORDER BY ID DESC LIMIT 1";
            return connection.getDataMariaDB(sql).Tables[0];

        }
    }
}