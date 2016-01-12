using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Private.Visitante
{
    public partial class Registrar : System.Web.UI.Page
    {
        private ControllersCOD Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ConsultarVisitantes();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public void registrarVisitante() {
            string Tidentificacion = TIDENTIFICACION.Text.Trim();
            string Tnombre = TNOMBRE.Text.Trim();
            string Tapellido1 = TAPELLIDO1.Text.Trim();
            string Tapellido2 = TAPELLIDO2.Text.Trim();
            string Tobservacion = TOBSERVACIÓN.Text.Trim();
            string Tfoto = " ";

            if (Controllers.registrarVisitante(Tidentificacion, Tnombre, Tapellido1, Tapellido2, Tobservacion, Tfoto))
            {
                X.Msg.Notify("Notificación","Registrado Exitosamente!.").Show();
                this.ConsultarVisitantes();
                FREGISTRO.Reset();

            }
            else
            {
                X.Msg.Notify("Notificación", "Ha ocurrido un error!..").Show();
            }
            
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public void ConsultarVisitantes() {
            SVISITANTE.DataSource =  Controllers.consultarVisitantes();
            SVISITANTE.DataBind();
        }
        [DirectMethod]
        public bool consultarSiExisteVisitante() {
            string SIdentificacion = TIDENTIFICACION.Text.Trim();
            if (Controllers.consultarSiExisteVisitante(SIdentificacion))
            {
                return true;
            }
            else
            {
                return false ;
            }
        }
        protected void consultarSiExisteVisitante(object sender, RemoteValidationEventArgs e)
        {
            string SIdentificacion = TIDENTIFICACION.Text.Trim();
            if (Controllers.consultarSiExisteVisitante(SIdentificacion))
            {
                e.Success = true;
            }
            else
            {
                e.Success = false;
                e.ErrorMessage = "'Visitante ya existe!.";
            }
            System.Threading.Thread.Sleep(1000);
        }
    }
}