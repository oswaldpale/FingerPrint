﻿using System;
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
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
            }
            catch
            {
               
            }
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
        #endregion
        #region METODOS DE CONVERSION DE IMAGEN
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
            return bitmap;
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
           
          
        }
        [ComVisible(true)]
        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
          
      
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MessageBox.Show("Prueba pulso de la huella");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            this.messageBiometricDevice = "Dispositivo " + ReaderSerialNumber + "Conectado";
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            this.messageBiometricDevice = " Dispositivo" + ReaderSerialNumber + " Desconectado";


        }
        #endregion

        #region Miembros de EventHandler


        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
           
        }

        #endregion
        #region METODOS DE VARIABLES
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
        #endregion
    }
}
 