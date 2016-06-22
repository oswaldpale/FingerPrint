using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Private.Parametrizacion.LectorBiometrico
{
    public partial class Incribir : System.Web.UI.Page
    {
        private string PEGE_ID = "-1";
        private string PEGE_DEDO = "Primario";
        private ControllersCOD Controllers = new ControllersCOD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["identificacion"] != null && Request.QueryString["tipo"] != null)
            {
                PEGE_ID = Request.QueryString["identificacion"].ToString();
                PEGE_DEDO = Request.QueryString["tipo"].ToString();
                HDEDO.Text = PEGE_DEDO;
                HIDENTIFICACION.Text = PEGE_ID;
                this.ConsultarInformacionUsuario(PEGE_ID);
            }
        }

        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        private void ConsultarInformacionUsuario(string identificacion)
        {
            DataTable DUSUARIO = Controllers.consultarInformacionUsuario(identificacion);

            DataRow row = DUSUARIO.Rows[0];
            FCAPTURA.Title = row["NOMBRE"].ToString();
            FCAPTURA.Icon = Ext.Net.Icon.User;
        }
    }
}