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
    public partial class PeriodoSemanal : System.Web.UI.Page
    {
        private ControllersCOD Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.consultarHorarioPeriodo();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public void consultarHorarioPeriodo() {
            SHORARIO.DataSource = Controllers.ConsultarHorariosPeriodos();
            SHORARIO.DataBind();
        }
        [DirectMethod(Namespace = "parametro")]
        public void AbrirVentanaHorario()
        {
            Window win = new Window
            {
                ID = "WHORARIO",
                Title = "FRANJA HORARIA",
                Height = 370,
                Width = 720,
                Modal = true,
                CloseAction = CloseAction.Destroy,
                Loader = new ComponentLoader
                {
                    Url = "../Parametrizacion/Horario.aspx",
                    Mode = LoadMode.Frame,
                    LoadMask =
                {
                    ShowMask = true

                }
                }
            };
            win.Listeners.Close.Handler = "parametro.consultarHorarioPeriodo();";
            win.Render(this.Form);

        }

    }
}