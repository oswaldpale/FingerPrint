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
                consultarHorarios();
            
            
        }
        [DirectMethod(ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public void registrarHorario(string horainicio,string horafin) {
            string nombre = TNOMBRE.Text.ToUpper();
            
            string horaInicio = Convert.ToDateTime(horainicio.ToString().Replace("\"", "")).ToString("HH:mm");
            string horaFin = Convert.ToDateTime(horafin.ToString().Replace("\"", "")).ToString("HH:mm");
            string tiempoTarde = TTIEMPOTARDE.Text;
            if (Controllers.registrarHorario(nombre,horaInicio,horaFin,tiempoTarde))
            {
                X.Msg.Notify("Notificación", "Registrado Exitosamente!.").Show();
                FREGISTRO.Reset();
                WREGISTRO.Hide();
                this.consultarHorarios();
            }
            else
            {
                X.Msg.Notify("Notificación", "Ha ocurrido un error!..").Show();
            }
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..")]
        public void consultarHorarios()
        {
            SHORARIO.DataSource =  Controllers.consultarHorarios();
            SHORARIO.DataBind();
        }
        [DirectMethod(ShowMask = true, Msg = "Eliminando..", Target = MaskTarget.Page)]
        public  bool eliminarHorario(string id)
        {
            return Controllers.eliminarHorario(id);
           
        }
    }
}