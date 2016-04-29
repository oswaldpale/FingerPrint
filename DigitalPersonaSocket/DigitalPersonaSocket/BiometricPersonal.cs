using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket;
using System.Windows.Forms;
using System.Drawing;
using System.ServiceProcess;
using System.Threading;
using SuperWebSocket;
using SuperSocket.SocketBase;
using DPFP;
using DPFP.Capture;
using System.IO;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;

namespace DigitalPersonaSocket
{
    public partial class BiometricPersonal : ServiceBase, DPFP.Capture.EventHandler
    {
        private WebSocketServer appServer;
        private const string _PORT_SOCKET = "2015";

        public int stateEnrroller = 0;     // controla el estado del proceso de incripción.
        public DPFP.Processing.Enrollment Enroller;  // incripcion de huella.
        public DPFP.Capture.Capture Capturer;    // controla la captura de la huella.
        public string typeProcces = "capture"; // tipo de proceso que ejecutara el lector (capture/validation) 
        public string bitmapDactilar = null;
        public string dedo = "Primario";
        public string stateUserVerify = null;
        public Int64 identificacion;
        public bool resultRegister;
        #region METODOS DE INICIALIZACION
        /// <summary>
        /// Metodos de Control de eventos.
        /// </summary>
        /// 

        private void Connect() {
            Init();
            Start();
        }
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
            this.stateEnrroller = (int)Enroller.FeaturesNeeded;
        }

        public void Start()
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

        public void Pause()
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
            if (features != null)
                try
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
                            Huella _huella = new Huella();
                            _huella._identificacion = identificacion;
                            _huella._huella1 = footprintByte;
                            _huella._dedo = dedo;
                            resultRegister = HuellaOAD.Registrarhuella(_huella) > 0 ? true : false;
                            this.Pause();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            this.Pause();
                            Start();
                            break;
                    }
                }
        }
        private void Validate(DPFP.Sample Sample)
        {
            BitMapToString(ConvertSampleToBitmap(Sample)); // CREO LA IMAGEN DE LA HUELLA.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            if (features != null)
            {

                UpdateStatus(); //Actualiza el estado del lector.
                this.stateUserVerify = ValidateOneFingerPrint(features) ? "true" : "false";
               
            }
        }

        private bool ValidateOneFingerPrint(FeatureSet features)
        {

            List<Huella> _dataHuella = HuellaOAD.consultarHuella(identificacion);
            foreach (Huella item in _dataHuella)
            {

                if (VerifyFinger(item._huella1, features) == true)
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

        //public void DowloadFinger(string FilterFinger)
        //{
        //    FingerPrint _finger = new FingerPrint();
        //    _finger = JsonConvert.DeserializeObject<FingerPrint>(FilterFinger);
        //    _filterFinger.Add(_finger);
        //}

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
        public string StringToByte(byte[] footprintByte)
        {
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

        #region METODOS DE CONVERSION DE IMAGEN
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
            return bitmap;
        }
        #endregion

        #region SERVICIO DE WINDOWS.
        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {

            Thread ComThread = new Thread(() =>
            {
                Connect();
            });

            ComThread.SetApartmentState(ApartmentState.STA);
            ComThread.Start();

            RunServer();

        }

        private void RunServer()
        {
            appServer = new WebSocketServer();
            appServer.Setup(Convert.ToInt32(_PORT_SOCKET));
            appServer.NewMessageReceived += new SessionHandler<WebSocketSession, string>(appServer_Register);
            appServer.Start();
        }

        private void appServer_Register(WebSocketSession session, string message)
        {

            string json = message;

            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

            dynamic obj = serializer.Deserialize(json, typeof(object));

            string type = obj.type;
            string user = "";

            switch (type)
            {
                case "register":
                    user = obj.payload[0].user;
                    break;
                case "validate":
                    user = obj.payload[0].user;
                    //string data = RecuperarHuella(user);
                    //session.Send(data);
                    break;
                default:
                    break;
            }

        }

        protected override void OnStop() { }

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            if (typeProcces == "capture")   // Si typeProcces es igual capture: Ejecuta proceso de Incripcion
            {
                Process(Sample);
            }
            else                           // Sino ejecuta el processo de Validación.
            {
                Validate(Sample);
            }

        }
        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            if (appServer.SessionCount > 0)
            {
                foreach (WebSocketSession session in appServer.GetAllSessions())
                {
                    session.Send(Convert.ToString("Se ha Conectado el Lector.. "));
                }
            } 
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            if (appServer.SessionCount > 0)
            {
                foreach (WebSocketSession session in appServer.GetAllSessions())
                {
                    session.Send(Convert.ToString("Se ha Desconectado el Lector.. "));
                }
            }
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            throw new NotImplementedException();
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
         
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
           
        }
        #endregion


    #region PERSISTENCIA OAD
    public class HuellaOAD
    {
        public static int Registrarhuella(Huella phuella)
        {
            int retorno = 0;
            using (MySqlConnection conn = InternConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO huella(huell_identificacion,huell_huella,huell_dedo) VALUES (@huell_identificacion,@huell_huella,@huell_dedo)";
                    cmd.Parameters.AddWithValue("@huell_identificacion", phuella._identificacion);
                    cmd.Parameters.AddWithValue("@huell_huella", phuella._huella1);
                    cmd.Parameters.AddWithValue("@huell_dedo", phuella._dedo);
                    retorno = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            return retorno;
        }
        public static List<Huella> consultarHuella(Int64 identificacion)
        {
            using (MySqlConnection conn = InternConexionBD.ObtenerConexion())
            {
                List<Huella> _lista = new List<Huella>();
                string sql = "SELECT  huell_identificacion,huell_huella FROM huella WHERE huell_identificacion= '" + identificacion + "'";
                MySqlCommand _comando = new MySqlCommand(sql, conn);
                MySqlDataReader _reader = _comando.ExecuteReader();

                while (_reader.Read())
                {

                    Huella pHuella = new Huella();
                    pHuella._identificacion = _reader.GetUInt32(0);
                    pHuella._huella1 = (byte[])_reader.GetValue(1);
                    _lista.Add(pHuella);

                }


                return _lista;
            }
        }
    }
    public class General
    {
        private InternConexionBD connection = new InternConexionBD();
    }
    #endregion
    #region CONEXION A LA BASE DE DATOS
    /// <summary>
    /// Conexion a la base de datos para consultar o registrar huellas.
    /// </summary>
    class InternConexionBD
    {
        public static MySqlConnection ObtenerConexion()
        {
            //string connectServer = "server=192.168.0.100; database=control_acceso; Uid=planta; pwd=planta123;";
            //string connectServer = "server=192.168.0.91; database=control_acceso; Uid=planta; pwd=planta123;";
            string connectServer = "server=127.0.0.1; database=control_acceso; Uid=root; pwd=root;";
            MySqlConnection conectar = new MySqlConnection(connectServer);
            conectar.Open();
            return conectar;
        }
    }

        #endregion


        #region ENTIDAD
        public class Huella
        {
            public Int64 _identificacion { get; set; }
            public byte[] _huella1 { get; set; }
            public string _dedo { get; set; }
            public Huella() { }
            public Huella(int primaryKey, Int64 ident, byte[] huella, string dedo)
            {
                this._identificacion = ident;
                this._huella1 = huella;
                this._dedo = dedo;
            }
        }
        #endregion
    }

}
