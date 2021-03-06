﻿using Ext.Net;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            
            HIDPERIODO.Text = "-1";
            this.consultarHorarioPeriodo();
            this.consultarPeriodo();
            //NodeRaiz(HIDPERIODO.Text);
        }
        
        private void consultarPeriodo()
        {
            SPERIODO.DataSource = Controllers.consultarPeriodo();
            SPERIODO.DataBind();
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
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public void NodeRaiz(string idperiodo)
        {
            HIDPERIODO.Text = idperiodo;
            List<DiaSemana> Semana = new List<DiaSemana>();
            DataTable DSemana = Controllers.consultarSemana();
            foreach (DataRow dia in DSemana.Rows)
            { 
                DiaSemana _dia = new DiaSemana();
                _dia.IDPERIODO = HIDPERIODO.Text;
                _dia.IDSEMANA = dia["ID"].ToString();
                _dia.NOMBRE = dia["DIA"].ToString();
                DataTable _DHDIA = Controllers.consultarHorarioporDia(HIDPERIODO.Text, _dia.IDSEMANA);
                _dia.HORARIO = new List<HorarioPorDia>();
                foreach (DataRow _franjahora in _DHDIA.Rows)
                {
                    HorarioPorDia hora = new HorarioPorDia();
                    hora.ID = _franjahora["ID"].ToString();
                    hora.IDHORA = _franjahora["IDHORA"].ToString();
                    hora.HORARIO = _franjahora["HORARIO"].ToString();
                    _dia.HORARIO.Add(hora);
                }
                Semana.Add(_dia);
            }
            Session["Semana"] = Semana;
            Ext.Net.Node root = new Ext.Net.Node()
            {
                Text = "SEMANA",
                NodeID="IDSEMANA" 
            };
            root.Expanded = true;
            TSEMANAHORARIO.Root.Add(root);

            foreach (DiaSemana dia in Semana)
            {
                Ext.Net.Node _componentedia = new Ext.Net.Node()
                {
                    Text = dia.NOMBRE,
                    Icon = Icon.CalendarSelectDay,
                    NodeID = "N" + dia.IDSEMANA

                };
                _componentedia.Expandable = true;
                root.Children.Add(_componentedia);
                foreach (HorarioPorDia franja in dia.HORARIO)
                {
                    Ext.Net.Node _franjaHora = new Ext.Net.Node()
                    {
                        NodeID = "HS" + franja.ID,
                        Text = franja.HORARIO,
                        Leaf = true
                    };
                    _componentedia.Children.Add(_franjaHora);
                }
            }
            TSEMANAHORARIO.ExpandAll();
            TSEMANAHORARIO.Render();
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Creando..", Target = MaskTarget.Page)]
        public bool crearPeriodo(string descripcion) {
            if (Controllers.registrarPeriodo("0", descripcion) == true) {
                HIDPERIODO.Text = Controllers.ConsultarPeriodoDisponible();
                return true;
            }
            return false ;
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public void registrarPeriodo(string idDiasemana, string idHorario, string horario)
        {
            List<DiaSemana> Semana = (List<DiaSemana>)Session["Semana"];
            int exist = 0;
            foreach (DiaSemana dia in Semana.Where(row => row.IDSEMANA == idDiasemana).ToList())
            {
                exist = dia.HORARIO.Where(item => item.IDHORA == idHorario).Count();
                if (exist == 0)
                {
                    HorarioPorDia h = new HorarioPorDia();
                    h.IDHORA = idHorario;
                    h.HORARIO = horario;
                    dia.HORARIO.Add(h);
                    if (Controllers.registrarHorarioPeriodo(HIDPERIODO.Text.Trim(), idDiasemana, idHorario) == true)
                    {
                        Node node = new Node()
                        {
                            NodeID ="HS" + Convert.ToString(Controllers.consultarIDsemanaHorario()),
                            Text = horario,
                            Leaf = true
                        };
                        var record = this.TSEMANAHORARIO.GetNodeById("N" + idDiasemana);
                        record.AppendChild(node);
                        X.Msg.Notify("Notificación", "registrado Exitosamente").Show();
                    }
                }
                else
                {
                    X.Msg.Notify("Notificación", "Este Horario ya esta asignado para este día").Show();
                }
            }
            Session.Remove("semana");
            Session["semana"] = Semana;
        }
         [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Eliminando..", Target = MaskTarget.Page)]
        public bool eliminarHorarioSemana(string idDiasemana, string idsemanahorario)
        { 
             string idEliminado= "-1";
             List<DiaSemana> Semana =  (List < DiaSemana >) Session["Semana"];  
             foreach (DiaSemana dia in Semana.Where(row => row.IDSEMANA == idDiasemana).ToList())
             {
                 foreach (HorarioPorDia item in dia.HORARIO.Where(item => item.ID == idsemanahorario).ToList())
                 {
		            idEliminado = item.ID;
                    dia.HORARIO.Remove(item);
	            }
            }
            Session.Remove("semana");
            Session["semana"] = Semana;
            return Controllers.eliminarHorarioSemana(idEliminado);
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


    }
    #region ENTIDAD
    public class HorarioPorDia
    {
        public string ID { get; set; }
        public string HORARIO { get; set; }
        public string IDHORA { get; set; }
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