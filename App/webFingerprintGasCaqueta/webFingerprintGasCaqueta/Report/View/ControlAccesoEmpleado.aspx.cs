using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
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
            Global.path2 = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/"));
            DFECHAINICIO.MaxDate = DateTime.Now;
            DFECHAFIN.MaxDate = DateTime.Now;

        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public void FiltroAsistencia()
        {
            string sFechaInicio = Convert.ToDateTime(DFECHAINICIO.Text).ToString("yyyy-MM-dd");
            string sFechaFin = Convert.ToDateTime(DFECHAFIN.Text).ToString("yyyy-MM-dd");
            DataTable _DataAsistencia = _Controllers.ListarreporteControlAsitenciasEmpleados(sFechaInicio, sFechaFin);
            Session.Remove("DataAsistencia");
            Session["DataAsistencia"] = _DataAsistencia;
            SCONTROL.DataSource = _DataAsistencia;
            SCONTROL.DataBind();
        }
        #region REPORTES
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Generando reporte..", Target = MaskTarget.Page)]
        public void reporteAsistencia() {
            string sFechaInicio = Convert.ToDateTime(DFECHAINICIO.Text).ToString("yyyy-MM-dd");
            string sFechaFin = Convert.ToDateTime(DFECHAFIN.Text).ToString("yyyy-MM-dd");
            DataTable _DataAsistencia = (DataTable) Session["DataAsistencia"];
            _Controllers.ReporteAsistenciaEmpleado(sFechaInicio,sFechaFin, _DataAsistencia);
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Generando reporte..", Target = MaskTarget.Page)]
        public void ReporteAsistenciaEmpleadoIndividual(string identificacion) {
            string sFechaInicio = Convert.ToDateTime(DFECHAINICIO.Text).ToString("yyyy-MM-dd");
            string sFechaFin = Convert.ToDateTime(DFECHAFIN.Text).ToString("yyyy-MM-dd");
            DataTable _DataAsistencia = (DataTable)Session["DataAsistencia"];
            _Controllers.ReporteAsistenciaEmpleadoIndividual(sFechaInicio, sFechaFin, _DataAsistencia,identificacion);
        }
        #endregion
    }
}