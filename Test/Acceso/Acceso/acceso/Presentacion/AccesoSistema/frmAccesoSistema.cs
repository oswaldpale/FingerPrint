using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Acceso.Presentacion.AccesoSistema
{
    public partial class frmAccesoSistema : Form, DPFP.Capture.EventHandler
    {
        LogicaNegocio.Acceso objAcceso = new LogicaNegocio.Acceso();
        private DPFP.Template Template;
        delegate void Function();
        private DPFP.Processing.Enrollment Enroller = new DPFP.Processing.Enrollment();
        private DPFP.Capture.Capture Capturer;
        private DPFP.Verification.Verification Verificator;

        public frmAccesoSistema()
        {
            InitializeComponent();
        }
        //Funcion que verifica si hay algo en el template

        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)

                    Capturer.EventHandler = this;		// Subscribe for capturing events.


                else
                    MessageBox.Show("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void frmAccesoSistema_Load(object sender, EventArgs e)
        {
            try
            {
                Init();
                Start();
            }
            catch {
                lblInstrucciones.Text = "No se puede iniciar la captura!";
            }
           
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    lblInstrucciones.Text = "Use el lector para escanear su huella digital.";
                }
                catch
                {
                    lblInstrucciones.Text ="No se puede iniciar la captura!";
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
                    lblInstrucciones.Text ="Can't terminate capture!";
                }
            }
        }
        

        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
             //lblInstrucciones.Text ="Scan the same fingerprint again.";
            objAcceso.leeRutas(this, Sample);
            //Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
           // MakeReport("The finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The fingerprint reader was touched.");
            

        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
           // MakeReport("The fingerprint reader was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The fingerprint reader was disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                lblInstrucciones.Text = "The quality of the fingerprint sample is good.";
            else
               lblInstrucciones.Text ="The quality of the fingerprint sample is poor.";
        }
        #endregion       

        private void frmAccesoSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }
    }

}
