using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DPFP;
using Newtonsoft.Json;


namespace PluginDigitalPersona

{
    [ComVisibleAttribute(true)]
    [Guid("7D30B571-D821-4F7D-B3A6-FD8728EF06F4")]
    [ProgId("PluginDigitalPersona.pluginDigitalpersona")]
    public class pluginDigitalpersona: Form,DPFP.Capture.EventHandler
    {
        public string messageBiometricDevice = null; // Controla mensajes y alertas del dispositivo cuando esta en estado (Conectado/Desconectado).
        public string checkFingerprint = null;  // chequea el estado de la huella cuando el dedo del usuario esta en el lector.
        public string bitmapDactilar = null;  // almacena la imagen de la huella en string.
        public string footprint = null;     // almacena huella en cadena string.
        public string typeProcces = "capture"; // tipo de proceso que ejecutara el lector (capture/validation) 
        public int stateEnrroller = 0;     // controla el estado del proceso de incripción.
        public DPFP.Processing.Enrollment Enroller;  // incripcion de huella.
        public DPFP.Capture.Capture Capturer;    // controla la captura de la huella.
        public List<FingerPrint> _filterFinger = new List<FingerPrint>();
        public bool stateUserVerify = false;
        public pluginDigitalpersona() {
            Init();
            Start();
        }
       
        [ComVisible(true)]
        public void prueba() {
            MessageBox.Show(_filterFinger.ToString());
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

		public void Stop()
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
        /// <summary>
        /// Ejecuta el proceso de incripcion de la huella
        /// </summary>
        /// <param name="Sample"></param>
        private void Process(DPFP.Sample Sample)
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
                            DPFP.Template template = Enroller.Template;
                            MemoryStream memoryFootprint = new MemoryStream();
                            template.Serialize(memoryFootprint);
                            byte[] footprintByte = memoryFootprint.ToArray();
                            //this.footprint = StringToByte(footprintByte);
                            this.Stop();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            this.Stop();
                            Start();
                            break;
                    }
                }
        }
        private void Validate(DPFP.Sample Sample) {
            BitMapToString(ConvertSampleToBitmap(Sample)); // CREO LA IMAGEN DE LA HUELLA.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            if (features != null) { 
                  UpdateStatus(); //Actualiza el estado del lector.
                  this.stateUserVerify = ValidateOneFingerPrint(features) ? true:false;
            }
        }

        private bool ValidateOneFingerPrint(FeatureSet features)
        {
            byte[] byteFinger;
            string iduser;
            foreach (var fingerOne in _filterFinger)
            {
                byteFinger = ByteToString(fingerOne.finger);
                if (VerifyFinger(byteFinger, features) == true)
                {
                    return true;
                }
            }
            return false;
        }
        private bool VerifyFinger(byte[] byteFinger, FeatureSet features)
        {
            DPFP.Verification.Verification.Result resulta = new DPFP.Verification.Verification.Result();
            DPFP.Verification.Verification verify = new DPFP.Verification.Verification();
            MemoryStream stream = new MemoryStream(byteFinger);
            DPFP.Template _templates = new DPFP.Template(stream);
            _templates.DeSerialize((byte[])byteFinger);
            verify.Verify(features, _templates, ref resulta);
            return (resulta.Verified);
        }

        public void DowloadFinger(string FilterFinger)
        {
            FingerPrint _finger = new FingerPrint();
            _finger = JsonConvert.DeserializeObject<FingerPrint>(FilterFinger);
            _filterFinger.Add(_finger);
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
        #endregion
        #region METODOS CONVERSION DE DATOS
        public void BitMapToString(Bitmap bitmap)
        {
            Bitmap bImage = bitmap;  //Your Bitmap Image
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            bitmapDactilar = StringToByte(byteImage);
             

        }
        /// <summary>
        /// Conversión de Byte[] a formato string.
        /// </summary>
        /// <param name="footprintByte"></param>
        /// <returns></returns>
        public string StringToByte(byte[] footprintByte) {
            return Convert.ToBase64String(footprintByte);
        }


        /// <summary>
        /// Conversor de String a Byte[]
        /// </summary>
        /// <param name="finger"></param>
        /// <returns></returns>
        public byte[] ByteToString(string finger)
        {
            //byte[] bytes = new byte[finger.Length * sizeof(char)];
            //System.Buffer.BlockCopy(finger.ToCharArray(), 0, bytes, 0, bytes.Length);
            byte[] bytes = Convert.FromBase64String(finger);
            return bytes;
        }
        /// <summary>
        /// Convierte json que se envia desde javascript a Objetos.
        /// </summary>
        /// <param name="_json"></param>
        [ComVisible(true)]
        public void  JsonToString(string _json) {
            _filterFinger =  JsonConvert.DeserializeObject<List<FingerPrint>>(_json);
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
        [ComVisible(true)]
        public void StopDevice() {
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
            if (typeProcces == "capture")   // Si typeProcces es igual capture: Ejecuta procceso de Incripcion
            {
                Process(Sample);     
            }
            else                           // Sino ejecuta el processo de Validación.
            {
                Validate(Sample);
            }

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
        [ComVisible(true)]
        public string Footprint
        {
            get
            {
                return footprint;
            }
            set
            {
                footprint = value;
            }
        }
        [ComVisible(true)]
        public string TypeProcces
        {
            get
            {
                return typeProcces;
            }
            set
            {
                typeProcces = value;
            }
        }
        [ComVisible(true)]
        public bool StateUserVerify
        {
            get
            {
                return stateUserVerify;
            }
            set
            {
                stateUserVerify = value;
            }
        }
        #endregion
    }
    public class FingerPrint
    {
        public string finger { get; set; }
        public string iduser { get; set; }

       
    }
}
 