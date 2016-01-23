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

namespace Instituto
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            Estudiantes registro = new Estudiantes();
            registro.MdiParent = this;
            registro.Show();


          
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void busquedaYActualizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            BuscarEstudiantes busquedaactualizacion = new BuscarEstudiantes();
            busquedaactualizacion.MdiParent = this;
            busquedaactualizacion.Show();
        
           
        }

        private void vistaYElimininacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

            Listado lista = new Listado();
            lista.MdiParent = this;
            lista.Show();

          
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

  


    
    }
}
