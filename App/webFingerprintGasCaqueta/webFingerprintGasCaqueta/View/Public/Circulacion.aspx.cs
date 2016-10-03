﻿using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFingerprintGasCaqueta.Controller;

namespace webFingerprintGasCaqueta.View.Public
{
    public partial class Circulacion : System.Web.UI.Page
    {
        private string PEGE_ID = "10012914";
        private ControllersCOD Controllers = new ControllersCOD();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarCombobox();
        }

        [DirectMethod(Namespace = "parametro")]
        public void RefreshTime()
        {
            string clock = DateTime.Now.ToString("hh:mm:ss tt");
            this.LMENSAJE.Text = clock.Replace(". m.", "m");
        }
       
        #region CONTROL DE LA ENTRADA Y SALIDA DE LOS FUNCIONARIOS
        [DirectMethod(Namespace = "parametro")]
        public bool consultarTipoIngreso(string identificacion)
        {
            bool RegUserDoor = false;                            //Estado de entrada o Salida.
            DataTable _DInAcceso = Controllers.consultarTipoIngreso(identificacion);
            Thread.Sleep(1200);
            if (_DInAcceso.Rows.Count > 0)
            {
                string InAcceso = _DInAcceso.Rows[0]["INGRESOESTADO"].ToString();
                TIDTUPLA.Text = _DInAcceso.Rows[0]["ID"].ToString();
                return (RegUserDoor = (InAcceso == "SALIDA") ? true : false);  //SI ES TRUE ES UNA SALIDA
            }
            else
            {
                return RegUserDoor;
            }
        }

        

        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool registrarEntrada(string identificacion)
        {
            string clockServer = DateTime.Now.ToString("hh:mm:ss tt");
            DateTime DateValue = DateTime.Now;
            int dSemanaServer = (int)DateValue.DayOfWeek;
            //if (Controllers.consultarHorarioEmpleadoDia(clockServer, identificacion, dSemanaServer) == true) //valida el horario asignado en bd del empleado con la hora que se toma del servidor. 
            //{
               
            //    return Controllers.registrarEntrada(identificacion);
            //}
           
            if (Controllers.registrarEntrada(identificacion)) {
                PFOTOS.Collapsed = true;
                LMENSAJE.Text = "ENTRADA:" + clockServer;
                return true;
            }
            return false;
        }
        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Guardando..", Target = MaskTarget.Page)]
        public bool registrarSalida(string idTupla, string identificacion)
        {
            string clockServer = DateTime.Now.ToString("hh:mm:ss tt");
            
            if(Controllers.registrarSalida(idTupla, identificacion)) {
                LMENSAJE.Text = "SALIDA:" + clockServer;
                return true;
            }
            return false;
        }
        #endregion

        [DirectMethod(Namespace = "parametro", ShowMask = true, Msg = "Consultando..", Target = MaskTarget.Page)]
        public bool buscarUsuario(string identificacion)
        {

            DataTable inforUsuario = Controllers.consultarInformacionUsuario(identificacion);
            bool tipoUsuario = false;
            if (inforUsuario.Rows.Count > 0)
            {
                DataRow _inforUsuario = inforUsuario.Rows[0];
                TUSUARIO.Text = _inforUsuario["NOMBRE"].ToString().ToUpper();
                TCARGO.SetValue(_inforUsuario["CARGO"].ToString().ToUpper());
                TTIPOOUSUARIO.Text = _inforUsuario["TIPO"].ToString().ToUpper();

                string ident = _inforUsuario["CODIGO"].ToString();
                string foto = Convert.ToString(_inforUsuario["FOTO"].ToString());
                string fileName="";
                switch (TTIPOOUSUARIO.Text)

                // nueva ruta de fotos ...... S:\Bdatos\Fotos
                {
                    case "VISITANTE":
                        if (foto != ""){
                            //fileName = Path.GetFullPath("D:\\SIGC\\Bdatos\\Fotos\\" + foto); MostrarImagen(fileName);
                        }
                        else
                            IMPERFIL.ImageUrl = "../../Content/images/user.png";
                        break;
                    case "EMPLEADO":
                        if (foto != "") { 
                            fileName = Path.GetFullPath("D:\\SIGC\\Bdatos\\Fotos\\" + foto); MostrarImagen(fileName); }

                        else
                            IMPERFIL.ImageUrl = "../../Content/images/user.png";
                        break;
                }
                
                TIDUSER.SetValue(ident);
                if (_inforUsuario["TIPO"].ToString() == "Empleado")
                {
                    tipoUsuario = true;
                }
                else {
                    tipoUsuario = true;
                    X.AddScript("App.WVISITANTE.show();");   //invoco el formulario  de lugar al que se dirige el visitante;
                }

            }
            return tipoUsuario;
        }

