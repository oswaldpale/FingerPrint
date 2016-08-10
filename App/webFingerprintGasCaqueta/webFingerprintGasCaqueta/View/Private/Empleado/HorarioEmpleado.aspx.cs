using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Private.Empleado
{
    public partial class Horario : System.Web.UI.Page
    {
        private ControllersCOD _Controllers = new ControllersCOD();
        public static string PEGE_ID = "-1";
        public static string PEGE_COD = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            consultarPeriodo();

            if (!X.IsAjaxRequest) {
                if (Request.QueryString["idempleado"] != null)
                {
                    PEGE_ID = Request.QueryString["idempleado"].ToString();
                    consultarHorarioEmpleado(PEGE_ID);

                }
            }
          
        }

        [DirectMethod(Namespace = "parametro")]
        public void consultarPeriodo()
        {
            SHORARIO.DataSource = _Controllers.consultarPeriodo();
            SHORARIO.DataBind();
        }

        public void consultarHorarioEmpleado(string idempleado)
        {

            DataTable data = _Controllers.consultarHorarioEmpleado(PEGE_ID);


            if (data.Rows.Count > 0)
            {

                string idhorariosemana = data.Rows[0]["IDHORARIOSEMANA"].ToString();
                string festivo = data.Rows[0]["FESTIVO"].ToString();
                string tespera = data.Rows[0]["TIEMPOTARDE"].ToString();
                string tipo = data.Rows[0]["TIPO"].ToString();
                string finicio = data.Rows[0]["FINICIO"].ToString();
                string ffin = data.Rows[0]["FFIN"].ToString();
                string horalab = data.Rows[0]["FFIN"].ToString();
                string desc_per = data.Rows[0]["PERIODO"].ToString();
                HPERIODO.Text = data.Rows[0]["IDHORARIOSEMANA"].ToString();
                PEGE_COD = data.Rows[0]["CODIGO"].ToString();
                consultarHorariosPorPeriodo(idhorariosemana);

                BMODIFICAR.Show();
                BGUARDAR.Hidden = true;

                if (tipo != "FIJO")
                {

                    X.AddScript("App.BTIPOHORARIO.setActiveItem('MPERIODO');");

                    CFECHAS.Show();
                    DFECHAINI.Text = finicio;
                    DFECHAFIN.Text = ffin;
                }
                NRETRASO.Text = tespera;
                CFESTIVO.Checked = festivo == "-1" ? false : true;
                PSEMANA.Title = "HORARIO ACTUAL: " + desc_per;
                X.AddScript("App.PHORARIO.collapse();");
                X.AddScript("App.FOPCION.expand();");

            }
        }
        [DirectMethod(Namespace = "parametro")]
        public void consultarHorariosPorPeriodo(string periodo)
        {
            string idperiodo = periodo;
            DataTable tablaHorario = _Controllers.consultarHorariosPorPeriodo(idperiodo);
            GHORARIO.GetStore().DataSource = tablaHorario;
            GHORARIO.GetStore().DataBind();
        }
        [DirectMethod(Namespace = "parametro")]
        public void RegistrarHorarioEmpleado(string periodo, string tipohorario, string festivo, string retardo, string fini, string ffin)
        {

            string _festivo = (festivo == "true") ? "1" : "-1";
            string estado = "1";
            bool result;
            string _tipohorario = (tipohorario == "MPERIODO") ? "PERIODO" : "FIJO";

            if (_tipohorario == "PERIODO")
            {
                string fechainicio = Convert.ToDateTime(fini).ToString("yyyy-MM-dd");
                string fechafin = Convert.ToDateTime(ffin).ToString("yyyy-MM-dd");

                result = _Controllers.registrarHorarioPeriodoEmpleado(estado, PEGE_ID, periodo, _festivo, retardo, _tipohorario, fechainicio, fechafin);
            }
            else
            {
                result = _Controllers.registrarHorarioFijoEmpleado(estado, PEGE_ID, periodo, _festivo, retardo, _tipohorario);
            }
            if (result == true)
            {
                X.Msg.Notify("Notificación", "Registrado Exitosamente!.").Show();
            }
            else
            {
                X.Msg.Notify("Notificación", "Ha ocurrido un error!..").Show();
            }

        }
        [DirectMethod(Namespace = "parametro")]
        public void ModificarHorarioEmpleado(string periodo, string tipohorario, string festivo, string retardo, string fini, string ffin)
        {

            string _festivo = (festivo == "true") ? "1" : "-1";
            string estado = "1";
            bool result;

            string _tipohorario = (tipohorario == "MPERIODO") ? "PERIODO" : "FIJO";

            if (_tipohorario == "PERIODO")
            {
                string fechainicio = Convert.ToDateTime(fini).ToString("yyyy-MM-dd"); ;
                string fechafin = Convert.ToDateTime(ffin).ToString("yyyy-MM-dd"); ;
                result = _Controllers.modificarHorarioPeriodoEmpleado(PEGE_COD, estado, PEGE_ID, periodo, _festivo, retardo, _tipohorario, fechainicio, fechafin);
            }
            else
            {
                result = _Controllers.modificarHorarioFijoEmpleado(PEGE_COD, estado, PEGE_ID, periodo, _festivo, retardo, _tipohorario);
            }
            if (result == true)
            {
                X.Msg.Notify("Notificación", "Actualizado Exitosamente!.").Show();
            }
            else
            {
                X.Msg.Notify("Notificación", "Ha ocurrido un error!..").Show();
            }

        }

    }

}


