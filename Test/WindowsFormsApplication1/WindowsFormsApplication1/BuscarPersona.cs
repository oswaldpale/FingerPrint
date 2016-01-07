using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class BuscarPersona : Form
    {
        
        public BuscarPersona()
        {
            InitializeComponent();
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvBuscar.DataSource = PersonaDAL.Buscar(txtNombre.Text, txtApellido.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
             if (dgvBuscar.SelectedRows.Count == 1)
            {

                int id = Convert.ToInt32(dgvBuscar.CurrentRow.Cells[0].Value);
                
                this.Close();
            }
            else
                MessageBox.Show("debe de seleccionar una fila");
        }
      


        
    }
}

