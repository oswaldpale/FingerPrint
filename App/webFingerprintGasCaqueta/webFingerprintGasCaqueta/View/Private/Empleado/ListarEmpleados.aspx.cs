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
            this.CargarEmpleados();
        }
        [DirectMethod(Namespace = "parametro")]
        public void CargarEmpleados() {
            SEMPLEADO.DataSource = Controllers.consultarEmpleados();
            SEMPLEADO.DataBind();
        }
        [DirectMethod(Namespace = "parametro")]
        public bool ConsultarEstadoHuella(string identificacion, string tipoHuella) {
            return Controllers.consultarEstadoHuella(identificacion, tipoHuella);
        }
        [DirectMethod(Namespace = "parametro")]
        public bool InactivarHorarioEmpleado(string codigoEmpleado) {
            return Controllers.inacticarHorarioEmpleado(codigoEmpleado);
        }

        #region Ventanas
        [DirectMethod(Namespace = "parametro")]
        public void AbrirVentanaIncripcionHuella(string identificacion,string TipoHuella) {

            Window win = new Window
            {
                ID = "WCAPTURAHUELLA",
                Title = "REGISTRO DE HUELLA: " + TipoHuella.ToUpper(),
                Height = 370,
                Width = 300,
                Modal = true,
                CloseAction = CloseAction.Destroy,
                Loader = new ComponentLoader
                {
                    Url = "../Parametrizacion/LectorBiometrico/Incribir.aspx?identificacion=" + identificacion + "&tipo=" + TipoHuella,
                    Mode = LoadMode.Frame,
                    LoadMask =
                {
                    ShowMask = true
                  
                }
                }
            };
            win.Listeners.Close.Handler = "parametro.CargarEmpleados();";
            win.Render(this.Form);
          
        }

        [DirectMethod(Namespace = "parametro")]
        public void AbrirVentanahorarioEmpleado(string codigo,string identificacion, string funcionario,string cargo)
        {

            Window win1 = new Window
            {
                ID = "WHORARIOLABORAL",
                Title = "HORARIO LABORAL: " +"(" + identificacion + ")" + funcionario.ToUpper()  + " - " + cargo,
                Height = 635,
                Width = 700,
                Modal = true,
                CloseAction = CloseAction.Destroy,
                Loader = new ComponentLoader
                {
                    Url = "../Empleado/HorarioEmpleado.aspx?idempleado="+ codigo,
                    Mode = LoadMode.Frame,
                    LoadMask =
                {
                    ShowMask = true

                }
                }
            };
            win1.Listeners.Close.Handler = "parametro.CargarEmpleados();";
            win1.Render(this.Form);

        }
        #endregion

        [DirectMethod(Namespace = "parametro")]
        public bool EliminarHuellaEmpleado(string identificacion, string dedo)
        {
            return Controllers.eliminarHuellaEmpleado(identificacion, dedo);

        }

    }
}
