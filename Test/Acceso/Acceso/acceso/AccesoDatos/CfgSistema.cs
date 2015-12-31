using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Acceso.AccesoDatos
{
    class CfgSistema
    {
        //Variables de Conexion
        public static string usuarioBD = "root";
        public static string claveBD = "";
        public static string nombreBD = "pruebas";
        public static string nombreBDSistema = "pruebas";

        public static string ipServidor = "";
        public static string puertoServidor = "";
        public static string nombreServidor = "localhost";


        //Variables de Usuario
        public static int idUsuarioSistema = 0;
        public static string nombreUsuarioSistema = "";
        public static string NombreCompletoUsuario = "";
        public static string tipoUsuario = "";

        //Variables de Empresa
        public static string NombreEmpresa = "";
        public static string RutaTrabajo = "";

    }
}
