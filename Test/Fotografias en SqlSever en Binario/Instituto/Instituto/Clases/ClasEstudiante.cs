//SISTEMA REALIZADO POR MICHELL ALVARADO C.
//CompuBinario
//www.compubinario.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Instituto
{
    
    class ClasEstudiante
    {
        SqlConnection miconexion = new SqlConnection(Conexion.conexion);

        private string buscar;
        public string Buscar
        {
            get { return buscar; }
            set { buscar = value; }
        }

        public void listarestudiantes(DataGridView data)
        {
            miconexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM estudiante", miconexion);
            comando.Connection = miconexion;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].Width = 60;
            data.Columns[1].Width = 165;
            data.Columns[2].Width = 165;
            data.Columns[3].Width = 90;
            data.Columns[4].Width = 50;
            data.Columns[5].Width = 165;
            data.Columns[6].Width = 100;
            data.Columns[7].Width = 125;

            miconexion.Close();
        }

        
        public void eliminar(DataGridView dataelimina)
        {
            DialogResult resultado = MessageBox.Show("¿Estas Seguro de Eliminar el Registro Seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                return;
            }
            SqlCommand comandito = new SqlCommand("BORRAR_ESTUDIANTE", miconexion);
            comandito.CommandType = CommandType.StoredProcedure;
            comandito.Parameters.AddWithValue("id", dataelimina.CurrentRow.Cells["id"].Value);
            miconexion.Open();
            comandito.ExecuteNonQuery();
            miconexion.Close();
            MessageBox.Show("Estudiante fue dado de Baja Correctamente", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void buscarxdni( DataGridView data)
        {
            miconexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM estudiante where dni like ('" + buscar + "%')", miconexion);
            comando.Connection = miconexion;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            data.DataSource = dt;
            miconexion.Close();
        }

        public void buscarapellido(DataGridView data)
        {
            miconexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM estudiante where apellidos like ('" + buscar + "%')", miconexion);
            comando.Connection = miconexion;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            data.DataSource = dt;
            miconexion.Close();
        }

       
    }
}
