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
    public partial class BuscarEstudiantes : Form
    {
        SqlConnection miconexion = new SqlConnection(Conexion.conexion);
        ClasEstudiante fun = new ClasEstudiante();
        public OpenFileDialog examinar = new OpenFileDialog();
        public BuscarEstudiantes()
        {
            InitializeComponent();
        }

        private void EditarEstudiante()
        {
         
            miconexion.Open();
            string sql = @"UPDATE ESTUDIANTE SET
                                [NOMBRES] = @NOMBRES, [APELLIDOS] = @APELLIDOS ,[DIRECCION] = @DIRECCION ,[DISTRITO] = @DISTRITO WHERE [ID] = @ID";

            SqlCommand command = new SqlCommand(sql, miconexion);

            command.Parameters.AddWithValue("ID", label4.Text);

            command.Parameters.AddWithValue("NOMBRES", txtnombres.Text);
            command.Parameters.AddWithValue("APELLIDOS", txtapellidos.Text);
            command.Parameters.AddWithValue("DIRECCION", txtdireccion.Text);
            command.Parameters.AddWithValue("DISTRITO", cbodistrito.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Datos Actualizados Satisfactoriamente", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            miconexion.Close();
        }

        private void EditarFotoEstudiante()
        {
            if (txtexaminar.Text == "")
            {
                MessageBox.Show("Cargue una Nueva Fotografia para Continuar", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnexaminar3.Focus();
                btnexaminar3.Enabled = true;
                txtexaminar.Enabled = true;
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
                picfoto3.Image = Image.FromStream(stream);

                miconexion.Open();
                string sql = @"UPDATE ESTUDIANTE SET
                             [FOTO] =  @FOTO WHERE [ID] = @ID";

                SqlCommand command = new SqlCommand(sql, miconexion);

                command.Parameters.AddWithValue("ID", label4.Text);
                command.Parameters.AddWithValue("FOTO", binData);
                command.ExecuteNonQuery();
                MessageBox.Show("Fotografia Actualizada Satisfactoriamente", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnexaminar3.Enabled = false;
                txtexaminar.Enabled = false;
                btneditafoto.Enabled = false;
                miconexion.Close();
            }
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            EditarEstudiante();
         

            txtnombres.Enabled = false;
            txtapellidos.Enabled = false;
            txtdireccion.Enabled = false;
            cbodistrito.Enabled = false;
            btnVerDatos.Enabled = false;
            btnnuevoeditar.Enabled = true;
        }

        private void btneditafoto_Click(object sender, EventArgs e)
        {
            EditarFotoEstudiante();
        }

        private void btnexaminar3_Click(object sender, EventArgs e)
        {
            examinar.Filter = "image files|*.jpg;*.png;*.gif;*.ico;.*;";
            DialogResult dres1 = examinar.ShowDialog();
            if (dres1 == DialogResult.Abort)
                return;
            if (dres1 == DialogResult.Cancel)
                return;
            txtexaminar.Text = examinar.FileName;
            picfoto3.Image = Image.FromFile(examinar.FileName);
        }

        private void BuscarEstudiantes_Load(object sender, EventArgs e)
        {
            
            cbobusqueda.SelectedIndex = 0;
            txtbusqueda1.Focus();
            txtbusqueda1.Enabled = true;
            txtnombres.Enabled = false;
            txtapellidos.Enabled = false;
            txtdireccion.Enabled = false;
            cbodistrito.Enabled= false;
            btnVerDatos.Enabled = false;
            btneditafoto.Enabled = false;
            btnnuevoeditar.Enabled = false;
            btnexaminar3.Enabled = false;

        }

        private void btnnuevoeditar_Click(object sender, EventArgs e)
        {
            txtbusqueda1.Enabled = true;
            cbobusqueda.Enabled = true;
            txtnombres.Enabled = false;
            txtapellidos.Enabled = false;
            txtdireccion.Enabled = false;
            cbodistrito.Enabled = false;
            btnVerDatos.Enabled = false;
            btneditafoto.Enabled = false;
            btnnuevoeditar.Enabled = false;
            btnexaminar3.Enabled = false;
            txtbusqueda1.Clear();
            txtnombres.Clear();
            txtapellidos.Clear();
            txtdireccion.Clear();
            txtexaminar.Clear();
            cbodistrito.Text = "SELECCIONE DISTRITO";
            txtbusqueda1.Focus();
            picfoto3.Image = null;
        }

        private void txtbusqueda1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //BUSQUEDA POR DNI
                if (cbobusqueda.Text == "Dni")
                {
                    SqlConnection miconexion = new SqlConnection(Conexion.conexion);
                    miconexion.Open();
                    SqlCommand cmd = new SqlCommand("select * from ESTUDIANTE where DNI= @Clave", miconexion);
                    cmd.Parameters.AddWithValue("@Clave", txtbusqueda1.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    //Representa un set de comandos que es utilizado para llenar un DataSet
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    //Representa un caché (un espacio) en memoria de los datos.
                    DataSet ds = new DataSet("ESTUDIANTE");

                    //Arreglo de byte en donde se almacenara la foto en bytes
                    byte[] MyData = new byte[0];


                    //Llenamosel DataSet con la tabla. ESTUDIANTE es nombre de la tabla
                    dp.Fill(ds, "ESTUDIANTE");

                    //Si dni existe ejecutara la consulta
                    if (ds.Tables["ESTUDIANTE"].Rows.Count > 0)
                    {
                        //Inicializamos una fila de datos en la cual se almacenaran todos los datos de la fila seleccionada
                        DataRow myRow = ds.Tables["ESTUDIANTE"].Rows[0];

                        //Se almacena el campo foto de la tabla en el arreglo de bytes
                        MyData = (byte[])myRow["FOTO"];
                        //Se inicializa un flujo en memoria del arreglo de bytes
                        MemoryStream stream = new MemoryStream(MyData);
                        //En el picture box se muestra la imagen que esta almacenada en el flujo en memoria 
                        //el cual contiene el arreglo de bytes
                        picfoto3.Image = Image.FromStream(stream);

                        txtnombres.Text = myRow["NOMBRES"].ToString();
                        txtapellidos.Text = myRow["APELLIDOS"].ToString();
                        txtdireccion.Text = myRow["DIRECCION"].ToString();
                        cbodistrito.Text = myRow["DISTRITO"].ToString();
                        label4.Text = myRow["ID"].ToString();

                        txtbusqueda1.Enabled = false;
                        cbobusqueda.Enabled = false;
                        txtnombres.Enabled = true;
                        txtnombres.Focus();
                        txtapellidos.Enabled = true;
                        txtdireccion.Enabled = true;
                        cbodistrito.Enabled = true;
                        btnVerDatos.Enabled = true;
                        btneditafoto.Enabled = true;
                        btnnuevoeditar.Enabled = true;
                        btnexaminar3.Enabled = true;
                    }
                    //Si dni no existe mandara mensajillo
                    else
                    {
                        MessageBox.Show("El DNI ingresado NO EXISTE - Digite un DNI Valido", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txtbusqueda1.Enabled = true;
                        cbobusqueda.Enabled = true;
                        txtnombres.Enabled = false;
                        txtbusqueda1.Focus();
                        txtbusqueda1.Clear();
                        txtapellidos.Enabled = false;
                        txtdireccion.Enabled = false;
                        cbodistrito.Enabled = false;
                        btnVerDatos.Enabled = false;
                        btneditafoto.Enabled = false;
                        btnnuevoeditar.Enabled = false;
                        btnexaminar3.Enabled = false;
                    }

                }

                //BUSQUEDA POR APELLIDOS
                if (cbobusqueda.Text == "Apellidos")
                {
                    SqlConnection miconexion = new SqlConnection(Conexion.conexion);
                    miconexion.Open();
                    SqlCommand cmd = new SqlCommand("select * from ESTUDIANTE where apellidos= @Clave", miconexion);
                    cmd.Parameters.AddWithValue("@Clave", txtbusqueda1.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    //Representa un set de comandos que es utilizado para llenar un DataSet
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    //Representa un caché (un espacio) en memoria de los datos.
                    DataSet ds = new DataSet("ESTUDIANTE");

                    //Arreglo de byte en donde se almacenara la foto en bytes
                    byte[] MyData = new byte[0];


                    //Llenamosel DataSet con la tabla. ESTUDIANTE es nombre de la tabla
                    dp.Fill(ds, "ESTUDIANTE");

                    //Si dni existe ejecutara la consulta
                    if (ds.Tables["ESTUDIANTE"].Rows.Count > 0)
                    {
                        //Inicializamos una fila de datos en la cual se almacenaran todos los datos de la fila seleccionada
                        DataRow myRow = ds.Tables["ESTUDIANTE"].Rows[0];

                        //Se almacena el campo foto de la tabla en el arreglo de bytes
                        MyData = (byte[])myRow["FOTO"];
                        //Se inicializa un flujo en memoria del arreglo de bytes
                        MemoryStream stream = new MemoryStream(MyData);
                        //En el picture box se muestra la imagen que esta almacenada en el flujo en memoria 
                        //el cual contiene el arreglo de bytes
                        picfoto3.Image = Image.FromStream(stream);

                        txtnombres.Text = myRow["NOMBRES"].ToString();
                        txtapellidos.Text = myRow["APELLIDOS"].ToString();
                        txtdireccion.Text = myRow["DIRECCION"].ToString();
                        cbodistrito.Text = myRow["DISTRITO"].ToString();
                        label4.Text = myRow["ID"].ToString();

                        txtbusqueda1.Enabled = false;
                        cbobusqueda.Enabled = false;
                        txtnombres.Enabled = true;
                        txtnombres.Focus();
                        txtapellidos.Enabled = true;
                        txtdireccion.Enabled = true;
                        cbodistrito.Enabled = true;
                        btnVerDatos.Enabled = true;
                        btneditafoto.Enabled = true;
                        btnnuevoeditar.Enabled = true;
                        btnexaminar3.Enabled = true;
                    }
                    //Si dni no existe mandara mensajillo
                    else
                    {
                        MessageBox.Show("Los Apellidos ingresados NO EXISTEN - Digite Apellidos Validos", "CompuBinario", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txtbusqueda1.Enabled = true;
                        cbobusqueda.Enabled = true;
                        txtnombres.Enabled = false;
                        txtbusqueda1.Focus();
                        txtbusqueda1.Clear();
                        txtapellidos.Enabled = false;
                        txtdireccion.Enabled = false;
                        cbodistrito.Enabled = false;
                        btnVerDatos.Enabled = false;
                        btneditafoto.Enabled = false;
                        btnnuevoeditar.Enabled = false;
                        btnexaminar3.Enabled = false;
                    }
                }
            }
        }

        private void txtbusqueda1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbobusqueda.Text == "Dni")
            {
                txtbusqueda1.MaxLength = 8;
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
            if (cbobusqueda.Text == "Apellidos")
            {
                txtbusqueda1.MaxLength = 43556;
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

        private void txtbusqueda1_Enter(object sender, EventArgs e)
        {
            txtbusqueda1.BackColor = Color.PeachPuff;
        }

        private void txtbusqueda1_Leave(object sender, EventArgs e)
        {
            txtbusqueda1.BackColor = Color.White;
        }

        private void txtnombres_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtnombres_Enter(object sender, EventArgs e)
        {
            txtnombres.BackColor = Color.PeachPuff;
        }

        private void txtnombres_Leave(object sender, EventArgs e)
        {
            txtnombres.BackColor = Color.White;
        }

        private void txtapellidos_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtapellidos_Enter(object sender, EventArgs e)
        {
            txtapellidos.BackColor = Color.PeachPuff;
        }

        private void txtapellidos_Leave(object sender, EventArgs e)
        {
            txtapellidos.BackColor = Color.White;
        }

        private void txtdireccion_Enter(object sender, EventArgs e)
        {
            txtdireccion.BackColor = Color.PeachPuff;
        }

        private void txtdireccion_Leave(object sender, EventArgs e)
        {
            txtdireccion.BackColor = Color.White;
        }

    }
}
