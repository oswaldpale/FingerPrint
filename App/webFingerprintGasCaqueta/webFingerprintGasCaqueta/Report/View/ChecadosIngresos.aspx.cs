using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.Report.View
{
    public partial class ChecadosIngresos : System.Web.UI.Page
    {
        ControllerReportCOD _controller = new ControllerReportCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            FSPRINCIPAL.Title = "LISTADO DE PERSONAL EN EL INTERIOR DE LA EMPRESA: " + Convert.ToString(DateTime.Now); 
            SCONTROL.DataSource = _controller.reporteControlIngresoActual();
            SCONTROL.DataBind();
        }
    }
}