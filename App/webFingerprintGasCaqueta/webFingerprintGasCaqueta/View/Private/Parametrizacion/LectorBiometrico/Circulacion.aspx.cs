using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;
using Newtonsoft.Json;
using System.Data;

namespace webFingerprintGasCaqueta.View.Public
{
    public partial class Empleado_circulacion : System.Web.UI.Page
    {
        private string PEGE_ID = "10012914";
        private ControllersCOD Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [DirectMethod]
        public void CreateSessionImage(string Image, string idImagen)
        {
            Session.Remove("ConvertImagen");
            Session["ConvertImagen"] = Image;
            IMDACTILAR.ImageUrl = "Imagen.aspx?id=" + idImagen;
        }
      
        [DirectMethod(Namespace = "parametro")]
        public string consultarHuellas(string identificacion) {
            List<FingerPrint> _UsuarioHuella = new List<FingerPrint>();
            DataTable DhuellaUsuario = Controllers.consultarHuellaPorUsuario(identificacion);
            foreach (DataRow row  in DhuellaUsuario.Rows)
            {
                FingerPrint _huella = new FingerPrint();
                _huella.finger = row["huell_huella"].ToString();
                _huella.iduser = row["emple_codempleado"].ToString();
                _UsuarioHuella.Add(_huella);
            }
            return JsonConvert.SerializeObject(_UsuarioHuella);
        }
    }
    public class FingerPrint
    {
        public string finger { get; set; }
        public string iduser { get; set; }
    }
}