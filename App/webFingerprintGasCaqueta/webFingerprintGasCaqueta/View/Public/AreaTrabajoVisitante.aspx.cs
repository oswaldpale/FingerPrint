using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;
using Ext.Net;

namespace webFingerprintGasCaqueta.View.Public
{
    public partial class VisitaAreaTrabajo : System.Web.UI.Page
    {
        ControllersCOD _controller = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarCombobox();
        }
        
        [DirectMethod(ShowMask = true, Msg = "Cargando..", Target = MaskTarget.Page)]
        public void cargarCombobox() {
            SDEPENDENCIA.DataSource =  _controller.consultarArea();
            SDEPENDENCIA.DataBind();
        }
        public bool registrarAreaVisita() {
            return true;
        }
    }
}