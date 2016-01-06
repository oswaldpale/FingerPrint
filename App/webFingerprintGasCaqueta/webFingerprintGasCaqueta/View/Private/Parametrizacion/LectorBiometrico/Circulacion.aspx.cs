using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Public
{
    public partial class Empleado_circulacion : System.Web.UI.Page
    {
        private string PEGE_ID = "02011235153";
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
        public bool registrarHuella(string huella, string empleado)
        {
            return Controllers.registrarHuella(huella, PEGE_ID,"Primario");
        }
    }
}