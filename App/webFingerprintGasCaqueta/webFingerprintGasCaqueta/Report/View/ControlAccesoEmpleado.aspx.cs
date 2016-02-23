using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.Report.View
{
    public partial class ControlAccesoEmpleado : System.Web.UI.Page
    {
        private ControllerReportCOD _Controllers = new ControllerReportCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            DFECHAINICIO.MaxDate = DateTime.Now;
            DFECHAFIN.MaxDate = DateTime.Now;

        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public void FiltroAsistencia()
        {
            string sFechaInicio = Convert.ToDateTime(DFECHAINICIO.Text).ToString("yyyy-MM-dd");
            string sFechaFin = Convert.ToDateTime(DFECHAFIN.Text).ToString("yyyy-MM-dd");
            SCONTROL.DataSource = _Controllers.ListarreporteControlAsitenciasEmpleados(sFechaInicio, sFechaFin);
            SCONTROL.DataBind();
        }
    }
}