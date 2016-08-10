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
        private HorarioEmpleado horarioempleado = new HorarioEmpleado();
        private PermisoOAD permiso = new  PermisoOAD();
        private AreaTrabajoOAD area = new AreaTrabajoOAD();

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
        public bool registrarHorarioPeriodoEmpleado(string estado, string idempleado, string periodo, string festivo, string tiemporetardo, string tipohorario, string fechainicio, string fechafin)
        {
            return horarioempleado.registrarHorarioPeriodoEmpleado(general.nextPrimaryKey("horarioempleado", "hoem_id"),estado, idempleado, periodo, festivo, tiemporetardo, tipohorario, fechainicio, fechafin);
        }

    

        public bool registrarHorarioFijoEmpleado(string estado, string idempleado, string periodo, string festivo, string tiemporetardo, string tipohorario)
        {
            return horarioempleado.registrarHorarioFijoEmpleado(general.nextPrimaryKey("horarioempleado", "hoem_id"), estado, idempleado, periodo, festivo, tiemporetardo, tipohorario);
        }

        public bool modificarHorarioPeriodoEmpleado(string primaryKey,string estado, string idempleado, string periodo, string festivo, string tiemporetardo, string tipohorario, string fechainicio, string fechafin)
        {
            return horarioempleado.modificarHorarioPeriodoEmpleado(primaryKey, estado, idempleado, periodo, festivo, tiemporetardo, tipohorario, fechainicio, fechafin);
        }

        

        public bool modificarHorarioFijoEmpleado(string primaryKey,string estado, string idempleado, string periodo, string festivo, string tiemporetardo, string tipohorario)
        {
            return horarioempleado.modificarHorarioFijoEmpleado(primaryKey, estado, idempleado, periodo, festivo, tiemporetardo, tipohorario);
        }
        public DataTable consultarHorarioEmpleado(string idempleado) {
            return horarioempleado.consultarHorariEmpleado(idempleado);
        }

        public bool inacticarHorarioEmpleado(string codigoEmpleado)
        {
            return horarioempleado.inacticarHorarioEmpleado(codigoEmpleado);
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
        public string recuperarIDperiodo()
        {
            return _periodo.recuperarIDperiodo();
        }
        public DataTable ConsultarEstadoPeriodo(string idperiodo) {
            return _periodo.ConsultarEstadoPeriodo(idperiodo);
        }
        public DataTable consultarPeriodo() {
            return _periodo.consultarPeriodo();
        }

        public bool registrarPeriodo(string totalHoras,string descripcion) {
            return _periodo.registrarPeriodo(general.nextPrimaryKey("periodo", "peri_id").ToString(), totalHoras, descripcion);
        }

        public bool actualizartotalperiodo(string idperiodo) {
            return _periodo.actualizartotalperiodo(idperiodo);
        }

        public bool modificarPeriodo(string idperiodo,string descripcion)
        {
            return _periodo.modificarPeriodo(idperiodo,descripcion);
        }
        public bool eliminarPeriodo(string idperiodo) {
            return _periodo.eliminarPeriodo(idperiodo);
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
        #region GESTIONAR PERMISOS
        public bool registrarPermisoHora(string idempleado ,string tipotiempo,string tipopermiso,string fechasolicitud,string estado,string fechapermiso,string horainicio,string horafin,string observacion) {
            return permiso.registrarPermisoHora(general.nextPrimaryKey("permisos", "perm_id").ToString(), idempleado,tipotiempo, tipopermiso, fechasolicitud, estado, fechapermiso, horainicio, horafin,observacion);
        }
        public bool registrarPermisoDia(string idempleado, string tipotiempo, string tipopermiso, string fechasolicitud, string estado, string fechainicio, string fechafin,string observacion)
        {
            return permiso.registrarPermisoDia(general.nextPrimaryKey("permisos", "perm_id").ToString(), idempleado, tipotiempo, tipopermiso, fechasolicitud, estado, fechainicio, fechafin,observacion);
        }

        public DataTable consultarTipoPermiso()
        {
            return permiso.consultarTipoPermiso();
        }

        public DataTable consultarPermisosActivo()
        {
            return permiso.consultarPermisosActivos();
        }
        public bool eliminarPermiso(string codigo)
        {
            return permiso.eliminarPermiso(codigo);
        }
        #endregion
        #region GESTIONAR AREA
        public DataTable consultarArea()
        {
            return area.consultarArea();
        }
        public bool registrarArea(string codigo, string dependencia,string ext)
        {
            return area.registrarArea(codigo,dependencia,ext);
        }
        public bool eliminarArea(string codigo)
        {
            return area.eliminarArea(codigo);
        }

        public bool modificarArea(string codigo, string dependencia, string ext)
        {
            return area.modificarArea(codigo, dependencia, ext);
        }

        #endregion

    }
}