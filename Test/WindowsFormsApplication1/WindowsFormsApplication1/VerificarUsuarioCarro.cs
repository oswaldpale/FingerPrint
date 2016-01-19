using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace WindowsFormsApplication1
{
    delegate void Functionz();
    public partial class VerificarUsuarioCarro : Form,DPFP.Capture.EventHandler
    {
        const string MySqlConnecionString = "Server=192.168.1.91; Database=control_acceso; User id=planta; Pwd=planta123;";
        
     
        bool registrationInProgress = false;              
        System.Drawing.Graphics graphics;
        DPFP.Capture.Capture capturer;
        DPFP.FeatureSet regFeatures;
        DPFP.FeatureSet verFeatures;
        
        DPFP.Capture.SampleConversion converter;
        public VerificarUsuarioCarro()
        {
           
         //   font = new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Pixel);
      //      DPFP.Capture.ReadersCollection coll = new DPFP.Capture.ReadersCollection();
            InitializeComponent();
            graphics = this.CreateGraphics();
            regFeatures = new DPFP.FeatureSet();
                    try
                    {
                        capturer = new DPFP.Capture.Capture();//CREAMOS UNA OPERACION DE CAPTURAS.
                        if (null != capturer)
                            capturer.EventHandler = this;			//AQUI CAPTURAMOS LOS EVENTOS.    
                            converter = new DPFP.Capture.SampleConversion();
                      
                    } 
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                                          
        }

        private void VerificarUsuario_Load(object sender, EventArgs e)
        {
            registrationInProgress = true;
            start();
        }
        public void OnComplete(object obj, string info, DPFP.Sample sample)
        {
            this.Invoke(new Functionz(delegate()
            {
                ListEvent.Items.Insert(0, "La Huella Digital ha sido Capturada");

            }));

            this.Invoke(new Functionz(delegate()
            {
                Bitmap tempRef = null;
                converter.ConvertToPicture(sample, ref tempRef);
                System.Drawing.Image img = tempRef;
                //AQUI MOSTRAMOS LA HUELLA CAPTURADA EN EL PICTUREBOX Y LA REDIMENSIONAMOS AL TAMAÑO DEL PICTUREBOX
                Bitmap bmp = new Bitmap(converter.ConvertToPicture(sample, ref tempRef), pbImage.Size);
                String pxFormat = bmp.PixelFormat.ToString();
                Point txtLoc = new Point(pbImage.Width / 2 - 20, 0);
                graphics = Graphics.FromImage(bmp);
                //AHORA CUANDO EL LECTOR YA TENGA CAPTURADA UNA HUELLA COMIENZA TODO EL PROCESO

                if (registrationInProgress)
                {
                    try
                    {
                        if (regFeatures != null)
                        {
                            verFeatures = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);
                            graphics = Graphics.FromImage(bmp);
                            PersonaDAL Phuella =new PersonaDAL();
                            Persona DatosPersonales;
                            DatosPersonales= Phuella.ObtenerPersonaHuella(verFeatures);
                            if (DatosPersonales != null)
                            {
                                textCedula.Text = Convert.ToString(DatosPersonales.Id);
                                textNombre.Text = DatosPersonales.Nombre;
                                textPrimerApell.Text = DatosPersonales.PrimerApellido;
                                textSegundoApell.Text = DatosPersonales.SegundoApellido;
                                //pictureBox1.Image = CargarImagenFoto(DatosPersonales.Foto);
                            }
                            else
                                {
                                textCedula.Text = "";
                                textNombre.Text = "";
                                textPrimerApell.Text = "";
                                textSegundoApell.Text = "";
                                pictureBox1.Image = null;
                                }
                        }
                    }
                    catch (DPFP.Error.SDKException ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                pbImage.Image = bmp;
            }));
        }
        
        public Image CargarImagenFoto(byte[] Foto){
            using (var stream = new MemoryStream(Foto))
            {
                Image img = Image.FromStream(stream);
                return img;
            }
        
        }
        private void start() {
             capturer.StartCapture();
             ListEvent.Items.Insert(0, "Utilizando el Lector de Huella Dactilar");
        }
        private void stop() {
            capturer.StopCapture();
            ListEvent.Items.Insert(0, "No se está usando el Lector de Huella Dactilar");
        }
        private void DetenerLectorHuella()
        {

            if (capturer != null)
            {
                try
                {

                    capturer.StopCapture();
                    capturer = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Dispose();
            Close();
        }
        public bool verificarhuella(byte[] b, DPFP.FeatureSet features)
        {
            DPFP.Verification.Verification.Result resulta = new DPFP.Verification.Verification.Result();
            DPFP.Verification.Verification verify = new DPFP.Verification.Verification();
            DPFP.Template templates = new DPFP.Template();
            MemoryStream stream = new MemoryStream(b);
            DPFP.Template templatess = new DPFP.Template(stream);
            templatess.DeSerialize((byte[])b);
            verify.Verify(features, templatess, ref resulta);
            if (resulta.Verified)
            {

                return true;
            }
            else
                return false;

        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            this.Invoke(new Functionz(delegate()
            {
                ListEvent.Items.Insert(0, "El dedo ha sido quitado del Lector de Huella");
            }));
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

            this.Invoke(new Functionz(delegate()
            {
                ListEvent.Items.Insert(0, "El dedo ha sido colocado sobre el Lector de Huella");

            }));
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            this.Invoke(new Functionz(delegate()
            {
                ListEvent.Items.Insert(0, String.Format("El Sensor de Huella Digital esta Activado o Conectado" +  " SerialNumber: " + ReaderSerialNumber));
            }));
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {

            this.Invoke(new Functionz(delegate()
            {
                ListEvent.Items.Insert(0, "El Sensor de Huella Digital esta Desactivado o no Conectado");

            }));

        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            MessageBox.Show("Sample quality!!!! " + CaptureFeedback.ToString());
        }




        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            try
            {
                Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }

        private void VerificarUsuarioCarro_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DetenerLectorHuella();
        }

        private void tbInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }
        static MySqlConnection GetNewConnection()
        {
            var conn = new MySqlConnection(MySqlConnecionString);
            conn.Open();
            return conn;
        }

        private void tbInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
