using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace webFingerprintGasCaqueta.Model
{
    public class VisitanteOAD
    {
        private Conexion connection = new Conexion();
        public bool registrarVisitante(string identificacion, string nombre, string apellido1, string apellido2, string telefono,string direccion, string foto)
        {
            string sql = "INSERT "
                            + "INTO "
                            + "    visitante "
                            + "    ( "
                            + "        visi_identificacion, "
                            + "        visi_nombre, "
                            + "        visi_apellido1, "
                            + "        visi_apellido2, "
                            + "        visi_telefono, "
                            + "        visi_direccion, "
                            + "        visi_foto, "
                            + "        visi_fecharegistro "
                            + "    ) "
                            + "    VALUES "
                            + "    ( "
                            + "        '" + identificacion + "', "
                            + "        '" + nombre + "', "
                            + "        '" + apellido1 + "', "
                            + "        '" + apellido2 + "', "
                            + "        '" + telefono + "', "
                            + "        '" + direccion + "', "
                            + "        '" + foto + @"', 
                                       now()"
                            + "    )";
            return connection.sendSetDataMariaDB(sql);
        }
        public DataTable consultarVisitantes() {
            string sql = "SELECT "
                            + "    v.visi_identificacion                                                AS IDENTIFICACION, "
                            + "    CONCAT(v.visi_nombre, ' ', v.visi_apellido1 , ' ', v.visi_apellido2) AS NOMBRE, "
                            + "    v.visi_nombre                                                        AS NOMBREUSUARIO, "
                            + "    v.visi_apellido1                                                     AS APELLIDO1, "
                            + "    v.visi_apellido2                                                     AS APELLIDO2, "
                            + "    v.visi_telefono                                                      AS TELEFONO, "
                            + "    v.visi_direccion                                                   AS DIRECCION, "
                            + "    IF( "
                            + "    ( "
                            + "        SELECT "
                            + "            COUNT(h.huell_identificacion) "
                            + "        FROM "
                            + "            huella h "
                            + "        WHERE "
                            + "            h.huell_identificacion = v.visi_identificacion "
                            + "        AND h.huell_dedo='Primario' "
                            + "    ) "
                            + "    !=0,'true','false') AS EXISTHUEPRIMARY, "
                            + "    IF( "
                            + "    ( "
                            + "        SELECT "
                            + "            COUNT(h.huell_identificacion) "
                            + "        FROM "
                            + "            huella h "
                            + "        WHERE "
                            + "            h.huell_identificacion = v.visi_identificacion "
                            + "        AND h.huell_dedo='Secundario' "
                            + "    ) "
                            + "    !=0,'true','false') AS EXISTHUESECOND "
                            + "FROM "
                            + "    visitante v";
            return connection.getDataMariaDB(sql).Tables[0];

        }

     

        public bool consultarSiExisteVisitante(string identificacion) {
            string sql = "SELECT "
                            + "   * "
                            + "FROM "
                            + "    (( "
                            + "        SELECT "
                            + "            e.Identificacion AS IDENTIFICACION "
                            + "        FROM "
                            + "            empleado e "
                            + "    ) "
                            + "UNION ALL "
                            + "    ( "
                            + "        SELECT "
                            + "            v.visi_identificacion AS IDENTIFICACION "
                            + "        FROM "
                            + "            visitante v "
                            + "    )) AS u "
                            + "WHERE "
                            + "    u.IDENTIFICACION ='" + identificacion + "'";
            return connection.getDataMariaDB(sql).Tables[0].Rows.Count != 0 ? false : true;
        }

        public bool modificarvisitante(string tidentificacion, string tnombre, string tapellido1, string tapellido2, string ttelefono, string tdireccion, string tfoto)
        {
            string sql = @"UPDATE
                                visitante
                            SET
                                visi_nombre = '" + tnombre + @"',
                                visi_apellido1 = ' " + tapellido1 + @"',
                                visi_apellido2 = ' " + tapellido2 + @"',
                                visi_foto = ' " + tfoto + @"',
                                visi_telefono = ' " + ttelefono +  @"',
                                visi_direccion = ' "  + tdireccion + @"'
                            WHERE
                                visi_identificacion =" + tidentificacion;
            return connection.sendSetDataMariaDB(sql);
        }

        public DataTable consultarRutaFotoVisitante(string identificacion)
        {
            string sql = @"SELECT
                            v.visi_fotoFisica AS FOTO

                        FROM
                            visitante v
                        where
                         v.visi_identificacion = '" + identificacion + "'";  
            return connection.getDataMariaDB(sql).Tables[0];
        }

        public  bool guardarFotoVisitante(string identificacion, string base64Foto)
        {
            string sql = @"UPDATE
                                visitante
                            SET
                                visi_fotoFisica = '" + base64Foto + @"'
                            WHERE
                                visi_identificacion = '" + identificacion + "' ";

            return connection.sendSetDataMariaDB(sql);
        }

        #region METODOS CONVERSION DE DATOS
       
        /// <summary>
        /// Conversión de Byte[] a formato string.
        /// </summary>
        /// <param name="footprintByte"></param>
        /// <returns></returns>
        public string StringToByte(byte[] footprintByte)
        {
            return Convert.ToBase64String(footprintByte);
        }


        /// <summary>
        /// Conversor de String a Byte[]
        /// </summary>
        /// <param name="finger"></param>
        /// <returns></returns>
        public byte[] ByteToString(string finger)
        {
            //byte[] bytes = new byte[finger.Length * sizeof(char)];
            //System.Buffer.BlockCopy(finger.ToCharArray(), 0, bytes, 0, bytes.Length);
            byte[] bytes = Convert.FromBase64String(finger);
            return bytes;
        }
        #endregion
    }
}