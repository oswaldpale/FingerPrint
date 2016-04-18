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
        }
        [DirectMethod(Namespace = "parametro")]
        public void CargarEmpleados()
        {
            SEMPLEADO.DataSource = Controllers.consultarEmpleados();
            SEMPLEADO.DataBind();
        }
        [DirectMethod(Namespace = "parametro")]
        public void registrarPermiso()
        {
            
        }

    }
}