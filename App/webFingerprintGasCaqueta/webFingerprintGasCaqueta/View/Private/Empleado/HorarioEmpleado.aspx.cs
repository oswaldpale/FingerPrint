using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Private.Empleado
{
    public partial class Horario : System.Web.UI.Page
    {
        private ControllersCOD _Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.consultarEmpleadosHorarios();
            this.consultarPeriodo();
        }
        
        public void consultarEmpleadosHorarios() {
           SEMPLEADOS.DataSource =  _Controllers.consultarEmpleadosHorarios();
           SEMPLEADOS.DataBind();
        }
        public void consultarPeriodo() {
            SHORARIO.DataSource = _Controllers.consultarPeriodo();
            SHORARIO.DataBind();
        }
    }
}