<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Circulacion.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Public.Empleado_circulacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title> Control de Acceso</title>
    <link href="../../../../Content/css/degraded.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Content/js/Concurrent.Thread.js"></script>
    <script type="text/javascript">
        try {
            var obj = new ActiveXObject("PluginDigitalPersona.pluginDigitalpersona");
            obj.typeProcces = "validation";
        }
        catch (e) {
            alert('Incompatibilidad con ActiveX');
        }
        function FhuellaUsuario() {
            parametro.consultarHuellas(App.TFILTRO.getValue(), {
                success: function (result) {
                    obj.JsonToString(result);
                }, failure: function (errorMsg) {
                    Ext.net.Notification.show({
                        html: 'Ha ocurrido un error!', title: 'Notificación'
                    });
                }
            });
        }
        function DeviceConnected() {
            Concurrent.Thread.create(proceso);
        }

        function proceso() {
            var NotifyBiometricDevice = null;
            var CheckFingerPrint = null;
            var BitmapDactilar = null;
           
            while (true) {
                parametro.RefreshTime();
                if (typeof (NotifyBiometricDevice) != "undefined" || NotifyBiometricDevice != null) {
                    parametro.RefreshTime();
                    if (NotifyBiometricDevice != obj.MessageBiometricDevice()) {
                        NotifyBiometricDevice = obj.MessageBiometricDevice();
                        parametro.ChangeReaderInf(NotifyBiometricDevice);
                    }
                    CheckFingerPrint = obj.CheckFingerprint();
                    if (typeof (CheckFingerPrint) != "undefined" || CheckFingerPrint != null) {
                        if (CheckFingerPrint == 'true') {
                            BitmapDactilar = obj.BitmapDactilar();
                            App.IMDACTILAR.setImageUrl('data:image/png;base64,' + BitmapDactilar + '');
                               
                            obj.bitmapDactilar = null;
                            var _stateUserVerify  = obj.StateUserVerify();
                            if (typeof (_stateUserVerify) != "undefined") {
                               
                                if (_stateUserVerify  == 'true') {
                                    parametro.consultarTipoIngreso(App.TIDUSER.getValue(), {   /// pa la siguiente fase se puede hacer el cruze de los horarios.
                                        success: function (result) {
                                          if (result == false) {    // retorna false----> registra una entrada
                                                parametro.registrarEntrada(App.TIDUSER.getValue(), {
                                                    success: function (result) {
                                                        Ext.net.Notification.show({
                                                            html: 'Bienvenido a Gas Caqueta!', title: 'Notificación'
                                                        });

                                                    }, failure: function (errorMsg) {
                                                        Ext.net.Notification.show({
                                                            html: 'Ha ocurrido un error!', title: 'Notificación'
                                                        });
                                                    }
                                                });
                                            } else {           // registra una salida -->xq ya existe una entrada..
                                                
                                                parametro.registrarSalida(App.TIDTUPLA.getValue(), App.TIDUSER.getValue(), {
                                                    success: function (result) {
                                                        Ext.net.Notification.show({
                                                            html: 'Buen Descanso Adios!', title: 'Notificación'
                                                        });
                                                       
                                                    }, failure: function (errorMsg) {
                                                        Ext.net.Notification.show({
                                                            html: 'Ha ocurrido un error!', title: 'Notificación'
                                                        });
                                                    }
                                                });
                                            }
                                        }, failure: function (errorMsg) {
                                            Ext.net.Notification.show({
                                                html: 'Ha ocurrido un error!', title: 'Notificación'
                                            });
                                        }

                                    });

                                } else {
                                    Ext.net.Notification.show({
                                        html: 'Acceso Denegado!', title: 'Notificación'
                                    });
                                }
                               
                            }
                           
                            obj.checkFingerprint = 'false';
                        }
                        
                    }

                } else {
                    NotifyBiometricDevice = obj.MessageBiometricDevice();
                    parametro.ChangeReaderInf(NotifyBiometricDevice);
                }
                Concurrent.Thread.sleep(1000);
            }
        }

        var findUser = function (texto, e) {
            if (e.getKey() == 13) {
                parametro.buscarUsuario(texto, {
                    success: function (result) {
                        obj.Start();// Habilito el lector Biometrico....
                        VID = App.TIDUSER.getValue();
                        obj.identificacion = VID ;
                        App.LMENSAJE.setText('Por Favor Ingrese Su Huella');            // Mensaje de Ingrese la Huella...
                         //Si es verdadero   ---->Realizo el Cruze de horario para darle permiso al empleado
                    }, failure: function (errorMsg) {
                        Ext.net.Notification.show({
                            html: 'Ha ocurrido un error!', title: 'Notificación'
                        });
                    }
                });
               
            }
        };



    </script>
