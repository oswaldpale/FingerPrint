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
using System.Data;

namespace webFingerprintGasCaqueta.View.Private.Parametrizacion.LectorBiometrico
{
    public partial class Captura : System.Web.UI.Page
    { 
        private string PEGE_ID = "-1";
        private string PEGE_DEDO = "Primario";
        private ControllersCOD Controllers  = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["identificacion"] != null && Request.QueryString["tipo"] != null) {
                PEGE_ID = Request.QueryString["identificacion"].ToString();
                PEGE_DEDO = Request.QueryString["tipo"].ToString();
                HDEDO.Text = PEGE_DEDO;
                HIDENTIFICACION.Text = PEGE_ID;
                this.ConsultarInformacionUsuario(PEGE_ID);
            }
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        private void ConsultarInformacionUsuario(string identificacion) {
            DataTable DUSUARIO = Controllers.consultarInformacionUsuario(identificacion);

            DataRow row =  DUSUARIO.Rows[0];
            FCAPTURA.Title = row["NOMBRE"].ToString();
            FCAPTURA.Icon = Ext.Net.Icon.User;
        }
        [DirectMethod(Msg = "Consultando..", Target = MaskTarget.Body, Timeout =50000)]
        public void CreateSessionImage(string Image, string idImagen)
        {
            Session["ConvertImagen"] = Image;
            //IMDACTILAR.ImageUrl = "Imagen.aspx?id=" + idImagen;
            IMDACTILAR.ImageUrl = "../../../../Imagen.aspx?id=" + idImagen;
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Registrando..", Target = MaskTarget.Page)]
        public bool registrarHuella(string huella) {
            //return Controllers.registrarHuella(huella, PEGE_ID, PEGE_DEDO);
            return true;
        }
      
    }
}