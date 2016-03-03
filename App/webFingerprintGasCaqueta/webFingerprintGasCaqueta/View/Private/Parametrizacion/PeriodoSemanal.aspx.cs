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
        string _periodo = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            _periodo = Controllers.ConsultarPeriodoDisponible();
            this.consultarHorarioPeriodo();
            this.consultarSemana();
            NodeRaiz();
        }
        public void NodeRaiz()
        {
            string _periodo = "1";
            List<DiaSemana> Semana = new List<DiaSemana>();
            DataTable DSemana = Controllers.consultarSemana();
            foreach (DataRow dia in DSemana.Rows)
            {
                DiaSemana _dia = new DiaSemana();
                _dia.IDPERIODO = _periodo;
                _dia.IDSEMANA = dia["ID"].ToString();
                _dia.NOMBRE = dia["DIA"].ToString();
                DataTable _DHDIA = Controllers.consultarHorarioporDia(_periodo, _dia.IDSEMANA);
                _dia.HORARIO = new List<HorarioPorDia>(); 
                foreach (DataRow _franjahora in _DHDIA.Rows)
                {
                    HorarioPorDia hora = new HorarioPorDia();
                    hora.ID = _franjahora["ID"].ToString();
                    hora.HORARIO = _franjahora["HORARIO"].ToString();
                    _dia.HORARIO.Add(hora);
                }
                Semana.Add(_dia);
            }
            Ext.Net.Node root = new Ext.Net.Node()
            {
                Text = "SEMANA"
            };
            root.Expanded = true;
            TSEMANAHORARIO.Root.Add(root);

            foreach (var dia in Semana)
            {
                Ext.Net.Node _componentedia = new Ext.Net.Node()
                {
                    Text = dia.NOMBRE,
                    Icon = Icon.Folder
                };
                root.Children.Add(_componentedia);
                foreach (var franja in dia.HORARIO)
                {
                    Ext.Net.Node _franjaHora = new Ext.Net.Node()
                    {
                        Text = franja.HORARIO,
                        Icon = Icon.Time,
                        Leaf = true
                    };
                    _componentedia.Children.Add(_franjaHora);
                }
            }
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
            //SSEMANA.DataSource = Controllers.consultarSemana();
            //SSEMANA.DataBind();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool registrarPeriodo(string idDiasemana, string idHorario) {
            return Controllers.registrarHorarioPeriodo(_periodo, idDiasemana, idHorario);
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
            //SPERIODOHORARIO.DataSource =  Controllers.ConsultarPeriodo(_periodo, idsemana);
            //SPERIODOHORARIO.DataBind();
        }

    }
    #region ENTIDAD
    public class HorarioPorDia
    {
        public string ID { get; set; }
        public string HORARIO{ get; set; }
        public HorarioPorDia() { }
        public HorarioPorDia(string id, string horario)
        {
            this.ID = id;
            this.HORARIO = horario;
        }
    }
    public class DiaSemana
    {
        public string IDSEMANA { get; set; }
        public string IDPERIODO { get; set; }
        public string NOMBRE { get; set; }
        public List<HorarioPorDia> HORARIO { get; set; }
        public DiaSemana() { }
    }
    #endregion

}