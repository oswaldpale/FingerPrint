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
    public partial class Festivos : System.Web.UI.Page
    {
        private ControllersCOD Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
                this.consultarFestivos();
          
        }
        [DirectMethod(ShowMask = true, Msg = "Cargando..", Target = MaskTarget.Page)]
        public void consultarFestivos()
        {
            SFESTIVOS.DataSource = Controllers.consultarFestivos();
            SFESTIVOS.DataBind();
        }
        [DirectMethod(ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool registrarFestivo()
        {
            string fecha = Convert.ToDateTime(TFECHA.Text).ToString("yyyy-MM-dd");
            string nombreFestivo = TNOMBRE.Text.Trim();
            return Controllers.registrarFestivo(fecha, nombreFestivo);
            
        }
        [DirectMethod(ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool eliminarFestivo(string id)
        {
            return Controllers.eliminarFestivo(id);
        }

        protected void consultarFechaExistente(object sender, RemoteValidationEventArgs e)
        {
            string fecha = Convert.ToDateTime(TFECHA.Text).ToString("yyyy-MM-dd");
            if (Controllers.consultarSiExisteVisitante(fecha) == true)
            {
                e.Success = true;
            }
            else
            {
                e.Success = false;
                e.ErrorMessage = "'Fecha festivo ya registrado!.";
            }
            System.Threading.Thread.Sleep(1000);
        }
    }
}