﻿using System;
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
        public DataTable consultarHorariosPorPeriodo(string periodo) {
            string sql = @"SELECT
                            hs.hose_diasemanaid AS DIAID,
                            CONCAT(TIME_FORMAT(h.hora_inicio, '%r'), ' - ', TIME_FORMAT(h.hora_fin, '%r')) AS HORARIO
                        FROM
                            HORARIO h
                        INNER JOIN horariosemanal hs
                        ON
                            h.hora_id = hs.hose_horaid
                        WHERE
                            hs.peri_id = '" + periodo + "'" +
                        "ORDER BY DIAID";
            return connection.getDataMariaDB(sql).Tables[0];
        }

    }
}