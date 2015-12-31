﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.IO;
using System.Drawing;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Private.Parametrizacion.LectorBiometrico
{
    public partial class Captura : System.Web.UI.Page
    {
        private ControllersCOD Controllers  = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [DirectMethod]
        public void CreateSessionImage(string Image,string idImagen) {
                Session.Remove("ConvertImagen");
                Session["ConvertImagen"] = Image;
                IMDACTILAR.ImageUrl = "Imagen.aspx?id=" +idImagen;
        }
        [DirectMethod(Namespace = "parametro")]
        public bool registrarHuella(string huella,string usuario) {
            return Controllers.registrarHuella(huella, usuario);
        }

    }
}