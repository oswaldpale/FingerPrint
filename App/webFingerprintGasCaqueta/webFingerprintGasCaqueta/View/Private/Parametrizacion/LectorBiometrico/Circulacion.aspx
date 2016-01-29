<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Circulacion.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Public.Empleado_circulacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title> Control de Acceso</title>
    <link href="../../../../Content/css/degraded.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Content/js/Concurrent.Thread.js"></script>
    <script type="text/javascript">
        <%--       try {
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
            var StateFingerPrintNeed = null;
            var CheckFingerPrint = null;
            var BitmapDactilar = null;
            while (true) {

                if (typeof (NotifyBiometricDevice) != "undefined" || NotifyBiometricDevice != null) {

                    if (NotifyBiometricDevice != obj.MessageBiometricDevice()) {
                        NotifyBiometricDevice = obj.MessageBiometricDevice();
                        App.LBIOMETRICOSTATE.setHtml('<font face="Comic Sans MS,arial,verdana" color="red">' + NotifyBiometricDevice + '</font>');

                    }
                    CheckFingerPrint = obj.CheckFingerprint();
                    if (typeof (CheckFingerPrint) != "undefined" || CheckFingerPrint != null) {
                        if (CheckFingerPrint == 'true') {

                            BitmapDactilar = obj.BitmapDactilar();
                            App.direct.CreateSessionImage(BitmapDactilar, Math.random());
                            obj.checkFingerprint = 'false';
                            obj.bitmapDactilar = null;
                        }
                    }
                } else {
                    NotifyBiometricDevice = obj.MessageBiometricDevice();
                    App.LBIOMETRICOSTATE.setHtml('<font face="Comic Sans MS,arial,verdana" color="red">' + NotifyBiometricDevice + '</font>');


                }
                Concurrent.Thread.sleep(800);
            }
        }--%>

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager2" Theme="Gray" runat="server" />
        <ext:Viewport runat="server">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:Window ID="WPRINCIPAL" runat="server" Title="Control de Acceso" Icon="User" Width="1000" Height="600">
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
                                        <ext:Panel runat="server" ID="PDATOS"  Width="700" >
                                            <Items>
                                                <ext:Panel ID="PDATOSPERSONA" runat="server"   Height="240" Border="false">
                                                    <Items>
                                                        
                                                    </Items>
                                                </ext:Panel>
                                                <ext:Panel ID="PALERTAS" runat="server"   Height="238" Border="false" />
                                            </Items>
                                        </ext:Panel>
                                        <%-- <ext:Panel runat="server" Title="Oeste" Region="Center" Collapsible="false"  Height="300" />--%>
                                        <ext:Panel runat="server" ID="PFOTOS"  Width="284" Height="480" Layout="VBoxLayout" Border="false" >
                                            <Items>
                                                <ext:Panel runat="server" Height="240"  Width="284" Frame="false"   Layout="CenterLayout" Border="false">
                                                    <Items>
                                                          <ext:Image ID="IMDACTILAR" runat="server" ImageUrl="../../../../Content/images/SinHuella.png" Width="160px" Height="160px">
                                                        </ext:Image>
                                                       
                                                    </Items>
                                                </ext:Panel>
                                                <ext:Panel runat="server" Height="240" Width="284"  Layout="CenterLayout" Border="false" >
                                                    <Items>
                                                       <ext:Image ID="IMPERFIL" runat="server" ImageUrl="../../../../Content/images/SinFoto.jpg" Width="160px" Height="160px">
                                                        </ext:Image>
                                                    </Items>
                                                </ext:Panel>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" ID="PSUR" Height="50" />
                            </Items>
                        </ext:Panel>
                    </Items>
                    <%-- <Listeners>
                                <AfterRender Handler="DeviceConnected();">
                                </AfterRender>
                            </Listeners>--%>
                </ext:Window>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
