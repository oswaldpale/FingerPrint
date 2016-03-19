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
        private FestivosOAD festivo = new FestivosOAD();
        private CirculacionOAD circulacion = new CirculacionOAD();
        private HorarioOAD horario = new HorarioOAD();
        private SemanaOAD semana = new SemanaOAD();
        private PeriodoOAD _periodo = new PeriodoOAD();
        private HorarioSemanaOAD horariosemana = new HorarioSemanaOAD();


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
        public DataTable consultarInformacionUsuario(string identificacion)
        {
            return circulacion.consultarInformacionUsuario(identificacion);
        }
        public DataTable ListarUsuarios() {
            return circulacion.ListarUsuarios();
        }
        public DataTable consultarTipoIngreso(string identificacion)
        {
            return circulacion.consultarTipoIngreso(identificacion);
        }
        public bool registrarEntrada(string identificacion)
        {
            return circulacion.registrarEntrada(general.nextPrimaryKey("circulacion", "circu_id"), identificacion);
        }

        public bool registrarSalida(string idTupla, string identificacion)
        {
            return circulacion.registrarSalida(idTupla, identificacion);
        }
        #endregion
        #region GESTIONAR HORARIO EMPLEADO
        public  bool consultarHorarioEmpleadoDia(string idempleado,string fechaserver, int diaserver){
            return false;
        }
        #endregion
        #region GESTIONAR EMPLEADOS
        public DataTable consultarEmpleados() {
            return empleado.consultarEmpleados();
        }
        public DataTable consultarEmpleadosHorarios() {
            return empleado.consultarEmpleadosHorarios();
        }
        #endregion
        #region GESTIONAR PERIODO HORARIO
        public DataTable consultarHorariosPorPeriodo(string periodo) {
            return _periodo.consultarHorariosPorPeriodo(periodo);
        }
        public string ConsultarPeriodoDisponible()
        {
            return  general.nextPrimaryKey("periodo","peri_id");
        }
        public DataTable ConsultarEstadoPeriodo(string idperiodo) {
            return _periodo.ConsultarEstadoPeriodo(idperiodo);
        }
        public DataTable consultarPeriodo() {
            return _periodo.consultarPeriodo();
        }
        #endregion
        #region GESTIONAR HORARIO SEMANA
        public DataTable consultarHorarioporDia(string idperiodo, string diasemana)
        {
            return horariosemana.consultarHorarioporDia(idperiodo, diasemana);
        }
        public bool eliminarHorarioSemana(string id) {
            return horariosemana.eliminarHorarioSemana(id);     
        }
        public int consultarIDsemanaHorario() {
            return Convert.ToInt32(general.nextPrimaryKey("horariosemanal","hose_id").ToString()) - 1;
        }

        public bool registrarHorarioPeriodo(string idperiodo, string idsemana, string idhorario)
        {
            if (this.ConsultarEstadoPeriodo(idperiodo).Rows.Count == 0)
            {
                _periodo.registrarPeriodo(idperiodo, "0", "");
            }
            return _periodo.registrarHorarioPeriodo(idperiodo, idsemana, idhorario, general.nextPrimaryKey("horariosemanal", "hose_id"));

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
        #region GESTIONAR FESTIVOS
        public DataTable consultarFestivos() {
            return festivo.consultarFestivos();
        }
        public bool registrarFestivo(string fecha,string nombreFestivo) {
            return festivo.registrarFestivo(general.nextPrimaryKey("diasfestivos", "dife_Id"), fecha, nombreFestivo);
        }
        public bool eliminarFestivo(string identificacion) {
            return festivo.eliminarFestivo(identificacion);
        }
        public bool consultarFechaExistente(string fecha) {
            return festivo.consultarFechaExistente(fecha);
        }
        #endregion
        #region GESTIONAR HORARIO
        public bool registrarHorario(string nombre, string horaInicio, string horarFin, string tiempoTarde) {
            return horario.registrarHorario(general.nextPrimaryKey("horario", "hora_id"),nombre,horaInicio,horarFin,tiempoTarde);
        }
        public DataTable consultarHorarios() {
            return horario.consultarHorarios();
        }
        public bool eliminarHorario(string id) {
            return horario.eliminarHorario(id);
        }
        public bool modificarHorario(string id,string nombre, string horaInicio, string horaFin, string tiempoTarde) {
            return horario.modificarHorario(id,nombre,horaInicio,horaFin,tiempoTarde);
        }
        public DataTable ConsultarHorariosPeriodos() {
            return horario.ConsultarHorariosPeriodos();
        }
        #endregion
        #region GESTIONAR SEMANA
        public DataTable consultarSemana()
        {
            return semana.consultarSemana();
        }
        #endregion


        
    }
}