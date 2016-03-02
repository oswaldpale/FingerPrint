using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class PeriodoOAD
    {
        private Conexion connection = new Conexion();

        public DataTable consultarPeriodo(string periodo,string diasemana) {
            string sql = @"SELECT
                                h.hose_id AS ID,
                                CONCAT(TIME_FORMAT(ho.hora_inicio, '%r'), ' - ', TIME_FORMAT(ho.hora_fin, '%r')) AS HORARIO,
                                 timediff(ho.hora_fin, ho.hora_inicio)      AS DURACION
                            FROM
                                control_acceso.horariosemanal h
                            INNER JOIN control_acceso.semana s
                            ON
                                s.sema_id = h.hose_diasemanaid
                            INNER JOIN control_acceso.horario ho
                            ON
                                ho.hora_id = h.hose_horaid
                            INNER JOIN periodo p
                            ON p.peri_id = h.peri_id
                            WHERE p.peri_id = '" + periodo + "'" +
                              " AND h.hose_diasemanaid = " + diasemana; 
            return connection.getDataMariaDB(sql).Tables[0];
        }
        public DataTable ConsultarEstadoPeriodo(string periodo) {
            string sql = @"SELECT
                                peri_id,
                                peri_totalhoras,
                                peri_descripcion
                            FROM
                                periodo p
                            WHERE
                                p.peri_id='" + periodo + "'";
            return connection.getDataMariaDB(sql).Tables[0];
        }

        public bool registrarPeriodo(string PrimaryKey,string totalHoras,string descripcion) {
            string sql = @"INSERT
                            INTO
                                periodo
                                (
                                    peri_id,
                                    peri_totalhoras,
                                    peri_descripcion
                                )
                                VALUES
                                (
                                    " + PrimaryKey + ","
                                    + totalHoras + ","
                                    + "'" + descripcion + "'"
                                + ")";
            return connection.sendSetDataMariaDB(sql);
        }

        public bool registrarHorarioPeriodo(string idperiodo, string idsemana, string idhorario,string primaryKey)
        {
            string sql = @"INSERT
                            INTO
                                horariosemanal
                                (
                                    peri_id,
                                    hose_diasemanaid,
                                    hose_horaid,
                                    hose_id
                                )
                                VALUES
                                ( "
                                    + idperiodo+","
                                    + idsemana +","
                                    + idhorario+","
                                    + primaryKey +
                                ")";
            return connection.sendSetDataMariaDB(sql);
        }
    }
}