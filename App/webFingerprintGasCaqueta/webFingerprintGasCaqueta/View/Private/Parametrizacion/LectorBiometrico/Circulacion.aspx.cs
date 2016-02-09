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

        #region CONTROL DE LA ENTRADA Y SALIDA
        [DirectMethod(Namespace = "parametro", ShowMask = true, Target = MaskTarget.Page)]
        public bool consultarTipoIngreso(string identificacion)
        {
            bool RegUserDoor = false;                            //Estado de entrada o Salida.
            DataTable _DInAcceso = Controllers.consultarTipoIngreso(identificacion);
            if (_DInAcceso.Rows.Count > 0)
            {
                string InAcceso = _DInAcceso.Rows[0]["INGRESOESTADO"].ToString();
                TIDTUPLA.Text = _DInAcceso.Rows[0]["ID"].ToString();
                return (RegUserDoor = (InAcceso == "SALIDA") ? true : false);  //SI ES TRUE ES UNA SALIDA
            }
            else
            {
                return RegUserDoor;
            }
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool registrarEntrada(string identificacion) {
        
            return Controllers.registrarEntrada(identificacion);
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool registrarSalida(string idTupla, string identificacion) {
            return Controllers.registrarSalida(idTupla,identificacion);
        }
        #endregion

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
                string ident = _inforUsuario["IDENTIFICACION"].ToString();
                TIDUSER.SetValue(ident);
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