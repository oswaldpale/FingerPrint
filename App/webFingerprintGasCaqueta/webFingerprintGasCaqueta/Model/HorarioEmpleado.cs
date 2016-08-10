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
                                empl_idempleado = '" + idempleado + @"'
                            AND
                                hoem_estado = '1' 
                                ";
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
                                                hoem_fechafin,
                                                hoem_fechacreacion
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
                                                '" + fechafin + @"',
                                                now() 
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
                                                hoem_tipohorario,
                                                hoem_fechacreacion
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
                                                now()
                                            )";

            return connection.sendSetDataMariaDB(sentencia);
        }

        public bool modificarHorarioPeriodoEmpleado(string primarykey, string estado, string idempleado, string periodo, string festivo, string tiemporetardo, string tipohorario, string fechainicio, string fechafin)
        {


            string sentencias = @"UPDATE
                                            horarioempleado
                                            SET
                                         
                                                peri_id= '" + periodo + @"',
                                                hoem_estado = " + estado + @",
                                                empl_idempleado  = '" + idempleado + @"',
                                                hoem_vincularfestivos  = '" + festivo + @"',
                                                hoem_tiempotarde = '" + tiemporetardo + @"' ,
                                                hoem_tipohorario = '" + tipohorario + @"',
                                                hoem_fechainicio = '" + fechainicio + @"' ,
                                                hoem_fechafin = '" + fechafin + @"'
                                             WHERE 
                                                hoem_id = " + primarykey + @"
                                            ";

            return connection.sendSetDataMariaDB(sentencias);
        }

        public bool inacticarHorarioEmpleado(string codigoEmpleado)
        {
            string sql = @"UPDATE
                                horarioempleado
                            SET
                                hoem_estado = 0,
                                hoem_fechainactivo = now()
                            WHERE
                                empl_idempleado = '" + codigoEmpleado + @"'
                            AND
                            hoem_estado = '1'";

            return connection.sendSetDataMariaDB(sql);
        }

        public bool modificarHorarioFijoEmpleado(string primarykey, string estado, string idempleado, string periodo, string festivo, string tiemporetardo, string tipohorario)
        {
            string sentencia = @"UPDATE
                                            horarioempleado
                                            SET
                                                peri_id= '" + periodo + @"',
                                                hoem_estado = " + estado + @",
                                                empl_idempleado  = '" + idempleado + @"',
                                                hoem_vincularfestivos  = '" + festivo + @"',
                                                hoem_tiempotarde = '" + tiemporetardo + @"' ,
                                                hoem_tipohorario = '" + tipohorario + @"'
                                             WHERE 
                                                hoem_id = " + primarykey + @"
                                            ";

            return connection.sendSetDataMariaDB(sentencia);
        }
    }
}