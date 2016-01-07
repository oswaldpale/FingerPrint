using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WindowsFormsApplication1
{
    public partial class FormCamara : Form
    {
        public delegate void pasarfoto(Image foto);
        public event pasarfoto pasadofoto;
        Camara crearFot = new Camara();
        private bool existenDispositivos = false;
        private bool fotografiaHecha = false;
        private FilterInfoCollection dispositivosDeVideo;
        private VideoCaptureDevice fuenteDeVideo = null;
        private PictureBox Foto;

        /*
         *  Inicialización
         */
        public FormCamara()
        {
            InitializeComponent();
            BuscarDispositivos();
        }
        public void establecerCam(PictureBox princ) {
            Foto = princ;
        }

        /*
         *  Carga del formulario
         */
        private void Frm_Index_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (existenDispositivos)
            {
                fuenteDeVideo = new VideoCaptureDevice(dispositivosDeVideo[0].MonikerString);
                Size tamanho = new Size(640, 480);
                fuenteDeVideo.DesiredFrameSize = tamanho;
                fuenteDeVideo.NewFrame += new NewFrameEventHandler(MostrarImagen);
                fuenteDeVideo.Start();
            }
            else
            {
                MessageBox.Show("No se encuentra ningún dispositivo de vídeo en el sistema", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CerrarFormulario();
            }
        }

        /*
         *  Cerrando el formulario (evento)
         */
        private void Frm_Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CerrarFormulario();
        }

        /*
         *  Cerrar el formulario
         */
        private void CerrarFormulario()
        {
            if (fuenteDeVideo != null)
            {
                if (fuenteDeVideo.IsRunning)
                {
                    fuenteDeVideo.SignalToStop();
                    fuenteDeVideo = null;
                }
            }

            Dispose();
            Close();
        }
        /*
         *  Botón de Capturar
         */
        private void btn_capturar_Click(object sender, EventArgs e)
        {
            Capturar();
            fotografiaHecha = true;
            button1.Enabled = true;
        }

        /*
         *  Botón de Guardar
         */
        
        /*
         *  Identifica los dispositivos disponibles
         */
        private void BuscarDispositivos()
        {
            dispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (dispositivosDeVideo.Count == 0)
                existenDispositivos = false;
            else
                existenDispositivos = true;
        }

        /*
         *  Muestra imagen en el PictureBox
         */
        private void MostrarImagen(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            pctbox_webcam.Image = imagen;
        }


        /*
         *  Deja de capturar imágenes, obteniendo la última capturada
         */
        public Image EstablecerFoto(){
            return (pctbox_imagen.Image);
        }
        private void Capturar()
        {
            if (fuenteDeVideo != null)
            {
                if (fuenteDeVideo.IsRunning)
                {
                    pctbox_imagen.Image = pctbox_webcam.Image;
                }
            }
        }

        private void pctbox_webcam_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pasadofoto(pctbox_imagen.Image);
           // Foto.Image = pctbox_imagen.Image;
       //     crearFot.Foto =crearFot.ConvertirImagen(pctbox_imagen.Image);
            CerrarFormulario();

        }
        public byte[] ObtenerFoto()
        {
            return crearFot.Foto;
        }

        private void pctbox_imagen_Click(object sender, EventArgs e)
        {

        }
    }
}
