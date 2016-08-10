using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class PermisoOAD
    {
        private Conexion connection = new Conexion();
        //Registrar Permiso por Horas


        public bool registrarPermisoHora(string PrimaryKey,string idempleado ,string tipotiempo,string tipopermiso,string fechasolicitud,string estado,string fechapermiso,string horainicio,string horafin,string observacion)
        {
            string sql = @"INSERT
                            INTO
                                permisos
                                (
                                    perm_id,
                                    empl_idempleado,
                                    perm_tipo,
                                    tipe_id,
                                    perm_fechasolicitud,
                                    perm_estado,
                                    perm_fechahora,
                                    perm_horainicio,
                                    perm_horafin,
                                    perm_descripcion
                                )
                                VALUES
                                (
                                    " + PrimaryKey + @",
                                    '" + idempleado + @"',
                                    '" + tipotiempo + @"',
                                    '" + tipopermiso + @"',
                                    '"  + fechasolicitud + @"',
                                    '" + estado + @"',
                                    '"  + fechapermiso + @"',
                                    '"  + horainicio + @"',
                                    '" + horafin + @"',
                                    '" + observacion + @"'
                                )";
            return connection.sendSetDataMariaDB(sql);
        }
        //Registrar Permiso por Dias
        public bool registrarPermisoDia(string PrimaryKey,string idempleado , string tipotiempo, string tipopermiso, string fechasolicitud, string estado, string fechainicio, string fechafin,string observacion)
        {
            string sql = @"INSERT
                            INTO
                                permisos
                                (
                                    perm_id,
                                    empl_idempleado,
                                    perm_tipo,
                                    tipe_id,
                                    perm_fechasolicitud,
                                    perm_estado,
                                    perm_fechainicio,
                                    perm_fechafin,
                                    perm_descripcion
                                )
                                VALUES
                                (
                                    " + PrimaryKey + @",
                                    '" +idempleado + @"',
                                    '" + tipotiempo + @"',
                                    '" + tipopermiso + @"',
                                    '" + fechasolicitud + @"',
                                    '" + estado + @"',
                                    '" + fechainicio + @"',
                                    '" + fechafin + @"',
                                    '" + observacion + @"'
                                )";
            return connection.sendSetDataMariaDB(sql);
        }

        #region Tipo Permiso
        public DataTable consultarTipoPermiso()
        {
            string sql = @"SELECT
                                tipe_id AS CODIGO,
                                tipe_descripcion AS TIPO
                            FROM
                                tipo_permiso
                            WHERE
                                tipe_estado = 1";
            return connection.getDataMariaDB(sql).Tables[0];
        }

        public  DataTable consultarPermisosActivos()
        {
            string sql = @"SELECT
                                p.perm_id             AS CODIGO,
                                DATE_FORMAT(p.perm_fechasolicitud,'%d-%m-%Y') AS FECHASOLICITUD,
                                p.empl_idempleado     AS CODEMPLEADO,
                                CONCAT(e.Nombres, ' ', e.Apellido1, ' ', IF(e.Apellido2 IS NOT NULL,e.Apellido2,' ')) AS NOMBRE,
                                tp.tipe_descripcion   AS PERMISO,
                                p.perm_tipo           AS TIPOHORA,
                                p.perm_estado         AS ESTADO,
                                DATE_FORMAT(p.perm_fechainicio,'%d-%m-%Y')     AS FECHAINICIO,
                                DATE_FORMAT(p.perm_fechafin,'%d-%m-%Y')  AS FECHAFIN,
                                DATE_FORMAT(p.perm_fechahora,'%d-%m-%Y') AS FECHAHORA,
                                TIME_FORMAT(p.perm_horainicio,'%r')  AS HORAINICIO,
                                TIME_FORMAT(p.perm_horafin,'%r')     AS HORAFIN,
                                p.perm_descripcion    AS DESCRIPCION
                            FROM
                                permisos p
                            INNER JOIN tipo_permiso tp
                            ON
                                tp.tipe_id = p.tipe_id
                            INNER JOIN empleado e
                            ON p.empl_idempleado = e.Cod_empleado
                            WHERE
                                p.perm_estado='ACTIVO'";
            return connection.getDataMariaDB(sql).Tables[0];
        }

        public bool eliminarPermiso(string codigo)
        {
            string sql = @"DELETE
                            FROM
                                permisos
                            WHERE
                                perm_id =" + codigo;
            return connection.sendSetDataMariaDB(sql);
        }
        #endregion
    }
}