        public void MostrarImagen(string filename) {
            try
            {
                Bitmap Foto = new Bitmap(filename);
                IMPERFIL.ImageUrl = "data:image/jpg;base64," + BitMapToString(Foto) + "";
            }
            catch {
                IMPERFIL.ImageUrl = "../../Content/images/user.png";
            }
            
        }

        public string BitMapToString(Bitmap bitmap)
        {
            Bitmap bImage = bitmap;  //Your Bitmap Image
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            return Convert.ToBase64String(byteImage);


        }

        [DirectMethod(Namespace = "parametro")]
        public void ChangeReaderInf(string state)
        {
            LESTADO.Text = state;
            if (state == "Desconectado Lector")
            {
                LESTADO.Icon = Ext.Net.Icon.Disconnect;
                LESTADO.Cls = "ReaderStateDisconnect";
                return;
            }
            else
            {
                LESTADO.Icon = Ext.Net.Icon.Connect;
                LESTADO.Cls = "ReaderStateConnect";
            }

        }

        [DirectMethod(Namespace = "parametro")]
        public string validarHorario(string usuario,string tipoingreso) {

            string clockServer = DateTime.Now.ToString("hh:mm:ss tt");


            DateTime dateValue = DateTime.Now;
            int ndia =  (int)dateValue.DayOfWeek;

            DataTable dt = Controllers.consultarHorarioEmpleado(usuario);
          
            if (dt.Rows.Count > 0) {
                string codigoperiodo = dt.Rows[0]["CODIGO"].ToString();
                string tiempoTarde = dt.Rows[0]["TIEMPOTARDE"].ToString();
                string estadoFestivo = dt.Rows[0]["FESTIVO"].ToString();
                DataTable dtDiaEvaluar = Controllers.consultarHorarioDiaTrabajo(codigoperiodo, ndia);
                if (dtDiaEvaluar.Rows.Count > 0) {

                    DataTable dtCirculacionActual = Controllers.consultarUltimoIngreso(usuario);     //Compruebo el ultimo ingreso para asi tomar desicion del ingreso nuevo
                    
                    switch (tipoingreso) {
                        case  "ENTRADA":

                            DateTime fechaRegistro = (DateTime)dtCirculacionActual.Rows[0]["FECHA"];

                            if (dtCirculacionActual.Rows.Count > 0)
                            {
                                foreach (DataRow item in dtDiaEvaluar.Rows)
                                {

                                }
                               
                            }
                            break;
                        case "SALIDA" :

                            break;
                    }
                        
                }
                
            }
            return "";            
        }


        #region  INDICENCIA  SUBFORMULARIO INCIDENCIA



        #endregion

        #region DEPEDENCIA  SUBFOMULARIO VISITANTE

        [DirectMethod(ShowMask = true, Msg = "Cargando..", Target = MaskTarget.Page)]
        public void cargarCombobox()
        {
            SDEPENDENCIA.DataSource = Controllers.consultarArea();
            SDEPENDENCIA.DataBind();
        }

        #endregion

    }
   
}