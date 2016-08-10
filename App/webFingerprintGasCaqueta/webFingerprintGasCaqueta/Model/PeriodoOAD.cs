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

        public DataTable consultarPeriodo() {
            string sql = @"SELECT
                                peri_id AS IDPERIODO,
                                peri_totalhoras AS DURACION,
                                peri_descripcion AS HORARIO
                            FROM
                                periodo";
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

        public bool actualizartotalperiodo(string idperiodo) {
            string sql = @"UPDATE
                                    periodo p
                                SET
                                    p.peri_totalhoras = calcularhorasperiodo(p.peri_id)
                                WHERE
                                    p.peri_id = " + idperiodo;
            return connection.sendSetDataMariaDB(sql);
        }

        public DataTable consultarHorariosPorPeriodo(string periodo) {
            string sql = @"SELECT
                                    hs.hose_diasemanaid                                                            AS ID,
                                    s.sema_dia                                                                     AS DIAID,
                                    CONCAT(TIME_FORMAT(h.hora_inicio, '%r'), ' - ', TIME_FORMAT(h.hora_fin, '%r')) AS HORARIO
                                FROM
                                    HORARIO h
                                INNER JOIN horariosemanal hs
                                ON
                                    h.hora_id = hs.hose_horaid
                                INNER JOIN semana s
                                ON
                                    s.sema_id = hs.hose_diasemanaid
                                WHERE
                                    hs.peri_id = " + periodo + @"
                                ORDER BY
                                    ID";
            return connection.getDataMariaDB(sql).Tables[0];
        }

        public string recuperarIDperiodo()
        {
            string sql = "SELECT MAX(peri_id) AS CODIGO FROM periodo;";
            return connection.getDataMariaDB(sql).Tables[0].Rows[0]["CODIGO"].ToString();
        }

        public bool modificarPeriodo(string idperiodo, string descripcion)
        {
            string sql = @"UPDATE
                                periodo
                            SET
                                peri_descripcion = '" + descripcion + @"'
                            WHERE
                                peri_id = '" + idperiodo + "'";
            return connection.sendSetDataMariaDB(sql);
        }
        public bool eliminarPeriodo(string idperiodo) {
            List<string> sentencia = new List<string>();

            string sql = @"DELETE
                        FROM
                            horariosemanal
                        WHERE
                        peri_id = '" + idperiodo + "'";

            sentencia.Add(sql);

            sql = @"DELETE
                         FROM
                             periodo
                         WHERE
                             peri_id = '" + idperiodo + "'";

            sentencia.Add(sql);
            
            return connection.sendSetDataTransaction(sentencia);
        }
    }
}