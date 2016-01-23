//SISTEMA REALIZADO POR MICHELL ALVARADO C.
//CompuBinario
//www.compubinario.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Instituto
{
    public partial class Listado : Form
    {
        SqlConnection miconexion = new SqlConnection(Conexion.conexion);
        ClasEstudiante fun = new ClasEstudiante();
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            rdbdni.Checked = true;
            fun.listarestudiantes(dataestudiantes);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            fun.eliminar(dataestudiantes);
            fun.listarestudiantes(dataestudiantes);
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Estudiantes estu = new Estudiantes();
            this.Hide();
            estu.Show();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (rdbdni.Checked == true)
            {
                fun.Buscar = txtbuscar.Text;
                fun.buscarxdni(dataestudiantes);
            }
            else if (rdbnombres.Checked == true)
            {
                fun.Buscar = txtbuscar.Text;
                fun.buscarapellido(dataestudiantes);
            }
        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdbdni.Checked == true)
            {
               txtbuscar.MaxLength = 8;
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (rdbnombres.Checked == true)
            {
                txtbuscar.MaxLength = 43556;
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtbuscar_Enter(object sender, EventArgs e)
        {
            txtbuscar.BackColor = Color.PeachPuff;
        }

        private void txtbuscar_Leave(object sender, EventArgs e)
        {
            txtbuscar.BackColor = Color.White;
        }

     

    }
}
