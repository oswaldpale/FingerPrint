//SISTEMA REALIZADO POR MICHELL ALVARADO C.
//CompuBinario
//www.compubinario.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Instituto
{
    class Acceso
    {
        SqlConnection miconexion = new SqlConnection(Conexion.conexion);

        private string mensaje;
        private string usuario;
        private string clave;

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public bool Verificar()
        {
            bool resultado = false;
            miconexion.Open();
            SqlCommand comando = new SqlCommand("select * from usuarios where usuario='" + usuario + "'and clave='" + clave + "'", miconexion);
            comando.Connection = miconexion;
            SqlDataReader ejecuta = comando.ExecuteReader();
            if (ejecuta.Read())
            {
                resultado = true;
                mensaje = "Su Logueo Fue Ingresado Correctamente \n \n               Bienvenido al Sistema \n \n Instituto Tecnologico Superior Binario";
            }
            else
            {
                mensaje = "         Excedio el Limite de Intentos al Sistema \n \nEspere unos Minutos y Ingrese Su Logueo Otra Vez";
            }
            miconexion.Close();
            return resultado;
        }
      
    }
}
