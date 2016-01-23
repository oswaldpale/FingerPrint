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
using System.IO;
using System.Data.SqlClient;

namespace Instituto
{
    public partial class Estudiantes : Form
    {
        SqlConnection miconexion = new SqlConnection(Conexion.conexion);
        public OpenFileDialog examinar = new OpenFileDialog();
        public Estudiantes()
        {
            InitializeComponent();
        }

        private void Estudiantes_Load(object sender, EventArgs e)
        {
            btnnuevo.Enabled = false;
        }
 

        private void btnexaminar_Click_1(object sender, EventArgs e)
        {
            examinar.Filter = "image files|*.jpg;*.png;*.gif;*.ico;.*;";
            DialogResult dres1 = examinar.ShowDialog();
            if (dres1 == DialogResult.Abort)
                return;
            if (dres1 == DialogResult.Cancel)
                return;
            txtexaminar.Text = examinar.FileName;
            picfotografia.Image = Image.FromFile(examinar.FileName);
        }


        private void btnvisualizar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Digite Nombres para Continuar", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtnombre.Focus();
            }
            else if (txtapellido.Text == "")
            {
                MessageBox.Show("Digite Apellidos para Continuar", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtapellido.Focus();
            }
            else if (txtdni.Text == "")
            {
                MessageBox.Show("Digite Dni para Continuar", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdni.Focus();
            }
            else if (txtdireccion.Text == "")
            {
                MessageBox.Show("Digite Direccion para Continuar", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdireccion.Focus();
            }
            else if (cbodistrito.Text == "SELECCIONE DISTRITO")
            {
                MessageBox.Show("Seleccione Distrito para Continuar", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdni.Focus();

            }
            else if (txtexaminar.Text == "")
            {
                MessageBox.Show("Cargue una fotografia para Continuar", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnexaminar.Focus();

            }
            else
            {
                FileStream stream = new FileStream(txtexaminar.Text, FileMode.Open, FileAccess.Read);
                //Se inicailiza un flujo de archivo con la imagen seleccionada desde el disco.
                BinaryReader br = new BinaryReader(stream);
                FileInfo fi = new FileInfo(txtexaminar.Text);

                //Se inicializa un arreglo de Bytes del tamaño de la imagen
                byte[] binData = new byte[stream.Length];
                //Se almacena en el arreglo de bytes la informacion que se obtiene del flujo de archivos(foto)
                //Lee el bloque de bytes del flujo y escribe los datos en un búfer dado.
                stream.Read(binData, 0, Convert.ToInt32(stream.Length));

                ////Se muetra la imagen obtenida desde el flujo de datos
                picfotografia.Image = Image.FromStream(stream);

                VistaEstudiantes f2 = new VistaEstudiantes();
                this.Hide();
                f2.Show();

                f2.lblnombres.Text = txtnombre.Text.ToString();
                f2.lblapellidos.Text = txtapellido.Text.ToString();
                f2.lbldni.Text = txtdni.Text.ToString();
                f2.lbledad.Text = numedad.Text.ToString();
                f2.lbldireccion.Text = txtdireccion.Text.ToString();
                f2.lbldistrito.Text = cbodistrito.Text.ToString();
                f2.lblfecha.Text = fecha1.Value.ToString();
                f2.txtexaminar2.Text = txtexaminar.Text.ToString();
                f2.picfoto.Image = Image.FromStream(stream);
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            btnnuevo.Enabled = false;
            btnvisualizar.Enabled = true;
            txtnombre.Enabled = true;
            txtdireccion.Enabled = true;
            txtapellido.Enabled = true;
            txtdni.Enabled = true;
            numedad.Enabled = true;
            fecha1.Enabled = true;
            btnexaminar.Enabled = true;
            txtnombre.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            txtnombre.BackColor = Color.PeachPuff;
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            txtnombre.BackColor = Color.White;
        }

        private void txtapellido_Enter(object sender, EventArgs e)
        {
            txtapellido.BackColor = Color.PeachPuff;
        }

        private void txtapellido_Leave(object sender, EventArgs e)
        {
            txtapellido.BackColor = Color.White;
        }

        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void txtdni_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void txtdni_Enter(object sender, EventArgs e)
        {
            txtdni.BackColor = Color.PeachPuff;
        }

        private void txtdni_Leave(object sender, EventArgs e)
        {
            txtdni.BackColor = Color.White;
        }

        private void numedad_Enter(object sender, EventArgs e)
        {
            numedad.BackColor = Color.PeachPuff;
        }

        private void numedad_Leave(object sender, EventArgs e)
        {
            numedad.BackColor = Color.White;
        }

        private void txtdireccion_Enter(object sender, EventArgs e)
        {
            txtdireccion.BackColor = Color.PeachPuff;
        }

        private void txtdireccion_Leave(object sender, EventArgs e)
        {
            txtdireccion.BackColor = Color.White;
        }

        private void fecha1_ValueChanged(object sender, EventArgs e)
        {
           
        }

 

     

     
    }
}

