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
    public partial class Funcionario : System.Web.UI.Page
    {
        ControllersCOD _controller = new ControllersCOD();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [DirectMethod]
        public void AbrirCamaraWeb()
        {

            Window win = new Window
            {
                ID = "WCAMARAWEB",
                Title = "CAMARA WEB:",
                Height = 400,
                Width = 700,
                UI=UI.Info,
                Modal = true,
                CloseAction = CloseAction.Destroy,
                Loader = new ComponentLoader
                {
                    Url = "../Parametrizacion/CamaraWeb/CapturarFoto.aspx",
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