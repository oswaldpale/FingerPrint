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
        public DataTable consultarHorarioporDia(string idempleado, string fechaserver, string diaserver)
        {
            
            string sql = "";
            return connection.getDataMariaDB(sql).Tables[0];
        }
        public bool registrarHorarioPeriodoEmpleado(string estado,List<string> idempleado,string periodo,string festivo,string tiemporetardo,string tipohorario,string fechainicio,string fechafin)
        {
            List<string> sql = new List<string>();
            foreach (var item in idempleado)
            {
                string sentencias = @"INSERT
                                        INTO
                                            horarioempleado
                                            (
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
                                                " + estado + @",
                                                '" + item.ToString() + @"',
                                                '" + periodo + @"',
                                                '" + festivo + @"',
                                                '" + tiemporetardo + @"' ,
                                                '" + tipohorario + @"',
                                                '" + fechainicio + @"',
                                                '" + fechafin + @"'
                                            )";
                sql.Add(sentencias);
            }
            return connection.sendSetDataTransaction(sql);
        }
        public bool registrarHorarioFijoEmpleado(string estado, List<string> idempleado, string periodo, string festivo, string tiemporetardo, string tipohorario)
        {
            List<string> sql = new List<string>();
            foreach (var item in idempleado)
            {
                string sentencias = @"INSERT
                                        INTO
                                            horarioempleado
                                            (
                                                hoem_estado,
                                                empl_idempleado,
                                                peri_id,
                                                hoem_vincularfestivos,
                                                hoem_tiempotarde,
                                                hoem_tipohorario
                                            )
                                            VALUES
                                            (
                                                " + estado + @",
                                                '" + item.ToString() + @"',
                                                '" + periodo + @"',
                                                '" + festivo + @"',
                                                '" + tiemporetardo + @"' ,
                                                '" + tipohorario + @"'
                                            )";
                sql.Add(sentencias);
            }
            return connection.sendSetDataTransaction(sql);
        }
    }
}