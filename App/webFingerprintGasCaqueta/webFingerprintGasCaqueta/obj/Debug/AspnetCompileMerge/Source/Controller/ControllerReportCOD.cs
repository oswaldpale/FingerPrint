using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model;
using webFingerprintGasCaqueta.Report.ClassReport;

namespace webFingerprintGasCaqueta.Controller
{
    public class ControllerReportCOD
    {
        ReporteOAD reporte = new ReporteOAD();
        ReportePDF pdf;
        #region GESTIONAR REPORTES ASISTENCIA EMPLLEADOS
        public DataTable ListarreporteControlAsitenciasEmpleados(string fechaInicio, string fechaFin) {
            return reporte.reporteControlAsitenciasEmpleados(fechaInicio,fechaFin);
        }
        public void ReporteAsistenciaEmpleado(string fechaIncio,string fechaFin,DataTable _DataAsistencia) {
            try
            {

                pdf= new ReportePDF("rptListadoControlAccesoEmpleado");

                List<string> htm = pdf.Template;
                string cad = "";
                //** Encabezado
                htm[1] = string.Format(htm[1], Global.Empresa, Global.Nit, fechaIncio, fechaFin, DateTime.Now.ToString("yyyy-MM-dd"));
                cad = pdf.Inicio;
                //**
                //** Cuerpo del Pdf
                var filterIdent = from d in _DataAsistencia.AsEnumerable() group d by d.Field<String>("IDENTIFICACION")
                                   into grp
                                  select new
                                  {
                                      IDENTIFICACION = grp.Key,
                                   }; 
                foreach (var item in filterIdent)
                {
                    var rowsEmployeer  = _DataAsistencia.Select("IDENTIFICACION ='" + item.IDENTIFICACION + "'");
                    

                    cad += string.Format(htm[2], item.IDENTIFICACION, rowsEmployeer[0][2].ToString());
                    cad += htm[3];
                    foreach ( var rowInfo in rowsEmployeer)
                    {
                        cad += string.Format(htm[4], rowInfo[3].ToString(), rowInfo[4].ToString(),
                                                     rowInfo[5].ToString(), rowInfo[6].ToString());
                    }
                    string totalhoras = totalHorasTrabajadas(rowsEmployeer);
                    cad += string.Format(htm[5], totalhoras);
                }
                cad += string.Format(htm[6]);
                cad += string.Format(htm[7]);
                cad += string.Format(htm[8]);
                cad += pdf.Fin;
                pdf.createPDF(cad, htm[1], "Informe_Asistencias_", pdf.getPageConfig("LETTER", false));
            }
            catch (Exception exc)
            {
                X.MessageBox.Show(new MessageBoxConfig
                {
                    Title = "Notificación",
                    Message = "Error: " + exc.Message + exc.StackTrace,
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR,
                    Closable = false
                });
            }
        }
        public void ReporteAsistenciaEmpleadoIndividual(string fechaIncio, string fechaFin, DataTable _DataAsistencia,string identificacion)
        {
            try
            {

                pdf = new ReportePDF("rptListadoControlAccesoEmpleado");

                List<string> htm = pdf.Template;
                string cad = "";
                //** Encabezado
                htm[1] = string.Format(htm[1], Global.Empresa, Global.Nit, fechaIncio, fechaFin, DateTime.Now.ToString("yyyy-MM-dd"));
                cad = pdf.Inicio;
                //**
                //** Cuerpo del Pdf
                    var rowsEmployeer = _DataAsistencia.Select("IDENTIFICACION ='" + identificacion + "'");

                    cad += string.Format(htm[2], identificacion, rowsEmployeer[0][2].ToString());
                    cad += htm[3];
                    foreach (var rowInfo in rowsEmployeer)
                    {
                        cad += string.Format(htm[4], rowInfo[3].ToString(), rowInfo[4].ToString(),
                                                     rowInfo[5].ToString(), rowInfo[6].ToString());
                    }
                    string totalhoras = totalHorasTrabajadas(rowsEmployeer);
                    cad += string.Format(htm[5], totalhoras);
          
                cad += string.Format(htm[6]);
                cad += string.Format(htm[7]);
                cad += string.Format(htm[8]);
                cad += pdf.Fin;
                pdf.createPDF(cad, htm[1], "Informe_AsistenciasPorEmpleado_", pdf.getPageConfig("LETTER", false));
            }
            catch (Exception exc)
            {
                X.MessageBox.Show(new MessageBoxConfig
                {
                    Title = "Notificación",
                    Message = "Error: " + exc.Message + exc.StackTrace,
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR,
                    Closable = false
                });
            }
        }
        #endregion
        #region CONTADOR HORAS 
        private string totalHorasTrabajadas(DataRow[] data)
        {
            string total = "";
            var hours=0;var minutes=0; var seconds=0;
            for (int i = 0; i < data.Length; i++)
            {
                DataRow record;
                record = data[i];
                string[] h = record["DURACION"].ToString().Split(':');
                seconds = Convert.ToInt32(h[2]) + seconds;
                if (seconds >= 60)
                {
                    seconds = seconds - 60;
                    minutes = minutes + 1;
                }
                minutes = minutes + Convert.ToInt32(h[1].ToString());
                if (minutes >= 60)
                {
                    minutes = minutes - 60;
                    hours = hours + 1;
                }
                hours = hours + Convert.ToInt32(h[0].ToString());
            }
           
            total = hours + " HORAS " + minutes + " MINUTOS " + seconds + " SEGUNDOS";
            return total;
        }
        #endregion
    }
}