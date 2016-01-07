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

namespace CapturaWebcam
{
    public partial class Frm_Index : Form
    {
        private bool existenDispositivos = false;
        private bool fotografiaHecha = false;
        private FilterInfoCollection dispositivosDeVideo;
        private VideoCaptureDevice fuenteDeVideo = null;





        /*
         *  Inicialización
         */
        public Frm_Index()
        {
            InitializeComponent();
            BuscarDispositivos();
        }

        /*
         *  Carga del formulario
         */
        private void Frm_Index_Load(object sender, EventArgs e)
        {
            if (existenDispositivos)
            {
                fuenteDeVideo = new VideoCaptureDevice(dispositivosDeVideo[0].MonikerString);
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
        }

        /*
         *  Botón de Guardar
         */
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (fotografiaHecha)
            {
                // Recorto la imagen conforme lo mostrado (Size del pctbox_webcam)
                Rectangle formaRecorte = new Rectangle(0, 0, 300, 300);
                Bitmap imagenOrigen = (Bitmap)pctbox_imagen.Image;
                Bitmap imagen = imagenOrigen.Clone(formaRecorte, imagenOrigen.PixelFormat);

                // Y la guardo
                try
                {
                    String ruta = txbox_ruta.Text.Trim();
                    if (!ruta.Substring(ruta.Length - 1).Equals("\\"))
                        ruta += "\\";
                    ruta += "CapturaWebcam.bmp";
                    imagen.Save(ruta);

                    MessageBox.Show("Fotografía almacenada", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Información",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Para guardar la fotografía, use en primer lugar el botón de Captura", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }









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

    }
}
