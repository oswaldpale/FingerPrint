using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace webFingerprintGasCaqueta.Model
{
    public class FestivosOAD
    {
        private Conexion connection = new Conexion();
        public DataTable consultarFestivos()
        {
            string sql = @"SELECT
                                dife_Id AS IDENTIFICACION,
                                DATE_FORMAT(dife_fecha, '%Y/%m/%d') AS FECHA,
                                UPPER(dife_nombre) AS NOMBREFESTIVO
                            FROM
                                diasfestivos";
            return connection.getDataMariaDB(sql).Tables[0];
        }
        public bool registrarFestivo(string identficacion, string fecha, string nombrefestivo) {
            string sql = @"INSERT
                            INTO
                                diasfestivos
                                (
                                    dife_Id,
                                    dife_fecha,
                                    dife_nombre
                                )
                                VALUES
                                (
                                    " + identficacion + @",
                                    '" + fecha + @"',
                                    '" + nombrefestivo + @"'
                                )";
            return connection.sendSetDataMariaDB(sql);
        }
        public bool eliminarFestivo(string identificación) {
            string sql = @"DELETE
                            FROM
                                diasfestivos
                            WHERE
                                dife_Id =" + identificación;
            return connection.sendSetDataMariaDB(sql);
        }
        public bool consultarFechaExistente(string fecha) {
            string sql = @"SELECT
                              COUNT(*)
                            FROM
                                diasfestivos d
                            WHERE
                            d.dife_fecha = '" + fecha + "' ";
            return connection.getDataMariaDB(sql).Tables[0].Rows.Count != 0 ? true : false;
        }
       
    }
}