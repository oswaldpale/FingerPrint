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
        private General general = new General();


        #region GESTION DE HUELLA
        public DataTable consultarHuella(string filtroUsuario)
        {
            return huella.consultarHuella(filtroUsuario);
        }
        
        public bool eliminarHuella(string identificacion)
        {
            return huella.eliminarHuella(identificacion);
        }
        public bool registrarHuella(string Dactilar, string empleado,string dedo) {
            return huella.registrarHuella(general.nextPrimaryKey("huella", "huell_id"), Dactilar, empleado,dedo);
        }
        #endregion
    }
}