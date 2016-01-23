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
    delegate void FunctionS();
    public partial class GuardarHuella : Form,DPFP.Capture.EventHandler
    {
        const string MySqlConnecionString = "server=192.168.0.91; database=control_acceso; Uid=planta; pwd=planta123";
        MySqlConnection conexion;
        public int PROBABILITY_ONE = 0x7FFFFFFF;
        bool registrationInProgress = false;
        int fingerCount = 0;
        byte[] huella = null;
        byte[] huella1;
        MemoryStream mem;

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
        public GuardarHuella()
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
            conexion.ConnectionString = "server=192.168.0.91; database=control_acceso; Uid=planta; pwd=planta123";


        }
        public void OnComplete(object obj, string info, DPFP.Sample sample)
        {
            this.Invoke(new FunctionS(delegate ()
            {
                tbInfo.Text = "Capture Complete";
            }));

            this.Invoke(new FunctionS(delegate ()
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

               
                    try
                    {
                        //CAPTURAMOS 4 EXTRACCIONES DE LA HUELLA PARA PODER CREAR UNA PLANTILLA OPTIMA QUE SERA ALMACENADA
                        regFeatures[fingerCount] = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Enrollment);
                        if (regFeatures[fingerCount] != null)
                        {
                            Huella validarBD = new Huella();
                            verFeatures = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);

                            ++fingerCount;
                            createRegTemplate.AddFeatures(regFeatures[fingerCount - 1]);
                            if (createRegTemplate.TemplateStatus == DPFP.Processing.Enrollment.Status.Failed)
                            {
                                createRegTemplate.Clear();
                                capturer.StopCapture();
                                fingerCount = 0;

                                capturer.StartCapture();
                                MessageBox.Show("Registration Failed, \nMake sure you use the same finger for all 4 presses.");
                            }
                            else
                                if (createRegTemplate.TemplateStatus == DPFP.Processing.Enrollment.Status.Ready)
                            {
                                template = createRegTemplate.Template;
                                mem = new MemoryStream();
                                template.Serialize(mem);
                                MessageBox.Show("Presione: 'Capturar huella derecha'");
                                huella1 = mem.ToArray();
                                capturer.StopCapture();
                                createRegTemplate.Clear();
                                fingerCount = 0;
                                capturer.StartCapture();
                                capturer.EventHandler = null;
                            }
                        }


                    }
                    catch (DPFP.Error.SDKException ex)
                    {

                        MessageBox.Show("Registration Failed, \nMake sure you use the same finger for all 4 presses.");
                        createRegTemplate.Clear();
                        capturer.StopCapture();
                        fingerCount = 0;
                        capturer.StartCapture();
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
                      string sql = "INSERT "
                       + "INTO "
                       + "    control_acceso.huella "
                       + "    ( "
                       + "        huell_id, "
                       + "        huell_identificacion, "
                       + "        huell_huella,"
                       + "        huell_dedo"
                       + "    ) "
                       + "    VALUES "
                       + "    ( "
                       + "        '" + "12367876" + "', "
                       + "        '" + "1297094" + "', "
                       + "        '" + huella + "', "
                       + "        '" + "Primario" + "' "
                       + "    )";
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
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
