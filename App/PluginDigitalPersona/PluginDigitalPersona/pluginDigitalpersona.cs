using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PluginDigitalPersona

{
    public class pluginDigitalpersona: DPFP.Capture.EventHandler
    {
        private DPFP.Capture.Capture Capturer;
        public pluginDigitalpersona() {
            iniciarPlugin();
        }

        public void iniciarPlugin()
        {
          
        }

        #region Init Method
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

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
           
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
           
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
           
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
         
        }
        #endregion

        #region Miembros de EventHandler


        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
           
        }

        #endregion
    }
}
