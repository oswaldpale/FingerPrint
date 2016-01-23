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

    public partial class VistaEstudiantes : Form
    {
        SqlConnection miconexion = new SqlConnection(Conexion.conexion);
        public VistaEstudiantes()
        {
            InitializeComponent();
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream(txtexaminar2.Text, FileMode.Open, FileAccess.Read);
            //Se inicailiza un flujo de archivo con la imagen seleccionada desde el disco.
            BinaryReader br = new BinaryReader(stream);
            FileInfo fi = new FileInfo(txtexaminar2.Text);

            //Se inicializa un arreglo de Bytes del tamaño de la imagen
            byte[] binData = new byte[stream.Length];
            //Se almacena en el arreglo de bytes la informacion que se obtiene del flujo de archivos(foto)
            //Lee el bloque de bytes del flujo y escribe los datos en un búfer dado.
            stream.Read(binData, 0, Convert.ToInt32(stream.Length));

            ////Se muetra la imagen obtenida desde el flujo de datos
            picfoto.Image = Image.FromStream(stream);

            Estudiantes f1 = new Estudiantes();
            this.Hide();
            f1.Show();

            f1.txtnombre.Text = lblnombres.Text.ToString();
            f1.txtapellido.Text = lblapellidos.Text.ToString();
            f1.txtdni.Text = lbldni.Text.ToString();
            f1.numedad.Text = lbledad.Text.ToString();
            f1.txtdireccion.Text = lbldireccion.Text.ToString();
            f1.cbodistrito.Text = lbldistrito.Text.ToString();
            f1.fecha1.Text = lblfecha.Text.ToString();
            f1.txtexaminar.Text = txtexaminar2.Text.ToString();
            f1.picfotografia.Image = Image.FromStream(stream);
        }

        private void btngrabar2_Click(object sender, EventArgs e)
        {
                FileStream stream = new FileStream(txtexaminar2.Text, FileMode.Open, FileAccess.Read);
                //Se inicailiza un flujo de archivo con la imagen seleccionada desde el disco.
                BinaryReader br = new BinaryReader(stream);
                FileInfo fi = new FileInfo(txtexaminar2.Text);

                //Se inicializa un arreglo de Bytes del tamaño de la imagen
                byte[] binData = new byte[stream.Length];
                //Se almacena en el arreglo de bytes la informacion que se obtiene del flujo de archivos(foto)
                //Lee el bloque de bytes del flujo y escribe los datos en un búfer dado.
                stream.Read(binData, 0, Convert.ToInt32(stream.Length));

                ////Se muetra la imagen obtenida desde el flujo de datos
                picfoto.Image = Image.FromStream(stream);

              
                miconexion.Open();
                SqlCommand cmd = new SqlCommand("GRABA_ESTUDIANTES", miconexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOMBRES", lblnombres.Text.ToString());
                cmd.Parameters.AddWithValue("@APELLIDOS", lblapellidos.Text.ToString());
                cmd.Parameters.AddWithValue("@DNI", lbldni.Text);
                cmd.Parameters.AddWithValue("@EDAD", lbledad.Text.ToString());
                cmd.Parameters.AddWithValue("@DIRECCION", lbldireccion.Text.ToString());
                cmd.Parameters.AddWithValue("@DISTRITO", lbldistrito.Text.ToString());
                cmd.Parameters.AddWithValue("@FECHA", lblfecha.Text.ToString());
                cmd.Parameters.AddWithValue("@FOTO", binData);


                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("Registro Registrado con Exito", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("NO FUE REGISTRADO", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                miconexion.Close();

                btnnuevo.Enabled = true;
                btngrabar2.Enabled = false;
                btnregresar.Enabled = false;
            }

        private void VistaEstudiantes_Load(object sender, EventArgs e)
        {
            btnnuevo.Enabled = false;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Estudiantes f1 = new Estudiantes();
            this.Hide();
            f1.Show();
            f1.btnnuevo.Enabled = false;
            f1.txtnombre.Enabled = true;
            f1.txtdireccion.Enabled = true;
            f1.txtapellido.Enabled = true;
            f1.txtdni.Enabled = true;
            f1.numedad.Enabled = true;
            f1.fecha1.Enabled = true;
            f1.btnexaminar.Enabled = true;
            f1.txtnombre.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }



            }
        }

    
