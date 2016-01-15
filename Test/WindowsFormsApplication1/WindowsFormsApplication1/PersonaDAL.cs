using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;


namespace WindowsFormsApplication1
{
    class PersonaDAL
    {
       
        private  DPFP.FeatureSet features; 

        public static int AgregarPersona(Persona pPersona)
        {
            int retorno = 0;
            using (MySqlConnection conn = BDconexion.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO huella(huell_id,huell_identificacion,huell_huella,huell_dedo) VALUES (@huell_id,@huell_identificacion,@huell_huella,@huell_dedo)";
                    cmd.Parameters.AddWithValue("@huell_id", pPersona.Id);
                    cmd.Parameters.AddWithValue("@huell_identificacion", pPersona.Id);
                    cmd.Parameters.AddWithValue("@huell_huella", pPersona.Huella1);
                    cmd.Parameters.AddWithValue("@huell_dedo", "Primario");
                    retorno = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            return retorno;
        }


        public static Persona ObtenerPersonaID(int pId)
        {
            Persona pPersona = new Persona();
           using (MySqlConnection conn = BDconexion.ObtenerConexion())
            {

                MySqlCommand _comando = new MySqlCommand(String.Format("SELECT cedula,nombres, ape1, ape2, telefono, foto FROM persona where cedula={0}", pId), conn);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pPersona.Id = Convert.ToInt32(_reader.GetValue(0));
                pPersona.Nombre = Convert.ToString(_reader.GetValue(1));
                pPersona.PrimerApellido = Convert.ToString(_reader.GetValue(2));
                pPersona.SegundoApellido = _reader.GetString(3);
                pPersona.Telefono =  Convert.ToString(_reader.GetValue(4));
                pPersona.Foto = (byte[]) _reader.GetValue(5);

            }
            conn.Close();
            return pPersona;
           }
        }
        public static List<Persona> ListarPersona()
        {
            using (MySqlConnection conn = BDconexion.ObtenerConexion())
            {
                List<Persona> _lista = new List<Persona>();
                MySqlCommand _comando = new MySqlCommand(String.Format("SELECT '111' AS cedula,'OSWALDO' AS nombres,'LEAL' AS ape1,'PAMO' AS  ape2,huell_huella AS huella1,huell_huella AS huella2,' ' AS foto FROM huella"), conn);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Persona pPersona = new Persona();
                    pPersona.Id = Convert.ToInt32(_reader.GetValue(0));
                    pPersona.Nombre = Convert.ToString(_reader.GetValue(1));
                    pPersona.PrimerApellido = Convert.ToString(_reader.GetValue(2));
                    pPersona.SegundoApellido = Convert.ToString(_reader.GetValue(3));             
                    pPersona.Huella1 = (byte[])_reader.GetValue(4);
                    pPersona.Huella2 = (byte[])_reader.GetValue(5);
                    //pPersona.Foto = (byte[])_reader.GetValue(6);
                    _lista.Add(pPersona);
                }
              //  conn.Close();
                return _lista;
            }

        }
        public bool VerificarHuella(byte[] huella)
        {
            DPFP.Verification.Verification.Result resulta = new DPFP.Verification.Verification.Result();
            DPFP.Verification.Verification verify = new DPFP.Verification.Verification();
            DPFP.Template templates = new DPFP.Template();
            MemoryStream stream = new MemoryStream(huella);
            DPFP.Template templatess = new DPFP.Template(stream);
            templatess.DeSerialize((byte[])huella);
            verify.Verify(features, templatess, ref resulta);
            return (resulta.Verified);
        }
        public Persona ObtenerPersonaHuella(DPFP.FeatureSet features)
        {
            this.features = features;
            
            foreach (Persona pPersona in ListarPersona()) {
                if(VerificarHuella(pPersona.Huella1) || VerificarHuella(pPersona.Huella2)){
                  return pPersona;
                }
            }
            return null;
        }

        public static int EliminarPersona(int pId)
        {
            int retorno = 0;
             using (MySqlConnection conn = BDconexion.ObtenerConexion())
            {
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From persona where cedula={0}", pId), conn);
            retorno = comando.ExecuteNonQuery();
            conn.Close();
            return retorno;
            }
        }
        public static int ActualizarPersona(Persona pPersona)
        {
            int retorno = 0;
            using (MySqlConnection conn = BDconexion.ObtenerConexion())
            {

                MySqlCommand comando = new MySqlCommand(string.Format("Update persona set cedula='{0}', ape1='{1}', ape2='{2}', telefono='{3}', huella1='{4}', huella2='{5}', foto='{6}', fk_tipoper='{7}'  where cedula={8}",
                pPersona.Nombre, pPersona.PrimerApellido, pPersona.SegundoApellido, pPersona.Telefono, pPersona.Huella1, pPersona.Huella2, pPersona.Foto, pPersona.Id), conn);
            retorno = comando.ExecuteNonQuery();
            conn.Close();
            return retorno;
            }
        }
        public static List<Persona> Buscar(string pNombre, string pApellido)
        {
            using (MySqlConnection conn = BDconexion.ObtenerConexion())
            {
            List<Persona> _lista = new List<Persona>();
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT cedula, nombres, ape1, ape2, telefono, fk_tipoper FROM persona  where nombres ='{0}' or ape1='{1}'", pNombre, pApellido), conn);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Persona pPersona = new Persona();
                pPersona.Id = _reader.GetInt32(0);
                pPersona.Nombre = _reader.GetString(1);
                pPersona.PrimerApellido = _reader.GetString(2);
                pPersona.SegundoApellido = _reader.GetString(3);
                pPersona.Telefono = _reader.GetString(4);
            //    pPersona.Foto = (byte[])_reader.GetValue(5);
                _lista.Add(pPersona);
            }

            return _lista;
            }
        }
    }
}
