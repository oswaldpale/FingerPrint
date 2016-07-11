using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class HorarioEmpleado
    {
        private Conexion connection = new Conexion();
        public DataTable consultarHorariEmpleado(string idempleado)
        {

            string sql = @"SELECT
                                he.hoem_id AS CODIGO,
                                he.hoem_estado AS ESTADO,
                                he.peri_id AS IDHORARIOSEMANA,
                                p.peri_descripcion AS PERIODO,
                                he.hoem_vincularfestivos AS FESTIVO,
                                he.hoem_tiempotarde AS TIEMPOTARDE,
                                he.hoem_tipohorario AS TIPO,
                                DATE_FORMAT(he.hoem_fechainicio,'%d-%m-%Y')  AS FINICIO,
                                DATE_FORMAT(he.hoem_fechafin,'%d-%m-%Y')  AS FFIN
                            FROM
                                horarioempleado he
                            INNER JOIN 
                                periodo p
                            ON
                                he.peri_id = p.peri_id
                            WHERE
                                empl_idempleado = '" + idempleado + "'";
            return connection.getDataMariaDB(sql).Tables[0];
        }
        public bool registrarHorarioPeriodoEmpleado(string primarykey,string estado, string idempleado, string periodo, string festivo, string tiemporetardo, string tipohorario, string fechainicio, string fechafin)
        {


            string sentencias = @"INSERT
                                        INTO
                                            horarioempleado
                                            (
                                                hoem_id,
                                                hoem_estado,
                                                empl_idempleado,
                                                peri_id,
                                                hoem_vincularfestivos,
                                                hoem_tiempotarde,
                                                hoem_tipohorario,
                                                hoem_fechainicio,
                                                hoem_fechafin
                                            )
                                            VALUES
                                            (
                                                " + primarykey + @",
                                                " + estado + @",
                                                '" + idempleado + @"',
                                                '" + periodo + @"',
                                                '" + festivo + @"',
                                                '" + tiemporetardo + @"' ,
                                                '" + tipohorario + @"',
                                                '" + fechainicio + @"',
                                                '" + fechafin + @"'
                                            )";

            return connection.sendSetDataMariaDB(sentencias);
        }
        public bool registrarHorarioFijoEmpleado(string primarykey,string estado, string idempleado, string periodo, string festivo, string tiemporetardo, string tipohorario)
        {
            string sentencia = @"INSERT
                                        INTO
                                            horarioempleado
                                            (
                                                hoem_id,
                                                hoem_estado,
                                                empl_idempleado,
                                                peri_id,
                                                hoem_vincularfestivos,
                                                hoem_tiempotarde,
                                                hoem_tipohorario
                                            )
                                            VALUES
                                            (
                                                " + primarykey + @",
                                                " + estado + @",
                                                '" + idempleado + @"',
                                                '" + periodo + @"',
                                                '" + festivo + @"',
                                                '" + tiemporetardo + @"' ,
                                                '" + tipohorario + @"'
                                            )";

            return connection.sendSetDataMariaDB(sentencia);
        }
    }
}