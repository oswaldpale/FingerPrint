using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace webFingerprintGasCaqueta.Model
{
    public class HorarioSemanaOAD
    {
        private Conexion connection = new Conexion();
        public DataTable consultarHorarioporDia(string periodo, string diasemana)
        {
            string sql = @"SELECT
                                h.hose_id AS ID,
                                h.hose_horaid AS IDHORA,
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
        public bool eliminarHorarioSemana(string id){
            string sql = @"DELETE
                            FROM
                                horariosemanal
                            WHERE
                            hose_id =" + id;
             return connection.sendSetDataMariaDB(sql);
        }

        
    }
}