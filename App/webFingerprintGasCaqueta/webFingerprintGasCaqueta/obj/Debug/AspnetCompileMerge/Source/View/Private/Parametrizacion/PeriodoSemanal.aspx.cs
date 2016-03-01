using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
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
        string _periodo="1";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.consultarHorarioPeriodo();
            this.consultarSemana();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public void consultarHorarioPeriodo()
        {
            SHORARIO.DataSource = Controllers.ConsultarHorariosPeriodos();
            SHORARIO.DataBind();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public void consultarSemana()
        {
            SSEMANA.DataSource = Controllers.consultarSemana();
            SSEMANA.DataBind();
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
        [DirectMethod(Namespace = "parametro")]
        public void consultarPeriodoHorario(string idsemana) {
            //S Controllers.ConsultarPeriodo(_periodo, idsemana);
        }

        [DirectMethod]
        public string gridPanelHorario(Dictionary<string, string> parameters)
        {
            // string id = parameters["id"];
            string diasemana = parameters["IDSEMANA"];
            GridPanel grid = new GridPanel
            {
                Height = 200,
                EnableColumnHide = false,
                Store =
            {
                new Store
                {
                    Model = {
                        new Ext.Net.Model {
                            IDProperty = "ID",
                            Fields =
                            {
                                new ModelField("ID"),
                                new ModelField("HORARIO"),
                                new ModelField("DURACION")
                            }
                        }
                    },
                    DataSource = Controllers.ConsultarPeriodo(_periodo,diasemana)
                 }
            },
                ColumnModel =
            {
                Columns =
                {
                    new Column { Text = "HORARIO", DataIndex = "HORARIO", Width = 150 },
                    new Column { Text = "HORAS DE TRABAJO", DataIndex = "DURACION", Width = 200 }
                }
            }
            };

            return ComponentLoader.ToConfig(grid);
        }
       

    }
}