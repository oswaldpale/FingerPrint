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
    public partial class ListarEmpleado : System.Web.UI.Page
    {
        private ControllersCOD Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.CargarEmpleados();
        }
        private void CargarEmpleados() {
            SEMPLEADO.DataSource = Controllers.consultarEmpleados();
            SEMPLEADO.DataBind();
        }
        [DirectMethod(Namespace = "parametro")]
        public void AbrirVentanaIncripcionHuella(string identificacion,string TipoHuella) {
            Window win = new Window
            {
                ID = "WCAPTURAHUELLA",
                Title = "Registro dedo " + TipoHuella,
                Height = 500,
                Width = 450,
                BodyPadding = 5,
                Modal = true,
                
                CloseAction = CloseAction.Destroy,
                Loader = new ComponentLoader
                {
                    Url = "../Parametrizacion/LectorBiometrico/Captura.aspx?identificacion="+ identificacion + "&tipo=" + TipoHuella,
                    Mode = LoadMode.Frame,
                    LoadMask =
                {
                    ShowMask = true
                }
                }
            };

            win.Render(this.Form);

        }
    }
}