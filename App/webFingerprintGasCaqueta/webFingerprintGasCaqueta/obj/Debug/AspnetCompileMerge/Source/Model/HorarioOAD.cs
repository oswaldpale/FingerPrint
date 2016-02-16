using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;
using System.Data;

namespace webFingerprintGasCaqueta.Model
{
    public class HorarioOAD
    {
        private Conexion connection = new Conexion();
        public bool registrarHorario(string id, string nombre, string horaInicio, string horaFin,string tiempoTarde)
        {
            string sql = @"INSERT
                            INTO
                                horario
                                (
                                    hora_id,
                                    hora_nombre,
                                    hora_inicio,
                                    hora_fin,
                                    hora_tiempotarde
                                )
                                VALUES
                                (
                                    "  + id  + @",
                                    '" + nombre + @"',
                                    '" + horaInicio + @"',
                                    '" + horaFin + @"',
                                    "  + tiempoTarde + @"
                                )";


            return connection.sendSetDataMariaDB(sql);
        }
        public DataTable consultarHorarios() {
            string sql = @"SELECT
                            hora_id          AS ID,
                            hora_nombre      AS NOMBREHORARARIO,
                            TIME_FORMAT(hora_inicio,'%r')  AS HORA_INICIO,
                            TIME_FORMAT(hora_fin,'%r')     AS HORA_FIN,
                            hora_tiempotarde AS TIEMPO_TARDE
                        FROM
                            horario";
            return connection.getDataMariaDB(sql).Tables[0];
        }
        public bool eliminarHorario(string id) {
            string sql = @"DELETE
                            FROM
                                horario
                            WHERE
                                hora_id = '" + id + @"'";

            return connection.sendSetDataMariaDB(sql);
        }
        public bool modificarHorario(string id,string nombre,string horaInicio,string horaFin,string tiempoTarde){
            string sql = @"UPDATE
                            horario
                        SET
                            hora_nombre = '" + nombre + @"',
                            hora_horainicio = '" + horaInicio + @"',
                            hora_fin = '" + horaFin + @"',
                            hora_tiempotarde = " + tiempoTarde + @"
                        WHERE
                            hora_id = " + id + "";

            return connection.sendSetDataMariaDB(sql);
        }
        public DataTable ConsultarHorariosPeriodos() {
            string sql = @"SELECT
                                hora_id AS ID,
                                hora_nombre AS NOMBRE,
                                CONCAT(TIME_FORMAT(hora_inicio, '%r'), ' - ', TIME_FORMAT(hora_fin, '%r')) AS HORARIO
                            FROM
                                horario";
            return connection.getDataMariaDB(sql).Tables[0];
        }
    }
}