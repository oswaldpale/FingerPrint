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
    delegate void Functions();
    public partial class CapturarHuella : Form, DPFP.Capture.EventHandler
    {
        public PictureBox DibHuella1;
        public PictureBox DibHuella2;
        bool dedo;
   
        bool registrationInProgress = false;
        int fingerCount = 0;
   
        Huella crearHuella = new Huella();
        byte[] huella1;
        byte[] huella2;
        MemoryStream mem;
        MemoryStream x;
        DPFP.Capture.ReadersCollection readers;
        DPFP.Capture.ReaderDescription readerDescription;
        DPFP.Capture.Capture capturer;
        DPFP.Template template;
        DPFP.FeatureSet[] regFeatures;
        DPFP.FeatureSet verFeatures;
        DPFP.Processing.Enrollment createRegTemplate;
        //  int Usuario;
        public CapturarHuella()
        {
            
            InitializeComponent();
            
            DPFP.Capture.ReadersCollection coll = new DPFP.Capture.ReadersCollection();
            regFeatures = new DPFP.FeatureSet[4];
            for (int i = 0; i < 4; i++)
                regFeatures[i] = new DPFP.FeatureSet();

           // verFeatures = new DPFP.FeatureSet();
            createRegTemplate = new DPFP.Processing.Enrollment();

            readers = new DPFP.Capture.ReadersCollection();

            for (int i = 0; i < readers.Count; i++)
            {
                readerDescription = readers[i];
                if ((readerDescription.Vendor == "Digital Persona, Inc.") || (readerDescription.Vendor == "DigitalPersona, Inc."))
                {
                    try
                    {
                        capturer = new DPFP.Capture.Capture(readerDescription.SerialNumber, DPFP.Capture.Priority.Normal);//CREAMOS UNA OPERACION DE CAPTURAS.
                        capturer.EventHandler = this;    	//AQUI CAPTURAMOS LOS EVENTOS.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message+ ex.ToString());
                    }
                    break;
                }
            }
            
        }

        private void CapturarHuella_Load(object sender, EventArgs e)
        {
            dedo = true;
            btHuella1.Enabled = false;
            ListEvent.Items.Clear();
            registrationInProgress = true;
            fingerCount = 0;
            createRegTemplate.Clear();
            EstadoHuellas();
            Start();
           
        }
        private void Start()
        {
            if (capturer != null)
            {
                try
                {
                    capturer.StartCapture();
                    ListEvent.Items.Insert(0, "Utilizando el Lector de Huella Dactilar");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        private void Stop()
        {
            capturer.StopCapture();
            ListEvent.Items.Insert(0, "No se está usando el Lector de Huella Dactilar");
        }
        private void EstadoHuellas() {
            ListEvent.Items.Insert(0, "Muestra de Huellas Necesarias para Guardar Template: " + createRegTemplate.FeaturesNeeded);
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
        public bool Compararhuella(DPFP.FeatureSet features)
        {
            
            if (template != null)
            {
                DPFP.Verification.Verification.Result resulta = new DPFP.Verification.Verification.Result();
                DPFP.Verification.Verification verify = new DPFP.Verification.Verification();
                verify.Verify(features, template, ref resulta);
                return resulta.Verified;
            }
            else {
                return false; 
            }
        }
        public void Ontemplate(DPFP.Template template)
        {
            this.template = template;
        }

        public void OnComplete(object obj, string info, DPFP.Sample sample)
        {
            this.Invoke(new Functions(delegate()
            {

                ListEvent.Items.Insert(0, "La Huella Digital ha sido Capturada");

            }));
            this.Invoke(new Functions(delegate()
            {
                if (dedo)
                {
                    ProcesarCaptura(pbImage, sample);
                }
                else {
                    ProcesarCaptura(pbImage2, sample);
                }
                    

            }));


            // aqui va otro metodo invoke
        }
        void ProcesarCaptura(PictureBox pbImg, DPFP.Sample sample)
         {
             Bitmap bmp = crearHuella.ConvertSampleToBitmap(sample);
 
             if (registrationInProgress)
             {
                 try
                 {
                     //CAPTURAMOS 4 EXTRACCIONES DE LA HUELLA PARA PODER CREAR UNA PLANTILLA OPTIMA QUE SERA ALMACENADA
                     regFeatures[fingerCount] = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Enrollment);
                     if (regFeatures[fingerCount] != null)
                     {
                         Huella validarBD = new Huella();
                         verFeatures = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);
                         if (Compararhuella (verFeatures))
                         {
                             MessageBox.Show("Registration Failed, \nMake Ya existe  una persona registrada con esa huella");
                             ListEvent.Items.Insert(0, "Ya se registro esta huella con el dedo indice izquierdo.");
                             fingerCount = 0;
                             createRegTemplate.Clear();
                             bmp = null;
                             dedo = false;
                             pbImg.Image = bmp;    
                         }
                         else
                         {
                             ++fingerCount;
                             createRegTemplate.AddFeatures(regFeatures[fingerCount - 1]);
                             dibujarHuella(pbImg, bmp);
                             EstadoHuellas();
                             if (createRegTemplate.TemplateStatus == DPFP.Processing.Enrollment.Status.Failed)
                             {
                                 createRegTemplate.Clear();
                                 capturer.StopCapture();
                                 fingerCount = 0;
                                 EstadoHuellas();
                                 capturer.StartCapture();
                                 MessageBox.Show("Registration Failed, \nMake sure you use the same finger for all 4 presses.");
                             }
                             else
                                 if (createRegTemplate.TemplateStatus == DPFP.Processing.Enrollment.Status.Ready)
                                 {
                                                                                       
                                         if (dedo)
                                         {
                                             template = createRegTemplate.Template;
                                             mem= new MemoryStream();
                                             template.Serialize(mem);
                                             ListEvent.Items.Insert(0, "Plantilla huella izquierda creada");
                                             MessageBox.Show("Presione: 'Capturar huella derecha'");
                                             huella1 = mem.ToArray();
                                         }
                                         else {
                                             template = createRegTemplate.Template;
                                             x = new MemoryStream();
                                             template.Serialize(x);
                                             ListEvent.Items.Insert(0, "Plantilla huella derecha creada");
                                             huella2 = x.ToArray();
                                         }
                                         if ((btHuella1.Enabled || bthuella2.Enabled)!= true)
                                         {
                                             btguardar.Enabled = true;
                                         }
                                         capturer.StopCapture();
                                         createRegTemplate.Clear();
                                         fingerCount = 0;
                                         capturer.StartCapture();
                                         capturer.EventHandler = null;
                                 }
                         }
                     }

                 }
                 catch (DPFP.Error.SDKException ex)
                 {

                     MessageBox.Show("Registration Failed, \nMake sure you use the same finger for all 4 presses.");
                     createRegTemplate.Clear();
                     capturer.StopCapture();
                     fingerCount = 0;
                     capturer.StartCapture();
                 }

             }

         }


        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            this.Invoke(new Functions(delegate()
            {

                ListEvent.Items.Insert(0, "El dedo ha sido quitado del Lector de Huella");

            }));
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

            this.Invoke(new Functions(delegate()
            {

                ListEvent.Items.Insert(0, "El dedo ha sido colocado sobre el Lector de Huella");
            }));
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            this.Invoke(new Functions(delegate()
            {

                ListEvent.Items.Insert(0, String.Format("El Sensor de Huella Digital esta Activado o Conectado" + readerDescription.Vendor + " SerialNumber: " + ReaderSerialNumber));
            }));
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {

            this.Invoke(new Functions(delegate()
            {
                ListEvent.Items.Insert(0, String.Format("El Sensor de Huella Digital esta Desactivado o no Conectado "));
               
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

        private void CapturarHuella_FormClosing(object sender, FormClosingEventArgs e)
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
        
        private void GuardarHuellas_Click(object sender, EventArgs e)
        {
            
            crearHuella.huella1 = huella1;
            crearHuella.huella2 = huella2;
            DibHuella1.Image = pbImage.Image;
            DibHuella2.Image = pbImage2.Image;
            Close();
        }
        public void dibujarHuella(PictureBox pHuella, Bitmap bitmap)
        {
           // DibHuella1 = pHuella1;
            //DibHuella2 = pHuella2;
            pHuella.Image = new Bitmap(bitmap, pHuella.Size);
        }


        private void CapturarHuella_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        public byte[] Obtenerhuella1() {
            return crearHuella.huella1;
        
        }
        public byte[] Obtenerhuella2() {
            return crearHuella.huella2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbImage2_Click(object sender, EventArgs e)
        {

        }

        private void btHuella1_Click(object sender, EventArgs e)
        {
            dedo = true;
            btHuella1.Enabled = false;
        }

        private void bthuella2_Click(object sender, EventArgs e)
        {
                    dedo = false;
                    bthuella2.Enabled = false;
                    capturer.EventHandler = this;             
        }

        private void ListEvent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        internal void huellasvacias(PictureBox pHuella1, PictureBox pHuella2)
        {
            DibHuella1 = pHuella1;
            DibHuella2 = pHuella2;
           
        }
    }
}
