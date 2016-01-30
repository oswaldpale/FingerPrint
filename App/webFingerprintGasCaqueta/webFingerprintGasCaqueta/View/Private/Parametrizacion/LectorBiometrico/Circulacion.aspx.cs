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
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public bool buscarUsuario(string identificacion) {
            DataTable inforUsuario = Controllers.consultarInformacionUsuario(identificacion);
            bool tipoUsuario = false;
            if (inforUsuario.Rows.Count > 0)
            {
                DataRow _inforUsuario = inforUsuario.Rows[0];
                LTIPOUSUARIO.Text = _inforUsuario["USUARIO"].ToString();
                LUSUARIO.Text = _inforUsuario["NOMBRE"].ToString();
                LCARGO.Text = _inforUsuario["TIPO"].ToString();
                if (_inforUsuario["USUARIO"].ToString() == "EMPLEADO")
                {
                    tipoUsuario = true;
                }
               
            }
            return tipoUsuario;
        }
        [DirectMethod(Namespace = "parametro")]
        public void ChangeReaderInf(string state) {
            LESTADO.Text = state;
            if (state=="Dispositivo Desconectado")
            {
                LESTADO.Icon = Icon.Disconnect;
                LESTADO.Cls = "ReaderStateDisconnect";
            }
            else
            {
                LESTADO.Icon = Icon.Connect;
                LESTADO.Cls = "ReaderStateConnect";
            }
           
        }

    }
}