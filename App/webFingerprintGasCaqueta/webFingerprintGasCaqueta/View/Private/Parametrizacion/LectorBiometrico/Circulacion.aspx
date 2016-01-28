<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Circulacion.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Public.Empleado_circulacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                        <ext:Panel runat="server" ID="PPRINCIPAL">
                            <Items>
                                <ext:Panel runat="server" ID="PNORTE" Region="North" Height="40">
                                </ext:Panel>
                                <ext:Panel runat="server" ID="PCONTENEDOR" Layout="ColumnLayout" >
                                    <Items>
                                        <ext:Panel runat="server" ID="PDATOS"  Title="CENTRO" Width="700">
                                            <Items>
                                                <ext:Panel ID="PDATOSPERSONA" runat="server" Title="INFORMACION"  Height="200" />
                                                <ext:Panel ID="PALERTAS" runat="server" Title="ALERTAS"  Height="200" />
                                            </Items>
                                        </ext:Panel>
                                        <%-- <ext:Panel runat="server" Title="Oeste" Region="Center" Collapsible="false"  Height="300" />--%>
                                        <ext:Panel runat="server" ID="PFOTOS"  Width="284" Height="480" Layout="VBoxLayout">
                                            <Items>
                                                <ext:Panel runat="server" Height="230"  Width="280" Frame="false"   Layout="CenterLayout">
                                                    <Items>
                                                          <ext:Image ID="IMDACTILAR" runat="server" ImageUrl="../../../../Content/images/SinHuella.png" Width="160px" Height="160px">
                                                        </ext:Image>
                                                       
                                                    </Items>
                                                </ext:Panel>
                                                <ext:Panel runat="server" Height="230" Width="280"  Layout="CenterLayout">
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