</head>
<body>
    <form id="form1" runat="server">
        
        <ext:ResourceManager ID="ResourceManager2" Theme="Crisp" runat="server" AjaxTimeout="20000" />
        <ext:Viewport runat="server">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:TextField runat="server" ID="TIDUSER"  Hidden="true"/>
                <ext:TextField runat="server" ID="TIDTUPLA"  Hidden="true"/>
                <ext:Window ID="WPRINCIPAL" runat="server" Title="Control de Acceso" Icon="User" Width="900" Height="600" UI="Info"  Draggable="false" Closable="false">
                    <Items>
                        <ext:Panel runat="server" ID="PPRINCIPAL" Border="false">
                            <Items>
                                <ext:Panel runat="server" ID="PNORTE" Region="North" Height="40" Border="false" BodyCls="TopBarDegraded" >
                                    <Items>
                                         <ext:Image ID="ILOGO" runat="server" ImageUrl="" Width="16px" Height="16px" Floating ="true" />
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" ID="PCONTENEDOR" Layout="ColumnLayout" Border="false" >
                                    <Items>
                                        <ext:Panel runat="server" ID="PDATOS"  Width="600" Border="true"  >
                                            <Items>
                                                <ext:Panel ID="PDATOSPERSONA" runat="server" Height="240" Border="false"  >
                                                    <Items>
                                                        <ext:Container runat="server" Height="100" Layout="CenterLayout" Cls="UserInf" >
                                                            <Items>
                                                                <ext:DropDownField ID="DDIDENTIFICACION" runat="server" Width ="500" TriggerIcon="Search" EmptyText="Ingrese su número de identificación." FieldLabel="Identificación:" LabelWidth="150" UI="Default" BodyStyle="padding:2px 2px;" EnableKeyEvents="true" >
                                                                    <Component>
                                                                        <ext:Panel runat="server" Height="200" ID="PBUSQUEDA">
                                                                            <Items>
                                                                                <ext:GridPanel ID="GSEARCHUSER" runat="server" Cls="extra-alt">
                                                                                    <Store>
                                                                                        <ext:Store ID="SUSUARIO" runat="server" PageSize="10">
                                                                                            <Model>
                                                                                                <ext:Model runat="server">
                                                                                                    <Fields>
                                                                                                        <ext:ModelField Name="IDENTIFICACION"  />
                                                                                                        <ext:ModelField Name="NOMBRE" />
                                                                                                        <ext:ModelField Name="TIPO" />
                                                                                                    </Fields>
                                                                                                </ext:Model>
                                                                                            </Model>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <ColumnModel runat="server">
                                                                                        <Columns>
                                                                                            <ext:Column runat="server" ID="CIDENTIFICACION" Text="IDENTIFICACIÓN" DataIndex="IDENTIFICACION" Width="160" />
                                                                                            <ext:Column runat="server" ID="CNOMBRE" Text="NOMBRE" DataIndex="NOMBRE" Flex="3" />
                                                                                        </Columns>
                                                                                    </ColumnModel>
                                                                                </ext:GridPanel>
                                                                            </Items>
                                                                        </ext:Panel>
                                                                    </Component>
                                                                    <Listeners>
                                                                         <KeyPress Handler="findUser(App.DDIDENTIFICACION.getValue(), Ext.EventObject);" Buffer="200" />
                                                                    </Listeners>
                                                                </ext:DropDownField>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Layout="CenterLayout" Cls="UserInf" Height="40" >
                                                            <Items>
                                                                <ext:TextField ID="TTIPOOUSUARIO" runat="server" Width="500"   FieldLabel="TIPO" LabelWidth="150"  />
                                                            </Items>
                                                        </ext:Container>
                                                         <ext:Container runat="server" Layout="CenterLayout"  Cls="UserInf" >
                                                            <Items>
                                                                  <ext:TextField runat="server" ID="TUSUARIO"  Width="500" ReadOnly="true" FieldLabel="USUARIO" LabelWidth="150" />
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Layout="CenterLayout"  Cls="UserInf" Height="40" >
                                                            <Items>
                                                                <ext:TextField runat="server" ID="TCARGO"  Width="500" ReadOnly="true" FieldLabel="CARGO" LabelWidth="150"  />
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Panel>
                                                <ext:Panel ID="PALERTAS" runat="server"   Height="238" Border="false">
                                                    <Items>
                                                        <ext:Container runat="server" Layout="CenterLayout"  >
                                                            <Items>
                                                                  <ext:Panel ID="PMENSAJE" runat="server" Width="500" Title="MENSAJE" Frame="true" UI="Info" Height="200" Layout="CenterLayout" >
                                                                      <Items>
                                                                          <ext:Label runat="server" ID="LMENSAJE" Text="BIENVENIDO.. " Cls="UserInf" />
                                                                      </Items>
                                                                  </ext:Panel>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Panel>
                                            </Items>
                                        </ext:Panel>
                                        <%-- <ext:Panel runat="server" Title="Oeste" Region="Center" Collapsible="false"  Height="300" />--%>
                                        <ext:Panel runat="server" ID="PFOTOS"  Width="284" Height="480" Layout="VBoxLayout" Border="true" Frame="true" >
                                            <Items>
                                                <ext:Panel runat="server" Height="240"  Width="284" Frame="false"   Layout="CenterLayout" Border="false">
                                                    <Items>
                                                          <ext:Image ID="IMDACTILAR" runat="server" Cls="RoundFinger" ImageUrl="../../../../Content/images/SinHuella.png" Width="160px" Height="160px">
                                                        </ext:Image>
                                                    </Items>
                                                </ext:Panel>
                                                <ext:Panel runat="server" Height="240" Width="284"  Layout="CenterLayout" Border="false"  >
                                                    <Items>
                                                       <ext:Image ID="IMPERFIL" runat="server" ImageUrl="../../../../Content/images/SinFoto.jpg" Width="160px" Height="160px">
                                                        </ext:Image>
                                                    </Items>
                                                </ext:Panel>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" ID="PSUR" Height="50"  Layout="TableLayout" BodyCls="FootBarDegraded">
                                    <Items>
                                        <ext:Container runat="server" Width="450">
                                            <Items>
                                                <ext:Label runat="server" ID="LESTADO" />
                                            </Items>
                                        </ext:Container>
                                        <ext:SpaceFillingChart runat="server" Width="240" />
                                        <ext:Container runat="server" Width="280">
                                            <Items>
                                                <ext:Label runat="server" ID="LCLOCK" Cls="Font-Clock" />
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                    </Items>
                    <Listeners>
                        <AfterRender Handler="DeviceConnected();">
                        </AfterRender>
                    </Listeners>
                </ext:Window>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
