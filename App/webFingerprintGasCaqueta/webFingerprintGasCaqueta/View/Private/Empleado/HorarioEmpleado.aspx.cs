using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Private.Empleado
{
    public partial class Horario : System.Web.UI.Page
    {
        private ControllersCOD _Controllers = new ControllersCOD();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.consultarEmpleadosHorarios();
            this.consultarPeriodo();
            this.consultarHorariosPorPeriodo("1");
        }

        public void consultarEmpleadosHorarios()
        {
            SEMPLEADOS.DataSource = _Controllers.consultarEmpleadosHorarios();
            SEMPLEADOS.DataBind();
        }
        public void consultarPeriodo()
        {
            SHORARIO.DataSource = _Controllers.consultarPeriodo();
            SHORARIO.DataBind();
        }
        [DirectMethod(Namespace = "parametro")]
        public void consultarHorariosPorPeriodo(string periodo)
        {
            String[,] semana = new String[7, 7];


            DataTable tablaHorario = _Controllers.consultarHorariosPorPeriodo(periodo);
            for (int i = 1; i < 7; i++)
            {
                DataRow[] result = tablaHorario.Select("DIAID = '" + i + "'");
                int j = 0;
                foreach (DataRow item in result)
                {

                    string dia = item["DIAID"].ToString();
                    switch (dia)
                    {
                        case "1":
                            semana[j, 1] = item["HORARIO"].ToString();
                            break;
                        case "2":
                            semana[j, 2] = item["HORARIO"].ToString();
                            break;
                        case "3":
                            semana[j, 3] = item["HORARIO"].ToString();
                            break;
                        case "4":
                            semana[j, 4] = item["HORARIO"].ToString();
                            break;
                        case "5":
                            semana[j, 5] = item["HORARIO"].ToString();
                            break;
                        case "6":
                            semana[j, 6] = item["HORARIO"].ToString();
                            break;
                        default:
                            semana[j, 7] = item["HORARIO"].ToString();
                            break;
                    }
                    j = j + 1;
                }
            }
        }

        [DirectMethod(Namespace = "parametro")]
        public void RegistrarHorarioEmpleado(string periodo,string tipohorario,string festivo,string retardo) {

            string fechainicio = Convert.ToDateTime(DFECHAINI.Text).ToString("yyyy-MM-dd"); 
            string fechafin = Convert.ToDateTime(DFECHAFIN.Text).ToString("yyyy-MM-dd"); 

            RowSelectionModel sm = this.GEMPLEADOS.GetSelectionModel() as RowSelectionModel;
            var codigoEmpleado = new List<string>();
            foreach (SelectedRow row in sm.SelectedRows)
            {
                codigoEmpleado.Add(row.RecordID);
            }
            string estado = "1";
            if ( _Controllers.registrarEmpleados(estado,codigoEmpleado,periodo,festivo,retardo,tipohorario,fechafin,fechafin))
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


