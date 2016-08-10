using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Private.Parametrizacion
{
    public partial class AreaTrabajo : System.Web.UI.Page
    {
        private ControllersCOD Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest) {
                this.consultarArea();
            }
            

        }
        [DirectMethod(ShowMask = true, Msg = "Cargando..", Target = MaskTarget.Page)]
        public void consultarArea()
        {
            SAREA.DataSource = Controllers.consultarArea();
            SAREA.DataBind();
        }
        [DirectMethod(ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool registrarArea()
        {
            string codigo = TCODIGO.Text.Trim();
            string area = TAREA.Text.Trim();
            string ext = TEXT.Text.Trim();
            return Controllers.registrarArea(codigo, area, ext);

        }
        [DirectMethod(ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool eliminarArea(string codigo)
        {
            return Controllers.eliminarArea(codigo);
        }

        [DirectMethod]
        public object modificarArea(string codigo,JsonObject values)
        {
            string cod = codigo;
            string area = values["AREA"].ToString();
            string ext = values["EXT"].ToString();
            if(Controllers.modificarArea(codigo, area, ext)){
                return new { valid = true };
            }
            return new { valid = false};
        }

    }
}