using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class RegistrarPersona : Form
        
    {

        CapturarHuella capturahuella = null;
       
        public RegistrarPersona()
        {
            InitializeComponent();
            ListadoTipopersona();
        }
        Persona PersonaActual { get; set; }
        void ListadoTipopersona() {
            TipoPersonaDal listado = new TipoPersonaDal();
            DataSet lista = listado.ListaTipoPersona();
            cBoxVinculacion.DataSource = lista.Tables[0].DefaultView;
            cBoxVinculacion.DisplayMember = "nom_tipoper";
            cBoxVinculacion.ValueMember = "cod_tipoper";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarPersona_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           capturahuella= new CapturarHuella();
           capturahuella.huellasvacias(this.pblHuella1, this.pblHuella2);
           capturahuella.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCamara cam = new FormCamara();
            cam.pasadofoto += new FormCamara.pasarfoto(ejecutar);
         //   cam.establecerCam(this.PicFoto);
            cam.ShowDialog();
        }
        public void ejecutar(Image foto) {
            PicFoto.Image = foto;
        }

        private void PGuardar_Click(object sender, EventArgs e)
        {
            Persona pPersona =new Persona();
            pPersona.Id = Int64.Parse(textId.Text.Trim());
            pPersona.Nombre= textnombre.Text.Trim();
            pPersona.PrimerApellido=textPrimerApell.Text.Trim();
            pPersona.SegundoApellido = textSegundApell.Text.Trim();
            pPersona.Telefono=textTelefono.Text.Trim();
            pPersona.vinculacion = Convert.ToInt32(cBoxVinculacion.SelectedValue);   
            pPersona.Huella1 = capturahuella.Obtenerhuella1();
            pPersona.Huella2 = capturahuella.Obtenerhuella2();
          //  pPersona.Foto = cam.ObtenerFoto();
            int resultado = PersonaDAL.AgregarPersona(pPersona);
            if (resultado > 0)
            {
                MessageBox.Show("Persona Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar la Persona", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textId.Text = "";
                textnombre.Text = "";
                textPrimerApell.Text = "";
                textSegundApell.Text = "";
                textTelefono.Text = "";
                pblHuella1.Image = null;
                pblHuella2.Image = null;
                PicFoto.Image = null;
            }
            textId.Text = "";
            textnombre.Text = "";
            textPrimerApell.Text = "";
            textSegundApell.Text = "";
            textTelefono.Text = "";
            pblHuella1.Image = null;
            pblHuella2.Image = null;
            PicFoto.Image = null;
            

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
