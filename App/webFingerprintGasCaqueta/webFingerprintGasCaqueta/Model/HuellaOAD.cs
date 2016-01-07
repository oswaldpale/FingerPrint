﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model.Boot_Park.Conections;

namespace webFingerprintGasCaqueta.Model
{
    public class HuellaOAD
    {
        private Conexion connection = new Conexion();
       

        public DataTable consultarHuellaPorUsuario(string filtroUsuario)
        {

            string sql ="SELECT "
                        + "    h.emple_codempleado, "
                        + "    h.huell_huella, "
                        + "    h.huell_dedo "
                        + "FROM "
                        + "    huella h "
                        + "INNER JOIN empleado e "
                        + "ON "
                        + "    h.emple_codempleado = e.Cod_empleado "
                        + "WHERE "
                        + "    e.Identificacion='"+ filtroUsuario + "'";
                  

            return connection.getDataMariaDB(sql).Tables[0];
        }

        public bool registrarHuella(string primaryKey,string huella, string empleado,string dedo)
        {
            string sql = "INSERT "
                        + "INTO "
                        + "    control_acceso.huella "
                        + "    ( "
                        + "        huell_id, "
                        + "        emple_codempleado, "
                        + "        huell_huella,"
                        + "        huell_dedo"
                        + "    ) "
                        + "    VALUES "
                        + "    ( "
                        + "        '" + primaryKey + "', "
                        + "        '" + empleado + "', "
                        + "        '" + huella + "', "
                        + "        '" + dedo + "' "
                        + "    )";

            return connection.sendSetDataMariaDB(sql);
        }
        public bool eliminarHuella(string idhuella)
        {
            string sql = "DELETE "
                         + "FROM "
                         + "    BOOTPARK.AUTORIZACION "
                         + "WHERE "
                         + "    USUA_ID ='" + idhuella + "' ";
                        
            return connection.sendSetDataMariaDB(sql);
        }
    }
}