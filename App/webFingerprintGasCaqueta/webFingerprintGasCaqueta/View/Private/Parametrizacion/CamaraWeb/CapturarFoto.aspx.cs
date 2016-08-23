using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;
using Ext.Net;
using System.IO;

namespace webFingerprintGasCaqueta.View.Private.Parametrizacion
{
    public partial class CapturarFoto : System.Web.UI.Page
    {
        public string PEGE_ID = "-1";
        public string PEGE_TIPO = "-1";
        public string PEGE_RUTAFOTOFUNCIONARIO = "D:\\SIGC\\Bdatos\\Fotos\\";
        public string TITLEPEGE_FOTO = "PRUEBA.JPG";
        ControllersCOD _controllers = new ControllersCOD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["identificacion"] != null && Request.QueryString["tipo"] != null)
            {
                PEGE_ID = Request.QueryString["identificacion"].ToString();
                PEGE_TIPO = Request.QueryString["tipo"].ToString();
            }
        }

        public void ConsultarRutaFoto(string identificacion, string tipo)
        {
            if (tipo == "FUNCIONARIO")
            {
                string TITLEPEGE_FOTO = _controllers.consultarRutaFotoFuncionario(identificacion);
                if (TITLEPEGE_FOTO != null)
                {

                }

            }
            else
            {
                string TITLEPEGE_FOTO = _controllers.consultarRutaFotoVisitante(identificacion);

            }

        }

        [DirectMethod(ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool guardarFotoPerfilUsuario(string Base64Foto)
        {

            if (PEGE_TIPO == "VISITANTE")
            {

                return _controllers.guardarFotoVisitante(PEGE_ID, Base64Foto);
                
            }
            else
            {

                return _controllers.ActualizarFotoFuncionario(PEGE_ID, TITLEPEGE_FOTO);

            }
        }
    }
}