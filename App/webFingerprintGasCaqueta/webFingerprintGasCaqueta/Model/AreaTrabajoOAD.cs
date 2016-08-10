using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class AreaTrabajoOAD

    {

    private Conexion connection = new Conexion();
    public bool registrarArea(string codigo, string area, string ext)
    {
        string sql = @"INSERT
                            INTO
                                sigc972008.tb_areatrabajo
                                (
                                    Cod_AreaT,
                                    Area,
                                    Ext
                                )
                                VALUES
                                (
                                    " + codigo + @",
                                    '" +  area + @"',
                                    '" + ext + @"'
                                )";

        return connection.sendSetDataMariaDB(sql);
    }
    public DataTable consultarArea()
    {
        string sql = @"SELECT
                            Cod_AreaT AS CODIGO,
                            Area AS AREA,
                            Ext AS EXT
                        FROM
                            sigc972008.tb_areatrabajo";
        return connection.getDataMariaDB(sql).Tables[0];
    }
    public bool eliminarArea(string id)
    {
        string sql = @"DELETE
                        FROM
                            sigc972008.tb_areatrabajo
                        WHERE
                            Cod_AreaT = '" + id + @"'";

        return connection.sendSetDataMariaDB(sql);
    }
    public bool modificarArea(string codigo, string area, string ext)
    {
        string sql = @"UPDATE
                            sigc972008.tb_areatrabajo
                        SET
                            Cod_AreaT = " + codigo + @",
                            Area = '" + area + @"',
                            Ext = '" + ext + @"'
                        WHERE
                            Cod_AreaT = " + codigo + "";

        return connection.sendSetDataMariaDB(sql);
    }
   
  }
}