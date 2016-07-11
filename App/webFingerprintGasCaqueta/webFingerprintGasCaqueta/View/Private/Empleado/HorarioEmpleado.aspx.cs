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
        string PEGE_ID="-1";
        string PEGE_COD = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            consultarPeriodo();

            if (Request.QueryString["idempleado"] != null)
            {
                PEGE_ID = Request.QueryString["idempleado"].ToString();
                consultarHorarioEmpleado(PEGE_ID);
              
            }
        }

        [DirectMethod(Namespace = "parametro")]
        public void consultarPeriodo()
        {
            SHORARIO.DataSource = _Controllers.consultarPeriodo();
            SHORARIO.DataBind();
        }

        public void consultarHorarioEmpleado(string idempleado) {

            DataTable data = _Controllers.consultarHorarioEmpleado(PEGE_ID);

            if (data.Rows.Count > 0) {
               
                string idhorariosemana = data.Rows[0]["IDHORARIOSEMANA"].ToString();
                string festivo = data.Rows[0]["FESTIVO"].ToString();
                string tespera = data.Rows[0]["TIEMPOTARDE"].ToString();
                string tipo = data.Rows[0]["TIPO"].ToString();
                string finicio = data.Rows[0]["FINICIO"].ToString();
                string ffin = data.Rows[0]["FFIN"].ToString();
                string horalab = data.Rows[0]["FFIN"].ToString();
                string desc_per = data.Rows[0]["PERIODO"].ToString();
                PEGE_COD = data.Rows[0]["CODIGO"].ToString();
                consultarHorariosPorPeriodo(idhorariosemana);

                BMODIFICAR.Show();
                BGUARDAR.Hidden = true;

                if (tipo == "FIJO")
                {
                    NRETRASO.Text = tespera;
                    CFESTIVO.Checked = festivo == "-1" ? false: true;
                }
                else {
                    X.AddScript("App.BTIPOHORARIO.setActiveItem('MPERIODO');");
                    PSEMANA.Title = "HORARIO ACTUAL: " + desc_per;
                    CFECHAS.Show();
                    DFECHAINI.Text = finicio;
                    DFECHAFIN.Text = ffin;
                }
                X.AddScript("App.FOPCION.expand();");
                
            }
        }
        [DirectMethod(Namespace = "parametro", ShowMask =true)]
        public void consultarHorariosPorPeriodo(string periodo)
        {
            DataTable tablaHorario = _Controllers.consultarHorariosPorPeriodo(periodo);
            SLABORAL.DataSource = tablaHorario;
            SLABORAL.DataBind();
        }
       [DirectMethod(Namespace = "parametro")]
        public void RegistrarHorarioEmpleado(string periodo,string tipohorario,string festivo,string retardo)
        {
            var r = DFECHAINI.Text;
            //string fecha = Convert.ToDateTime().ToString("yyyy-MM-dd");
            string _festivo = (festivo=="true") ? "1" : "-1";
            string estado = "1";
            bool result;
            string _tipohorario = (tipohorario == "MPERIODO") ? "PERIODO" : "FIJO";
            if (_tipohorario == "PERIODO")
            {
                string d = DFECHAINI.Value.ToString();
                string fechainicio = Convert.ToDateTime(DFECHAINI.Text).ToString("yyyy-MM-dd");
                string fechafin = Convert.ToDateTime(DFECHAFIN.Text).ToString("yyyy-MM-dd");
                result = _Controllers.registrarHorarioPeriodoEmpleado(estado, PEGE_ID, periodo, _festivo, retardo, _tipohorario, fechafin, fechafin);
              
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
       
    }

}


