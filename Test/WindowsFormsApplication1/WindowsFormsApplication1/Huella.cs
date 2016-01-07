using DPFP.Capture;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Huella
    {
        public byte[] huella1 { get; set; }
        public byte[] huella2  { get; set; }
        public Huella() { }
        public Huella(byte[] phuella1, byte[] phuella2)
        {
            this.huella1 = phuella1;
            this.huella2 = phuella2;
        }
        public Bitmap PintarHuella(SampleConversion conversion,PictureBox marco, DPFP.Sample sample)
        {
            Bitmap tempRef = null;
            Image img = tempRef;
            Bitmap bmp = new Bitmap(conversion.ConvertToPicture(sample, ref tempRef),marco.Size);
            return bmp;
        }
        public Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }
        public Persona BuscarHuella(DPFP.FeatureSet features)
        {
            try
            {
                using (MySqlConnection conn = BDconexion.ObtenerConexion())
                {
                    MySqlCommand y = new MySqlCommand("SELECT cedula, nombres, ape1, ape2, foto, huella1, huella2 FROM persona", conn);
                    MySqlDataReader select;
                    select = y.ExecuteReader();
                    byte[] b;
                    byte[] c;
                    Persona Ppersona = new Persona();
                   
                    while (select.Read())
                    {
                        b = (byte[])select.GetValue(5);
                        c = (byte[])select.GetValue(6);

                        if (verificarhuella(b, features) || verificarhuella(c, features))
                        {
                            Ppersona.Id = Convert.ToInt32(select.GetValue(0));
                            Ppersona.Nombre = Convert.ToString(select.GetValue(1));
                            Ppersona.PrimerApellido = Convert.ToString(select.GetValue(2));
                            Ppersona.SegundoApellido = Convert.ToString(select.GetValue(3));
                            Ppersona.Foto = (byte[])select.GetValue(4);
                            MessageBox.Show("Ya Existe un Empleado Con La Huella Capturada" + Convert.ToString(select.GetValue(0)));
                            return Ppersona;    
                        }
                    }
                    return null;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + " sdsdsd");
                return null;
            }
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
            return (resulta.Verified);
      }
        public bool CompararHuella(DPFP.FeatureSet features)
        {
            try
            {
                using (MySqlConnection conn = BDconexion.ObtenerConexion())
                {
                    MySqlCommand y = new MySqlCommand("SELECT huella1, huella2 FROM persona", conn);
                    MySqlDataReader select;
                    select = y.ExecuteReader();
                    byte[] b;
                    byte[] c;
                    
             
                    while (select.Read())
                    {
                        b = (byte[])select.GetValue(0);
                        c = (byte[])select.GetValue(1);

                        if (verificarhuella(b, features) || verificarhuella(c, features))
                        {  
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception er)
            {
                return false;
            }
        }
    }
}
