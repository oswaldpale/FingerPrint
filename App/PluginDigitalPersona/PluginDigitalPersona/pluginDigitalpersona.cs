using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace PluginDigitalPersona

{
    [ComVisibleAttribute(true)]
    [Guid("7D30B571-D821-4F7D-B3A6-FD8728EF06F4")]
    [ProgId("PluginDigitalPersona.pluginDigitalpersona")]
    public class pluginDigitalpersona: DPFP.Capture.EventHandler
    {
        public string messageBiometricDevice = null;
        public string checkFingerprint = null;
        public string bitmapDactilar = null;
        public int stateEnrroller = 0;
        
        public event OnTemplateEventHandler OnTemplate;
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Capture.Capture Capturer;
        public pluginDigitalpersona() {
            Init();
            Start();
        }
       
        [ComVisible(true)]
        public void prueba() {
            MessageBox.Show("Prueba");
        }

        #region METODOS DE INICIALIZACION
        /// <summary>
        /// Metodos de Control de eventos.
        /// </summary>
        /// 
        protected virtual void Init()
        {
            try
            {
                Enroller = new DPFP.Processing.Enrollment();			// Create an enrollment.
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.
                UpdateStatus();
                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
            }
            catch
            {
               
            }
        }

        private void UpdateStatus()
        {
            this.stateEnrroller =(int) Enroller.FeaturesNeeded;
        }

        protected void Start()
		{
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                  
                }
                catch
                {
                  
                }
            }
		}
		protected void Stop()
		{
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                   
                }
            }
		}
        protected void Process(DPFP.Sample Sample)
        {
            BitMapToString(ConvertSampleToBitmap(Sample)); // CREO LA IMAGEN DE LA HUELLA.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            // Check quality of the sample and add to enroller if it's good
            if (features != null) try
                {
                    Enroller.AddFeatures(features);     // Add feature set to template.
                }
                finally
                {
                    UpdateStatus();
                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                            OnTemplate(Enroller.Template);
                            Stop();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            Stop();
                            OnTemplate(null);
                            Start();
                            break;
                    }
                }
        }

        public void ConverBitmap(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            //DrawPicture(ConvertSampleToBitmap(Sample));
        }
        
        #endregion
        #region METODOS DE CONVERSION DE IMAGEN
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
            return bitmap;
        }
        public void BitMapToString(Bitmap bitmap)
        {
            Bitmap bImage = bitmap;  //Your Bitmap Image
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            bitmapDactilar = Convert.ToBase64String(byteImage);

        }
        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }
        #endregion
        #region WebForm Event Handlers:
        /// <summary>
        /// Construccion de los eventos de escucha del lector al inicializar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureForm_Load(object sender, EventArgs e)
		{
			Init();
			Start();												// Start capture operation.
		}
        public void cerrarConexion() {
            Stop();
        }

	
	#endregion


        #region EventHandler Members
        /// <summary>
        /// Eventos En tiempo Real del Lector Biometrico...
        /// </summary>
        /// <param name="Capture"></param>
        /// <param name="ReaderSerialNumber"></param>
        /// <param name="Sample"></param>
        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            checkFingerprint = "true";
            Process(Sample);

        }
        [ComVisible(true)]
        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
          
      
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
          
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            this.messageBiometricDevice = "Dispositivo Conectado";
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            this.messageBiometricDevice = "Dispositivo Desconectado";


        }
        #endregion

        #region Miembros de EventHandler


        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
           
        }

        #endregion
        #region METODOS DE VARIABLES
        /// <summary>
        /// METODOS DE VARIABLES ACCESIBLES DESDE JAVASCRIPT.
        /// </summary>
        [ComVisible(true)]
        public string MessageBiometricDevice
        {
            get
            {
                return messageBiometricDevice;
            }
            set
            {
                messageBiometricDevice = value;
            }
        }
        [ComVisible(true)]
        public string CheckFingerprint
        {
            get
            {
                return checkFingerprint;
            }
            set
            {
                checkFingerprint = value;
            }
        }
        [ComVisible(true)]
        public string BitmapDactilar
        {
            get
            {
                return bitmapDactilar;
            }
            set
            {
                bitmapDactilar = value;
            }
        }
        [ComVisible(true)]
        public int StateEnrroller
        { 
            get
            {
                return stateEnrroller;
            }
            set
            {
                stateEnrroller = value;
            }
        }
        #endregion
    }
}
 