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


        public bool registrarPermisoHora(string PrimaryKey,string idempleado ,string perm_codigo,string tipotiempo,string tipopermiso,string fechasolicitud,string estado,string fechapermiso,string horainicio,string horafin)
        {
            string sql = @"INSERT
                            INTO
                                permisos
                                (
                                    perm_id,
                                    empl_idempleado,
                                    perm_codigo,
                                    perm_tipotiempo,
                                    tipe_id,
                                    perm_fechasolicitud,
                                    perm_estado,
                                    perm_fechainicio,
                                    perm_horainicio,
                                    perm_horafin
                                )
                                VALUES
                                (
                                    " + PrimaryKey + @",
                                    '" + idempleado + @"',
                                    '" + perm_codigo + @"',
                                    '" + tipotiempo + @"',
                                    '" + tipopermiso + @"',
                                    "  + fechasolicitud + @",
                                    '" + estado + @"',
                                    "  + fechapermiso + @",
                                    "  + horainicio + @",
                                    '" + horafin + @"'
                                )";
            return connection.sendSetDataMariaDB(sql);
        }
        //Registrar Permiso por Dias
        public bool registrarPermisoDia(string PrimaryKey,string idempleado ,string perm_codigo, string tipotiempo, string tipopermiso, string fechasolicitud, string estado, string fechapermiso, string fechainicio, string fechafin)
        {
            string sql = @"INSERT
                            INTO
                                permisos
                                (
                                    perm_id,
                                    empl_idempleado,
                                    perm_codigo,
                                    tipe_id,
                                    perm_fechasolicitud,
                                    perm_estado,
                                    perm_cancelado,
                                    perm_fechainicio,
                                    perm_fechafin
                                )
                                VALUES
                                (
                                    " + PrimaryKey + @",
                                    '" +idempleado + @"',
                                    '" + perm_codigo + @"',
                                    '" + tipotiempo + @"',
                                    '" + tipopermiso + @"',
                                    " + fechasolicitud + @",
                                    '" + estado + @"',
                                    " + fechainicio + @",
                                    '" + fechafin + @"'
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
        #endregion
    }
}