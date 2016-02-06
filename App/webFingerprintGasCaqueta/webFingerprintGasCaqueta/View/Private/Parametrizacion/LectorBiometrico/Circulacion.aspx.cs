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
        public void ListarUsuarios() {
            SUSUARIO.DataSource = Controllers.ListarUsuarios();
            SUSUARIO.DataBind();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public bool consultarTipoIngreso(string identificacion) {
            bool RegUserDoor= false;                            //Estado de entrada o Salida.
            string InAcceso = Controllers.consultarTipoIngreso().Rows[0][""].ToString();
            return(RegUserDoor = (InAcceso == "ENTRADA") ? true:false);
            
        }

        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public bool buscarUsuario(string identificacion) {
          
            DataTable inforUsuario = Controllers.consultarInformacionUsuario(identificacion);
            bool tipoUsuario = false;
            if (inforUsuario.Rows.Count > 0)
            {
                DataRow _inforUsuario = inforUsuario.Rows[0];
                TUSUARIO.Text = _inforUsuario["NOMBRE"].ToString().ToUpper();
                TCARGO.SetValue(_inforUsuario["CARGO"].ToString().ToUpper());
                TTIPOOUSUARIO.Text = _inforUsuario["TIPO"].ToString().ToUpper();
                HIDUSER.Text = _inforUsuario["IDENTIFICACION"].ToString();
                if (_inforUsuario["TIPO"].ToString() == "Empleado")
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