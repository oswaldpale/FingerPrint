using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Private.Visitante
{
    public partial class Registrar : System.Web.UI.Page
    {
        private ControllersCOD Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ConsultarVisitantes();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool registrarVisitante() {
            string Tidentificacion = TIDENTIFICACION.Text.Trim();
            string Tnombre = TNOMBRE.Text.Trim();
            string Tapellido1 = TAPELLIDO1.Text.Trim();
            string Tapellido2 = TAPELLIDO2.Text.Trim();
            string Ttelefono = TTELEFONO.Text.Trim();
            string Tdireccion = TDIRECCIÓN.Text.Trim();
            string Tfoto = "";

            return Controllers.registrarVisitante(Tidentificacion, Tnombre, Tapellido1, Tapellido2, Ttelefono, Tdireccion, Tfoto);
        }
        [DirectMethod(Msg = "Cargando...", ShowMask = true, Target = MaskTarget.CustomTarget)]
        public bool modificarVisistante() {

            string Tidentificacion = TIDENTIFICACION.Text.Trim();
            string Tnombre = TNOMBRE.Text.Trim();
            string Tapellido1 = TAPELLIDO1.Text.Trim();
            string Tapellido2 = TAPELLIDO2.Text.Trim();
            string Ttelefono = TTELEFONO.Text.Trim();
            string Tdireccion = TDIRECCIÓN.Text.Trim();
            string Tfoto = "";
         
            return Controllers.modificarVisitante(Tidentificacion, Tnombre, Tapellido1, Tapellido2, Ttelefono, Tdireccion, Tfoto);
        }

        [DirectMethod]
        public void ConsultarVisitantes() {
            SVISITANTE.DataSource =  Controllers.consultarVisitantes();
            SVISITANTE.DataBind();
        }
        [DirectMethod(Namespace = "parametro")]
        public bool EliminarHuella(string identificacion,string dedo)
        {
             return Controllers.eliminarHuellaVisitante(identificacion,dedo);
            
        }
        [DirectMethod]
        public bool consultarSiExisteVisitante() {
            string SIdentificacion = TIDENTIFICACION.Text.Trim();
            if (Controllers.consultarSiExisteVisitante(SIdentificacion))
            {
                return true;
            }
            else
            {
                return false ;
            }
        }
        [DirectMethod(Namespace = "parametro")]
        public void AbrirVentanaIncripcionHuella(string identificacion, string TipoHuella)
        {
            Window win = new Window
            {
                ID = "WCAPTURAHUELLA",
                Title = "REGISTRO DE HUELLA: " + TipoHuella.ToUpper(),
                Height = 386,
                Width = 290,
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

            win.Render(this.Form);

        }

        [DirectMethod]
        public void AbrirCamaraWeb()
        {
            string identificacion = TIDENTIFICACION.Text; ;
            string tipo = "VISITANTE";

         
            Window win = new Window
            {
                ID = "WCAMARAWEB",
                Title = "CAMBIAR FOTO",
                Height = 515,
                Width = 444,
                UI = UI.Info,
                Modal = true,
                CloseAction = CloseAction.Destroy,
                Loader = new ComponentLoader
                {
                    Url = "../Parametrizacion/CamaraWeb/CapturarFoto.aspx?identificacion=" + identificacion + "&tipo=" + tipo,
                    Mode = LoadMode.Frame,
                    LoadMask =
                {
                    ShowMask = true

                }
                }
            };
            win.Listeners.Close.Handler = "App.direct.cargarFotoVisitante(" + identificacion + ");";
            win.Render(this.Form);

           
        }
        [DirectMethod]
        public void cargarFotoVisitante(string identificacion) {
            string FotoBinary = Controllers.consultarRutaFotoVisitante(identificacion);
            if (FotoBinary != null ) {
                IMPERFIL.ImageUrl = "data:image/jpg;base64," + FotoBinary + "";
            }
             
        }

        protected void consultarSiExisteVisitante(object sender, RemoteValidationEventArgs e)
        {
            string SIdentificacion = TIDENTIFICACION.Text.Trim();
            if (Controllers.consultarSiExisteVisitante(SIdentificacion) == true)
            {
                e.Success = true;
            }
            else
            {
                e.Success = false;
                e.ErrorMessage = "'Visitante ya existe!.";
            }
            System.Threading.Thread.Sleep(1000);
        }
    }
}