﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.IO;
using System.Drawing;

namespace webFingerprintGasCaqueta.View.Private.Parametrizacion.LectorBiometrico
{
    public partial class Captura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [DirectMethod]
        public void CreateSessionImage(string Image) {
            Session["ConvertImagen"] = Image;
            IMDACTILAR.ImageUrl = "Imagen.aspx";
        }
        
    }
}