using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;


namespace webFingerprintGasCaqueta.View.Private.Empleado
{
    public partial class PermisoLaboral : System.Web.UI.Page
    {
        private ControllersCOD Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            DFECHAINI.MinDate = DateTime.Now;
            DFECHAHORA.MinDate = DateTime.Now;
            TFECHASOLICITUD.Text = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            this.CargarEmpleados();
            this.cargarTipoPermiso();
        }
        [DirectMethod(Namespace = "parametro")]
        public void CargarEmpleados()
        {
            SEMPLEADO.DataSource = Controllers.consultarEmpleados();
            SEMPLEADO.DataBind();
        }
        [DirectMethod(ShowMask = true, Msg = "Guardando..")]
        public void registrarPermiso(string tipo,string horainicio,string horafin)
        {
            string tiphora = (tipo == "MHORA") ? "HORA" : "DIA";
            string fechasol = Convert.ToDateTime(TFECHASOLICITUD.Text).ToString("yyyy-MM-dd"); 
            string fechaini = Convert.ToDateTime(DFECHAINI.Text).ToString("yyyy-MM-dd");
            string fechafin = Convert.ToDateTime(DFECHAFIN.Text).ToString("yyyy-MM-dd");
            string codemp = HCODEMPLEADO.Text;
            string tipoperm = CTIPO.ActiveItem.ToString();
            string horaInicio = Convert.ToDateTime(horainicio.ToString().Replace("\"", "")).ToString("HH:mm");
            string horaFin = Convert.ToDateTime(horafin.ToString().Replace("\"", "")).ToString("HH:mm");
            string obs = TOBSERVACION.Text;
            string fechahora = Convert.ToDateTime(DFECHAHORA.Text).ToString("yyyy-MM-dd"); 

            if (tiphora == "HORA")
            {
                Controllers.registrarPermisoHora(codemp,tiphora,tipoperm,fechasol,"activo",fechahora,horainicio,horafin);
            }
            //else
            //{
            //    return Controllers.registrarPermisoDia(codemp,tipotiempo,tipoperm,fechasol,"activo",fecha);
            //}

        }
        public void cargarTipoPermiso() {
            STIPO.DataSource = Controllers.consultarTipoPermiso();
            STIPO.DataBind();
        }

    }
}