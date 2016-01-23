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
    public partial class Logueo : Form
    {
        public Logueo()
        {
            InitializeComponent();
        }
        Acceso ace = new Acceso();
        int veces = 0;
        private const int intentos = 2;


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ace.Usuario = textBox1.Text;
            ace.Clave = textBox2.Text;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Digite Usuario para Continuar", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Digite Clave para Continuar", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox2.Focus();
            }
            else if(ace.Verificar() == true)
            {
                //MessageBox.Show(ace.Mensaje, "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide();
                Menu inicia = new Menu();
                inicia.Show();
            }
            else
            {
                if (veces == 2 )
                {
                    MessageBox.Show(ace.Mensaje, "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Su Usuario o Contraseña NO Coinciden o son Erroneas \n \n                        Le Quedan " + (intentos - veces) + " Intento(s)", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                 veces = veces + 1;
                }
            }
         
            
        }

        private void Logueo_Load(object sender, EventArgs e)
        {

        }

      

        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

   
    }
}
