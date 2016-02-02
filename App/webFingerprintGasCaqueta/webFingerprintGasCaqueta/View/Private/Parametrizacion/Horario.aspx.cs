using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Private.Parametrizacion
{
    public partial class Horario : System.Web.UI.Page
    {
        private ControllersCOD Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.consultarHorarios();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public void registrarHorario(string horainicio) {
            string nombre = TNOMBRE.Text.ToUpper();
            string horaInicio = Convert.ToDateTime(horainicio).ToString("T");
            string horaFin = THFIN.Text;
            string tiempoTarde = TTIEMPOTARDE.Text;
            if (Controllers.registrarHorario(nombre,horaInicio,horaFin,tiempoTarde))
            {
                X.Msg.Notify("Notificación", "Registrado Exitosamente!.").Show();
                this.consultarHorarios();
                FREGISTRO.Reset();
            }
            else
            {
                X.Msg.Notify("Notificación", "Ha ocurrido un error!..").Show();
            }
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public void consultarHorarios()
        {
            Controllers.consultarHorarios();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Eliminando..", Target = MaskTarget.Page)]
        public void EliminarHorario(string id)
        {
            if ( Controllers.eliminarHorario(id))
            {
                X.Msg.Notify("Notificación", "Eliminado Exitosamente!..").Show();
            }
            else
            {
                X.Msg.Notify("Notificación", "Ha ocurrido un error!..").Show();
            }
        }
    }
}