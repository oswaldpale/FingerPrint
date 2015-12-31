using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acceso.AccesoDatos;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Acceso.Presentacion.AccesoSistema;

namespace Acceso.LogicaNegocio
{
    class Acceso : Conexion
    {
        private DPFP.Template Template;
        delegate void Function();
        private DPFP.Processing.Enrollment Enroller = new DPFP.Processing.Enrollment();
        private DPFP.Capture.Capture Capturer;
        private DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
       
      

        public void leeRutas( frmAccesoSistema frm,DPFP.Sample Sample)
        {
            AbrirConexion0();
            Label lbl = new Label();
            sqlQuery1 = "SELECT * FROM usuarios";
            MySqlCommand cmd = new MySqlCommand(sqlQuery1,conn0);
            MySqlDataReader myReader = cmd.ExecuteReader();
            if(myReader.HasRows)
            {
                while (myReader.Read())
                {
                    //if(myReader["TipoUsuario"].ToString() == "Administrador")
                    //{
                    //MessageBox.Show(myReader["RutaTemplate"].ToString() + myReader["TipoUsuario"].ToString());
                    //filestreamTemplateGuardado = fsTG
                        FileStream fsTG = File.OpenRead(myReader["RutaTemplate"].ToString());
                        DPFP.Template templateGuardado = new DPFP.Template(fsTG);
                       
                        //verificar(templateGuardado);
                        if (procesar(Sample, templateGuardado, frm) == "Bienvenido")
                        {
                            MessageBox.Show("usuario que acceso: " + myReader["Nombre"].ToString());
                        }
                        else
                        {
                            //MessageBox.Show("Acceso denegado"); 
                        }
                        //Funcion Verifica y libera modulo correspondiente
                   // }
                   

                }
                myReader.Close();
            }
            CerrarConexion0();
        }

        public void verificar(DPFP.Template templateGuardado)
        {
            DPFP.Template templateNuevo;
            templateNuevo = templateGuardado;
            //templateGuardado = templateNuevo.GetType();
            
            

        }

        //Sample = capturaNueva
        //Retornar un string para poder mostrar el modulo correspondiente y terminar el cislo
        public string procesar(DPFP.Sample Sample, DPFP.Template templateGuardado,frmAccesoSistema frm)
        {
            DrawPicture(ConvertSampleToBitmap(Sample),frm);
            //DrawPicture(ConvertSampleToBitmap(Sample));
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            // Check quality of the sample and start verification if it's good
            // TODO: move to a separate task
            if (features != null)
            {
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                //vrifica fetures Vs Template = template guardado
                Verificator.Verify(features, templateGuardado, ref result);
                //Updatestatus
                if (result.Verified)
                {
                  //  MessageBox.Show("Bienvenido");
                    return "Bienvenido";
                }
                else
                {
                   // MessageBox.Show("Acceso Denegado");
                    return "Fail";
                }
              
            }
            else
            {
                return "Fail";
            }
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)

                return features;
            else
                return null;
        }


        private void OnTemplate(DPFP.Template template)
        {
                Template = template;
                
                if (Template != null)
                    MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                else
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
            
        }

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }

        private void DrawPicture(Bitmap bitmap, frmAccesoSistema frm)
        {
            frm.Picture.Image = new Bitmap(bitmap, frm.Picture.Size);
            
        }
    }

  
}
