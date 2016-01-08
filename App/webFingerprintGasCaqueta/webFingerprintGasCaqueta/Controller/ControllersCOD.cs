using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webFingerprintGasCaqueta.Model;

namespace webFingerprintGasCaqueta.Controller
{
    public class ControllersCOD
    {
        private HuellaOAD huella = new HuellaOAD();
        private EmpleadoOAD empleado = new EmpleadoOAD();
        private General general = new General();


        #region GESTION DE HUELLA
        public DataTable consultarHuellaPorUsuario(string filtroUsuario)
        {
            return huella.consultarHuellaPorUsuario(filtroUsuario);
        }
        
        public bool eliminarHuella(string identificacion)
        {
            return huella.eliminarHuella(identificacion);
        }
        public bool registrarHuella(string Dactilar, string empleado,string dedo) {
            return huella.registrarHuella(general.nextPrimaryKey("huella", "huell_id"), Dactilar, empleado,dedo);
        }
        #endregion
        #region GESTIONAR CIRCULACIÓN

        #endregion

        #region GESTIONAR EMPLEADOS
        public DataTable consultarEmpleados() {
            return empleado.consultarEmpleados();
        }
        public DataTable consultarInformacionUsuario(string identificacion) {
            return empleado.consultarInformacionUsuario(identificacion);
        }
        #endregion
    }
}