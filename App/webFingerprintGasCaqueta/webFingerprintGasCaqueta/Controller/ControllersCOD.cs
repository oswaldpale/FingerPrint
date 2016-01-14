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
        private VisitanteOAD visitante = new VisitanteOAD();


        #region GESTION DE HUELLA
        public DataTable consultarHuellaPorUsuario(string filtroUsuario)
        {
            return huella.consultarHuellaPorUsuario(filtroUsuario);
        }
        /// <summary>
        /// Eliminar la huella de un visitante
        /// </summary>
        /// <param name="identificacion"></param>
        /// <param name="dedo"></param>
        /// <returns></returns>
        public bool eliminarHuellaVisitante(string identificacion,string dedo)
        {
            return huella.eliminarHuellaVisitante(identificacion,dedo);
        }
        public bool consultarEstadoHuella(string identificacion, string dedo) {
            return huella.consultarEstadoHuella(identificacion, dedo);
        }
        public bool registrarHuella(string Dactilar, string empleado,string dedo) {
            return huella.registrarHuella(general.nextPrimaryKey("huella", "huell_id"), Dactilar, empleado,dedo);
        }
        /// <summary>
        /// Elimina la huella de un empleado
        /// </summary>
        /// <param name="identificacion"></param>
        /// <param name="dedo"></param>
        /// <returns></returns>
        public bool eliminarHuellaEmpleado(string identificacion, string dedo)
        {
            return huella.eliminarHuellaEmpleado(identificacion, dedo);
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
        #region GESTIONAR VISITANTE
        public bool registrarVisitante(string identificacion, string nombre, string apellido1, string apellido2, string observacion, string foto) {
            return visitante.registrarVisitante(identificacion,nombre,apellido1,apellido2,observacion,foto);
        }
        public DataTable consultarVisitantes() {
            return visitante.consultarVisitantes();
        }
        public bool consultarSiExisteVisitante(string identficacion) {
            return visitante.consultarSiExisteVisitante(identficacion);
        }

       
        #endregion
    }
}