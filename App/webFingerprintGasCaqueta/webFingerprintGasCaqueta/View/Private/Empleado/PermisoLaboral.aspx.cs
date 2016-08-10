using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
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
            TFECHASOLICITUD.Text = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            this.CargarEmpleados();
            this.cargarTipoPermiso();
            this.CargarPermisosActivos();
            
        }
        [DirectMethod(ShowMask = true, Msg = "Cargando..", Target = MaskTarget.Page)]
        public void CargarEmpleados()
        {
            SEMPLEADO.DataSource = Controllers.consultarEmpleados();
            SEMPLEADO.DataBind();
        }
        [DirectMethod(ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool registrarPermisoHora(string tipo, string hini, string hfin)
        {

            string tiphora = (tipo == "CHORA") ? "HORA" : "DIA";
            string fechasol = Convert.ToDateTime(TFECHASOLICITUD.Text).ToString("yyyy-MM-dd");
            string codemp = HCODEMPLEADO.Text;
            string tipoperm = CDILIGENCIA.SelectedItems[0].Value;
            string obs = TOBSERVACION.Text;
            string fechahora = Convert.ToDateTime(DFECHAHORA.Text).ToString("yyyy-MM-dd");
            string horaInicio = Convert.ToDateTime(hini.ToString().Replace("\"", "")).ToString("HH:mm");
            string horaFin = Convert.ToDateTime(hfin.ToString().Replace("\"", "")).ToString("HH:mm");

            if (Controllers.registrarPermisoHora(codemp, tiphora, tipoperm, fechasol, "activo", fechahora, horaInicio, horaFin,obs)) 
            {
               
                FREGISTRO.Reset();
                WREGISTRO.Hide();
                return true;
            }
            else {
                X.Msg.Notify("Notificación", "Ha ocurrido un error.").Show();
                return false;
            }
           

        }
        [DirectMethod(ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool _registrarPermisoDia(string tipo)
        {
           
            string tiphora = (tipo == "CHORA") ? "HORA" : "DIA";
            string obs = TOBSERVACION.Text;
            string codemp = HCODEMPLEADO.Text;
            string fechasol = Convert.ToDateTime(TFECHASOLICITUD.Text).ToString("yyyy-MM-dd");
            string tipoperm = CDILIGENCIA.SelectedItems[0].Value;
            string fechaini = Convert.ToDateTime(DFECHAINI.Text).ToString("yyyy-MM-dd");
            string fechafin = Convert.ToDateTime(DFECHAFIN.Text).ToString("yyyy-MM-dd");

            if (Controllers.registrarPermisoDia(codemp, tiphora, tipoperm, fechasol, "activo", fechaini, fechafin,obs))
            {
                FREGISTRO.Reset();
                WREGISTRO.Hide();
                return true;
            }
            else
            {
                X.Msg.Notify("Notificación", "Ha ocurrido un error.").Show();
                return false;
            }
        }
        [DirectMethod(ShowMask = true, Msg = "Eliminando..", Target = MaskTarget.Page)]
        public bool eliminarPermiso(string codigo) {
            return Controllers.eliminarPermiso(codigo);
        }




        public void cargarTipoPermiso()
        {
            STIPO.DataSource = Controllers.consultarTipoPermiso();
            STIPO.DataBind();
        }

        #region GRILLA PERMISOS ACTIVOS
        [DirectMethod (ShowMask = true, Msg = "Cargando.", Target = MaskTarget.Page)]
        public void CargarPermisosActivos() {
            DataTable dt =  Controllers.consultarPermisosActivo();
            SPERMISO.DataSource = dt;
            SPERMISO.DataBind();
            DFECHAHORA.MinDate = DateTime.Now;
        }

       
        #endregion
    }
}