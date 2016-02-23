using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model;

namespace webFingerprintGasCaqueta.Controller
{
    public class ControllerReportCOD
    {
        ReporteOAD reporte = new ReporteOAD();
        #region GESTIONAR REPORTES
        public DataTable ListarreporteControlAsitenciasEmpleados(string fechaInicio, string fechaFin) {
            return reporte.reporteControlAsitenciasEmpleados(fechaInicio,fechaFin);
        }
        #endregion
    }
}