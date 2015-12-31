using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Acceso.AccesoDatos
{
    class Conexion : CfgSistema
    {
         //Declaramos las variables:
        public MySqlConnection conn0;
        public MySqlConnection conn1;
        public MySqlConnection conn2;
        public MySqlConnection conn3;
        public MySqlConnection conn4;

        string CadenaDeConexion;
        public string sqlQuery1;
        public string sqlQuery2;
        //public string sqlQuery3;
        //public string sqlQuery4;

        public void AbrirConexion0()
        {
            try
            {

                CadenaDeConexion = "SERVER=" + Conexion.nombreServidor + ";"
                                 + "DATABASE=" + Conexion.nombreBDSistema + ";"
                                 + "UID=" + Conexion.usuarioBD + ";"
                                 + "PASSWORD=" + Conexion.claveBD + ";"
                                 + "Pooling=" + false + ";";

                conn0 = new MySqlConnection(CadenaDeConexion);
                conn0.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Descripción del Error: " + ex.Message + " " + Environment.NewLine +
                                                                                   " " + ex.StackTrace + " " + Environment.NewLine +
                                                                                   " ", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CerrarConexion0()
        {
            conn0.Close();
        }

        public void AbrirConexion1()
        {
            try
            {

                CadenaDeConexion = "SERVER=" + Conexion.nombreServidor + ";"
                                 + "DATABASE=" + Conexion.nombreBD + ";"
                                 + "UID=" + Conexion.usuarioBD + ";"
                                 + "PASSWORD=" + Conexion.claveBD + ";"
                                 + "Pooling=" + false + ";";

                conn1 = new MySqlConnection(CadenaDeConexion);
                conn1.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Descripción del Error: " + ex.Message + " " + Environment.NewLine +
                                                                                   " " + ex.StackTrace + " " + Environment.NewLine +
                                                                                   " ", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CerrarConexion1()
        {
            conn1.Close();
        }

        public void AbrirConexion2()
        {
            try
            {

                CadenaDeConexion = "SERVER=" + Conexion.nombreServidor + ";"
                                 + "DATABASE=" + Conexion.nombreBD + ";"
                                 + "UID=" + Conexion.usuarioBD + ";"
                                 + "PASSWORD=" + Conexion.claveBD + ";"
                                 + "Pooling=" + false + ";"
                                 + "Connect Timeout =" + 120 + ";";

                conn2 = new MySqlConnection(CadenaDeConexion);
                conn2.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Descripción del Error: " + ex.Message + " " + Environment.NewLine +
                                                                                   " " + ex.StackTrace + " " + Environment.NewLine +
                                                                                   " ", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CerrarConexion2()
        {
            conn2.Close();
        }

        public void AbrirConexion3()
        {
            try
            {

                CadenaDeConexion = "SERVER=" + Conexion.nombreServidor + ";"
                                 + "DATABASE=" + Conexion.nombreBD + ";"
                                 + "UID=" + Conexion.usuarioBD + ";"
                                 + "PASSWORD=" + Conexion.claveBD + ";"
                                 + "Pooling=" + false + ";"
                                 + "Connect Timeout =" + 120 + ";";

                conn3 = new MySqlConnection(CadenaDeConexion);
                conn3.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Descripción del Error: " + ex.Message + " " + Environment.NewLine +
                                                                                   " " + ex.StackTrace + " " + Environment.NewLine +
                                                                                   " ", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CerrarConexion3()
        {
            conn3.Close();
        }

        public void AbrirConexion4()
        {
            try
            {

                CadenaDeConexion = "SERVER=" + Conexion.nombreServidor + ";"
                                 + "DATABASE=" + Conexion.nombreBD + ";"
                                 + "UID=" + Conexion.usuarioBD + ";"
                                 + "PASSWORD=" + Conexion.claveBD + ";"
                                 + "Pooling=" + false + ";"
                                 + "Connect Timeout =" + 120 + ";";

                conn4 = new MySqlConnection(CadenaDeConexion);
                conn4.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Descripción del Error: " + ex.Message + " " + Environment.NewLine +
                                                                                   " " + ex.StackTrace + " " + Environment.NewLine +
                                                                                   " ", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CerrarConexion4()
        {
            conn4.Close();
        }        
    }
}
