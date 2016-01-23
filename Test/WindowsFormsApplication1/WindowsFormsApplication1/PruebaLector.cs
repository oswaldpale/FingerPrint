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
 
    public partial class PruebaLector : Form,DPFP.Capture.EventHandler
    {
        const string MySqlConnecionString = "Server=127.0.0.1; Database=digital; User id=root; Pwd=root;";
        MySqlConnection conexion;
        public int PROBABILITY_ONE = 0x7FFFFFFF;
        bool registrationInProgress = false;
        int fingerCount = 0;
        byte[] huella = null;
        
        System.Drawing.Graphics graphics;
        System.Drawing.Font font;
        DPFP.Capture.ReadersCollection readers;
        DPFP.Capture.ReaderDescription readerDescription;
        DPFP.Capture.Capture capturer;
        DPFP.Template template;
        DPFP.FeatureSet[] regFeatures;
        DPFP.FeatureSet verFeatures;
        DPFP.FeatureSet verFeatures2;
        DPFP.Processing.Enrollment createRegTemplate;
        DPFP.Verification.Verification verify;
        DPFP.Capture.SampleConversion converter;
    //  int Usuario;
        public  void GuardarHuella()
        {
            graphics = this.CreateGraphics();
            font = new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            DPFP.Capture.ReadersCollection coll = new DPFP.Capture.ReadersCollection();
            InitializeComponent();
            regFeatures = new DPFP.FeatureSet[4];
            for (int i = 0; i < 4; i++)
                regFeatures[i] = new DPFP.FeatureSet();

            verFeatures = new DPFP.FeatureSet();
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    capturer.EventHandler = this;							//AQUI CAPTURAMOS LOS EVENTOS.

                    converter = new DPFP.Capture.SampleConversion();
                    try
                    {
                        verify = new DPFP.Verification.Verification();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ex: " + ex.ToString());
                    }
                    break;
                }
           }
        }

        private void GuardarHuella_Load(object sender, EventArgs e)
        {
            registrationInProgress = true;
            fingerCount = 0;
            createRegTemplate.Clear();
            if (capturer != null)
            {
                try
                {

                    capturer.StartCapture();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //conexion = new SqlConnection("integrated security=true;server=.;database=digital");
            conexion = new MySqlConnection();
            conexion.ConnectionString = "Server=127.0.0.1; Database=digital; User id=root; Pwd=root;";
           
       
        }
        public void OnComplete(object obj, string info, DPFP.Sample sample)
        {
            this.Invoke(new FunctionS(delegate()
            {
                tbInfo.Text = "Capture Complete";
            }));

            this.Invoke(new FunctionS(delegate()
            {
                Bitmap tempRef = null;
                converter.ConvertToPicture(sample, ref tempRef);
                System.Drawing.Image img = tempRef;
                //AQUI MOSTRAMOS LA HUELLA CAPTURADA EN EL PICTUREBOX Y LA REDIMENSIONAMOS AL TAMAÑO DEL PICTUREBOX
                Bitmap bmp = new Bitmap(converter.ConvertToPicture(sample, ref tempRef), pbImage.Size);
                String pxFormat = bmp.PixelFormat.ToString();
                Point txtLoc = new Point(pbImage.Width / 2 - 20, 0);
                graphics = Graphics.FromImage(bmp);
                //AHORA CUANDO EL LECTOR YA TENGA CAPTURADA UNA HUELLA COMIENZA TODO EL PROCESO

                if (registrationInProgress)
                {
                    try
                    {
                        //CAPTURAMOS 4 EXTRACCIONES DE LA HUELLA PARA PODER CREAR UNA PLANTILLA OPTIMA QUE
                        //SERA ALMACENADA
                        regFeatures[fingerCount] = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Enrollment);
                        if (regFeatures[fingerCount] != null)
                        {
                           // string b64 = Convert.ToBase64String(regFeatures[fingerCount].Bytes);
                      //      regFeatures[fingerCount].DeSerialize(Convert.FromBase64String(b64));

                            if (regFeatures[fingerCount] == null)
                            {
                                txtLoc.X = pbImage.Width / 2 - 26;
                                graphics.DrawString("Bad Press", font, Brushes.Cyan, txtLoc);
                                return;
                            }
                            ++fingerCount;

                            createRegTemplate.AddFeatures(regFeatures[fingerCount - 1]);
                            graphics = Graphics.FromImage(bmp);
                            if (fingerCount < 4)
                                graphics.DrawString("" + fingerCount + " De 4", font, Brushes.Black, txtLoc);
                            if (createRegTemplate.TemplateStatus == DPFP.Processing.Enrollment.Status.Failed)
                            {
                                capturer.StopCapture();
                                fingerCount = 0;
                                MessageBox.Show("Registration Failed, \nMake sure you use the same finger for all 4 presses.");
                            }
                            else
                                if (createRegTemplate.TemplateStatus == DPFP.Processing.Enrollment.Status.Ready)
                                {
                                    string mensaje = "";
                                  // MemoryStream x = new MemoryStream();
                                   MemoryStream mem = new MemoryStream();
                                    template = createRegTemplate.Template;
                                    template.Serialize(mem);
                                    byte[] imgArr = mem.ToArray();
                                    guardarhuellaenDB();
                                    /* 
                           
                                    verFeatures = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);
                                    mensaje = comparar(verFeatures);
                                    if (mensaje == "Ya Existe un Empleado Con La Huella Capturada")
                                    {
                                        MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        capturer.StopCapture();
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Se Procedera a guardar la huella digital", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        huella = mem.ToArray();
                                        
                                        //AQUI PROCEDEMOS A GUARDAR LA HUELLA EN LA DB
                                        guardarhuellaenDB();
                                        capturer.StopCapture();
                                     //   this.Close();
                                    }
                                    */
                                }
                        }

                    }
                    catch (DPFP.Error.SDKException ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    DPFP.Verification.Verification.Result rslt = new DPFP.Verification.Verification.Result();
                    verFeatures = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);
                    verify.Verify(verFeatures, template, ref rslt);

                    txtLoc.X = pbImage.Width / 2 - 38;
                    if (rslt.Verified == true)
                        graphics.DrawString("Match!!!!", font, Brushes.LightGreen, txtLoc);
                    else graphics.DrawString("No Match!!!", font, Brushes.Red, txtLoc);
                }
                pbImage.Image = bmp;
            //    MessageBox.Show("aqui");
                try
                {
                    string mensaje2 = "";
                    //MemoryStream x2 = new MemoryStream();
                    //MemoryStream mem2 = new MemoryStream();

                    verFeatures2 = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);
                    mensaje2 = comparar(verFeatures2);
                    if (mensaje2 == "Ya Existe un Empleado Con La Huella Capturada")
                    {
                        MessageBox.Show("encontrado");
                    }
                }
                catch (DPFP.Error.SDKException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }));
        }
        private void guardarhuellaenDB()
        {
          //  MySqlCommand comandodb;
          //  if (conexion.State == ConnectionState.Closed) conexion.Open();
             
           // comandodb = new MySqlCommand("insert into empleado(id, huella ",conexion);
             // comandodb = new MySqlCommand("Insert into empleado (huella) values (@huella)");
          //  comandodb.CommandType = CommandType.StoredProcedure;
             // comandodb.Parameters.AddWithValue("@huella", huella);
      //      comandodb.Parameters.Add("@msj", MySqlDbType.VarChar, 60).Direction = ParameterDirection.Output;
            //  comandodb.ExecuteScalar();
      //      MessageBox.Show(comandodb.Parameters["@msj"].Value + "");
          //  if (conexion.State == ConnectionState.Open) conexion.Close();
            using (MemoryStream ms = new MemoryStream())
            {
                //  imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
               // template.Serialize(ms);
                byte[] imgArr = ms.ToArray();


                using (MySqlConnection conn = GetNewConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO empleado(huella) VALUES (@imgArr)";
                        cmd.Parameters.AddWithValue("@imgArr", huella);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
        
        }


        private string comparar(DPFP.FeatureSet features)
        {
            string mensaje = "";
            try
            {
                conexion.Open();
                MySqlCommand y = new MySqlCommand("select huella from empleado", conexion);
                MySqlDataReader select;
                select = y.ExecuteReader();
                byte[] b;
                int cont = 0;
                DPFP.Verification.Verification.Result resulta = new DPFP.Verification.Verification.Result();
                while (select.Read())
                {
              //    MessageBox.Show(resulta.Verified + "0010...");
                   // Usuario = (int)select.GetValue(0);
                    //tx = (byte[])select.GetValue(0);
                    b = (byte[])select.GetValue(0);
             //     MessageBox.Show(resulta.Verified + "0010...");
                    Console.WriteLine("not found");
                    DPFP.Template templates = new DPFP.Template();
                    using (MemoryStream stream = new MemoryStream(b))
                    {
                        DPFP.Template templatess = new DPFP.Template(stream);
                        template = templatess;
                    }

                    
                    template.DeSerialize((byte[])b);
                    
                     
                    verify.Verify(features, template, ref resulta);
                    
                    if (resulta.Verified)
                    {
                        mensaje = "Ya Existe un Empleado Con La Huella Capturada";
                        MessageBox.Show(resulta.Verified + mensaje);
                        cont++;
                        break;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + " ");
            }
            conexion.Close();
            return mensaje;

        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            this.Invoke(new FunctionS(delegate()
            {
                tbInfo.Text = "Finger Gone";

            }));
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

            this.Invoke(new FunctionS(delegate()
            {
                tbInfo.Text = "Finger Touch";
            }));
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            this.Invoke(new FunctionS(delegate()
            {
                tbInfo.Text = "Reader Connected";
                MessageBox.Show(readerDescription.Vendor);
            }));
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {

            this.Invoke(new FunctionS(delegate()
            {

                tbInfo.Text = "Reader DisConnected"; MessageBox.Show("reader count: " + readers.Count);
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

        private void GuardarHuella_FormClosing(object sender, FormClosingEventArgs e)
        {
           // capturer.StopCapture();
        }

        private void tbInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }
        static MySqlConnection GetNewConnection()
        {
            var conn = new MySqlConnection(MySqlConnecionString);
            conn.Open();
            return conn;
        }

    }
}
