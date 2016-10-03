<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Circulacion.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Public.Circulacion" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Control de Acceso</title>
    <link href="../../Content/css/degraded.css" rel="stylesheet" />
    <script src="../../Content/js/Concurrent.Thread.js"></script>
    <script src="../../Content/js/jquery.min.js"></script>

    <style type="text/css">
        /**/
        #unlicensed {
            display: none !important;
        }
    </style>

    <script type="text/javascript">

        var iubi = new WebSocket('ws://127.0.0.1:2015')
       
        iubi.onerror = function (error) {
            Ext.Msg.info({ ui: 'warning', title: 'UI', html: 'El servicio del Lector U Are U 4500 Digital Persona esta inactivo', iconCls: '#Error' });
        };

        function emit(evt, data) {
           
            var msg = {
                type: evt,
                payload: []
            };

            msg.payload.push(data)
            iubi.send(JSON.stringify(msg));

        }

        iubi.onmessage = function (evt) {

            var data;
            eval(evt.data);
            console.log(data)
          
            switch (data.type) {
                case 'validate':
                    var r = data.payload[0];
                    App.IMDACTILAR.setImageUrl('data:image/png;base64,' + r.data + '');
                    
                    if (r.state == 'complete') {

                        parametro.consultarTipoIngreso(App.TIDUSER.getValue(), {   /// pa la siguiente fase se puede hacer el cruze de los horarios.
                            success: function (result) {
                                if (result == false) {    // retorna false----> registra una entrada
                                     
                                    parametro.registrarEntrada(App.TIDUSER.getValue(), {
                                        success: function (result) {
                                            App.PFOTOS.collapse()
                                            setTimeout(function () { ClearData() }, 3000)
                                           
                                        }
                                    });

                                } else {           // registra una salida -->xq ya existe una entrada..

                                    parametro.registrarSalida(App.TIDTUPLA.getValue(), App.TIDUSER.getValue(), {
                                        success: function (result) {
                                            App.PFOTOS.collapse()
                                            setTimeout(function () { ClearData()}, 3000)
                                            Ext.net.Notification.show({
                                                html: 'Buen Descanso Adios!', title: 'Notificación'
                                            });
                                            
                                            
                                        }
                                    });
                                }
                            }
                        });
                      
                    }
                    else {
                       
                        Ext.net.Notification.show({
                            html: 'Acceso Denegado!', title: 'Notificación'
                        });
                        App.IMDACTILAR.setImageUrl('../../Content/images/SinHuella.png');
                       
                    }
                   
                    break;
                case 'checkin':
                    App.PFOTOS.expand();
                    var r = data.payload[0];
                    App.IMDACTILAR.setImageUrl('data:image/png;base64,' + r.data + '');
                    App.PFOTOS.collapse();
                    
                    break;

                case 'connect':
                    parametro.ChangeReaderInf('Conectado Lector');
                    break;

                case 'disconnect':
                    parametro.ChangeReaderInf('Desconectado Lector');
                    break;
              
            }

        }
        function sleep(delay) {
            var start = new Date().getTime();
            while (new Date().getTime() < start + delay);
        }

        function loadDevice() { //connect serverBD: local,products,test
            emit('connectserver', { type: String('local') });
            emit('checkin');
        }

        var findUser = function (texto, e) {
           
            if (e.getKey() == 13) {
                parametro.buscarUsuario(texto, {

                    success: function (result) {
                        if (result) {
                            
                            App.PFOTOS.expand();

                            emit('validate', { user: String(App.TIDUSER.getValue()) }); 

                            App.LMENSAJE.setText('Ingrese Su Huella');            // Mensaje de Ingrese la Huella...
                            App.IMDACTILAR.setImageUrl('../../Content/images/SinHuella.png');
                            
                            var typeEntry =  parametro.consultarTipoIngreso(App.TIDUSER.getValue()) ? 'ENTRADA' : 'SALIDA';
                            
                            
                            parametro.validarHorario(App.TIDUSER.getValue(),typeEntry, {

                            success: function (result) {
                                if (result == true) {
                                    Ext.net.Notification.show({
                                        html: 'Incidencia No generada', title: 'Notificación'
                                    });

                                } else {
                                    Ext.net.Notification.show({
                                        html: 'Incidencia Previa', title: 'Notificación'
                                    });

                                }
                            }
                        });

                    } else {

                            ClearData();

                            Ext.net.Notification.show({
                                html: 'Usuario no registrado', title: 'Notificación'
                            });
                     }
                }, failure: function (errorMsg) {
                    Ext.net.Notification.show({
                        html: 'Ha ocurrido un error!', title: 'Notificación'
                    });
                }
             });
           }
        };

        function ClearData() {
            App.PPRINCIPAL.reset();
            App.TIDUSER.reset();
            App.LMENSAJE.setText('');
            App.TIDTUPLA.reset();
            App.DDIDENTIFICACION.focus();
            App.IMDACTILAR.setImageUrl('../../Content/images/SinHuella.png');
          
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <ext:ResourceManager ID="ResourceManager2" Theme="NeptuneTouch" runat="server" AjaxTimeout="98000000" />
        <ext:Viewport runat="server">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:TextField runat="server" ID="TIDUSER" Hidden="true" />
                <ext:TextField runat="server" ID="TIDTUPLA" Hidden="true" />
                <ext:FormPanel ID="FPRINCIPAL" runat="server" Title="CONTROL DE ACCESO" Icon="User" Width="1000" Height="650" UI="Info" Draggable="false" Closable="false" Border="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="PPRINCIPAL" Border="false">
                            <Items>
                                <ext:Panel runat="server" ID="PNORTE" Region="North" Height="40" Border="false" BodyCls="TopBarDegraded">
                                    <Items>
                                        <ext:Image ID="ILOGO" runat="server" ImageUrl="" Width="16px" Height="16px" Floating="true" />
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" ID="PCONTENEDOR" Layout="BorderLayout" Height="520">
                                    <Items>
                                        <ext:Panel runat="server" ID="PDATOS" Width="600" Border="true" Region="Center">
                                            <Items>
                                                <ext:Panel ID="PDATOSPERSONA" runat="server" Height="260" Border="false" Icon="Zoom" Title="INFORMACIÓN" Collapsible="true">
                                                    <Items>
                                                        <ext:Container runat="server" Height="100" Layout="CenterLayout" Cls="UserInf">
                                                            <Items>
                                                                <ext:DropDownField ID="DDIDENTIFICACION" runat="server" Width="550" TriggerIcon="Search" EmptyText="Ingrese su número de identificación." FieldLabel="Identificación:" LabelWidth="150" UI="Default" BodyStyle="padding:2px 2px;" EnableKeyEvents="true" AutoFocus="true" MaskRe="[0-9]">
                                                                    <Listeners>
                                                                        <KeyPress Handler="findUser(App.DDIDENTIFICACION.getValue(), Ext.EventObject);" Buffer="200" />
                                                                    </Listeners>
                                                                    <Listeners>
                                                                        <IconClick Handler="" />
                                                                    </Listeners>
                                                                </ext:DropDownField>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Layout="CenterLayout" Cls="UserInf" Height="45">
                                                            <Items>
                                                                <ext:TextField ID="TTIPOOUSUARIO" runat="server" Width="550" FieldLabel="TIPO" LabelWidth="150" ReadOnly="true" />
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Layout="CenterLayout" Cls="UserInf">
                                                            <Items>
                                                                <ext:TextField runat="server" ID="TUSUARIO" Width="550" ReadOnly="true" FieldLabel="USUARIO" LabelWidth="150" />
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Layout="CenterLayout" Cls="UserInf" Height="40">
                                                            <Items>
                                                                <ext:TextField runat="server" ID="TCARGO" Width="550" ReadOnly="true" FieldLabel="CARGO" LabelWidth="150" />
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Panel>
                                                <ext:Panel ID="PALERTAS" runat="server" Height="238" Border="false">
                                                    <Items>
                                                        <ext:Container runat="server" Layout="CenterLayout">
                                                            <Items>
                                                                <ext:Panel ID="PMENSAJE" runat="server" Width="620" Title="MENSAJE" Border="true" Height="220" Layout="CenterLayout" Collapsible="true">
                                                                    <Items>
                                                                        <ext:Label runat="server" ID="LMENSAJE" Cls="Font-Clock" Width="610" />
                                                                    </Items>
                                                                </ext:Panel>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Panel>
                                            </Items>
                                        </ext:Panel>

                                        <ext:Panel runat="server" ID="PFOTOS" Width="275" Height="480" Layout="VBoxLayout" Title="INFOGRAFIA" Icon="Information" AnimCollapseDuration="500" AnimCollapse="true" Region="East" Collapsible="true" Collapsed="true">
                                            <Items>
                                                <ext:Panel runat="server" Height="230" Width="284" Border="false" Layout="CenterLayout">
                                                    <Items>
                                                        <ext:Image ID="IMPERFIL" runat="server" ImageUrl="../../Content/images/user.png" Width="190px" Height="190px">
                                                        </ext:Image>
                                                    </Items>
                                                </ext:Panel>
                                                <ext:Panel runat="server" Height="240" Width="284" Frame="false" Layout="CenterLayout" Border="false">
                                                    <Items>
                                                        <ext:Image ID="IMDACTILAR" runat="server" ImageUrl="../../Content/images/SinHuella.png" Width="200px" Height="200px">
                                                        </ext:Image>
                                                    </Items>
                                                </ext:Panel>

                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" ID="PSUR" Height="50" Layout="TableLayout" Region="South" BodyCls="FootBarDegraded">
                                    <Items>
                                        <ext:Container runat="server" Width="550">
                                            <Items>
                                                <ext:Label runat="server" ID="LESTADO" Cls="ReaderStateConnect" Text="Conectado Lector" Icon="Anchor" />
                                            </Items>
                                        </ext:Container>
                                        <ext:SpaceFillingChart runat="server" Width="240" />
                                        <ext:Container runat="server" Width="300">
                                            <Items>
                                                <ext:Label runat="server" ID="LCLOCK" Cls="Font-Clock" />
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Listeners>
                        <AfterRender Handler="loadDevice(); ">
                        </AfterRender>
                    </Listeners>
                </ext:FormPanel>

                <%--------------------------------  FORMULARIO DE TOMA EL AREA A LA QUE SE DIRIGE EL VISITANTE -----------------------------%>

                <ext:Window runat="server" ID="WVISITANTE" Width="400" Height="360" Frame="true" UI="Warning" Closable="false" Hidden="true">
                    <Items>
                        <ext:FormPanel ID="FVISITANTE" runat="server" Draggable="false" Resizable="true" Width="390">
                            <Items>
                                <ext:FormPanel runat="server" ID="FREGISTROVISITANTE" Padding="5" Layout="ColumnLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:Panel ID="PINCIDENCIAVISITA" runat="server" DefaultWidth="400">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="CAREATRABAJO" FieldLabel="DEPENDENCIA " ForceSelection="true" MarginSpec="0 3 0 0" DisplayField="AREA" ValueField="CODIGO" Width="380" AllowBlank="false">
                                                    <Store>
                                                        <ext:Store runat="server" ID="SDEPENDENCIA">
                                                            <Model>
                                                                <ext:Model ID="Model2" runat="server" IDProperty="CODIGO">
                                                                    <Fields>
                                                                        <ext:ModelField Name="CODIGO" />
                                                                        <ext:ModelField Name="EXT" />
                                                                        <ext:ModelField Name="AREA" />
                                                                    </Fields>
                                                                </ext:Model>
                                                            </Model>
                                                        </ext:Store>
                                                    </Store>

                                                </ext:ComboBox>
                                                <ext:ToolbarSpacer runat="server" Height="20" />
                                                <ext:TextArea ID="TextArea1" FieldLabel="RAZON DE LA VISITA:" runat="server" Width="380" Height="200" />
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                    <Listeners>
                                        <ValidityChange Handler="#{BGUARDAR}.setDisabled(!valid);" />
                                    </Listeners>
                                </ext:FormPanel>
                            </Items>
                            <BottomBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:ToolbarFill />
                                        <ext:Button runat="server" ID="Button1" Text="Finalizar" FormBind="true" UI="Info">
                                            <Listeners>
                                                <Click Handler="if(#{FREGISTROVISITANTE}.getForm().isValid()) { App.WVISITANTE.hide(); }else{ return false;}  " />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </BottomBar>
                            <Listeners>
                            </Listeners>
                        </ext:FormPanel>
                    </Items>
                </ext:Window>

            </Items>

        </ext:Viewport>


        <%--------------------------------  FORMULARIO DE GENERA LA INCIDENCIA DE LA TARDANZA -----------------------------%>

        <ext:Window runat="server" ID="WINCIDENCIA" Width="430" Height="385" Frame="true" UI="Danger" Closable="false" Hidden="true">
            <Items>
                <ext:FormPanel ID="FINCIDENCIA" runat="server" Draggable="false" Resizable="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="FREGISTROINCIDENCIA" Padding="10" Layout="ColumnLayout">
                            <FieldDefaults LabelAlign="Top" />
                            <Items>
                                <ext:Panel ID="PPREVIO" runat="server" DefaultWidth="400">
                                    <Items>
                                        <ext:ToolbarSpacer runat="server" Height="5" />
                                        <ext:TextField ID="TINCIDENCIA" FieldLabel="Descripcion Incidencia:" runat="server" Flex="1" ReadOnly="true" />
                                        <ext:ToolbarSpacer runat="server" Height="20" />
                                        <ext:TextArea ID="TOBSERVACION" FieldLabel="Justifique el tiempo de tardanza" runat="server" Height="200" AllowBlank="false" />
                                    </Items>
                                </ext:Panel>
                            </Items>
                            <Listeners>
                                <ValidityChange Handler="#{BGUARDAR}.setDisabled(!valid);" />
                            </Listeners>
                        </ext:FormPanel>
                    </Items>
                    <BottomBar>
                        <ext:Toolbar ID="Toolbar3" runat="server">
                            <Items>
                                <ext:ToolbarFill />
                                <ext:Button runat="server" ID="BGUARDAR" Text="Finalizar" UI="Danger">
                                    <Listeners>
                                        <%--<Click Handler="if(#{FREGISTRO}.getForm().isValid()) {App.direct.registrarHorario(App.THINICIO.getValue(),App.THFIN.getValue());}else{ return false;}  " />--%>
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </BottomBar>
                    <Listeners>
                        <%--<BeforeHide Handler="App.FREGISTRO.reset();parametro.consultarHorarios();" />--%>
                    </Listeners>
                </ext:FormPanel>
            </Items>
        </ext:Window>



    </form>
</body>
</html>
