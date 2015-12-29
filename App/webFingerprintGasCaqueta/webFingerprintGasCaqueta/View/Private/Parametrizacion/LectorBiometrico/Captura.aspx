﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captura.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.LectorBiometrico.Captura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
      <script runat="server">
          public const string OPERA_PATH = "";

     </script>

    <script src="../../../../Content/js/Concurrent.Thread.js"></script>
	<script type="text/javascript">
	 try {
	     var obj = new ActiveXObject("PluginDigitalPersona.pluginDigitalpersona");
	         
        }
        catch (e) {
            alert('Incompatibilidad con ActiveX');
        }
	    function DeviceConnected(){
            Concurrent.Thread.create(proceso);
        }

        function proceso() {
            var NotifyBiometricDevice = null;
            var StateFingerPrintNeed = null;
            var CheckFingerPrint = null;
            var BitmapDactilar = null;
            while (true) {
                if (typeof (StateFingerPrintNeed) != "undefined" || StateFingerPrintNeed != null) {
                    if (StateFingerPrintNeed != obj.StateEnrroller()) {
                        StateFingerPrintNeed = obj.StateEnrroller();
                        App.LFINGERPRINTNEED.append('Muestra de Huella Necesaria: ' + StateFingerPrintNeed );
                    }
                }
                if (typeof (NotifyBiometricDevice) != "undefined" || NotifyBiometricDevice != null) {
                   
                    if (NotifyBiometricDevice != obj.MessageBiometricDevice()) {
                        NotifyBiometricDevice = obj.MessageBiometricDevice();
                        App.TBIOMETRICOESTADO.clear();
                        StateFingerPrintNeed = obj.StateEnrroller();
                        console.log(StateFingerPrintNeed);
                        App.TBIOMETRICOESTADO.appendLine(NotifyBiometricDevice);
                        App.LFINGERPRINTNEED.append('Muestra de Huella Necesaria: ' + StateFingerPrintNeed);
                    }
                    CheckFingerPrint = obj.CheckFingerprint();
                    if (typeof (CheckFingerPrint) != "undefined" || CheckFingerPrint != null) {
                        if (CheckFingerPrint == 'true') {
                            obj.checkFingerprint = 'false';
                            BitmapDactilar = obj.BitmapDactilar();
                            App.direct.CreateSessionImage(BitmapDactilar);
                        } else {
                           
                        }
                    }
                } else {
                    NotifyBiometricDevice = obj.MessageBiometricDevice();
                    App.TBIOMETRICOESTADO.clear();
                    App.TBIOMETRICOESTADO.appendLine(NotifyBiometricDevice);
                }
                
                Concurrent.Thread.sleep(1000);
            }
        }
        
	</script>
</head>
<body>
    <form id="form1" runat="server" >
        <ext:ResourceManager ID="ResourceManager2" Theme="Gray" runat="server" />
        <ext:Viewport runat="server" >
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>

                <ext:FormPanel runat="server" BodyPadding="8" AutoScroll="true" Title="INSCRIPCÍON DE HUELLA." Weight="600">
                    <FieldDefaults LabelAlign="Right" LabelWidth="115" MsgTarget="Side" />
                    <Items>
                        <ext:Panel runat="server" Layout="ColumnLayout">
                            <Items>
                                <ext:Panel runat="server" Border="false" AutoScroll="true" Region="East" Height="200" BodyPadding="20">
                                    <Items>
                                        <ext:Image ID="IMPERFIL" runat="server" ImageUrl="../../../../Content/images/SinFoto.jpg" Width="160px" Height="160px">
                                        </ext:Image>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Border="false" AutoScroll="true" Region="West" Height="200" BodyPadding="20">
                                    <Items>
                                        <ext:Image ID="IMDACTILAR" runat="server" ImageUrl="../../../../Content/images/SinHuella.png" Width="160px" Height="160px">
                                        </ext:Image>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Border="false" Height="80" Layout="FormLayout" Width="400"  >
                            <Items>
                                <ext:TextArea runat="server"  ID="TBIOMETRICOESTADO" Border="false" Height="30"   AutoScroll="true" EmptyText="Estado del Lector.." />
                            </Items>
                        </ext:Panel>
                    </Items>
                    <BottomBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Label runat="server" ID="LFINGERPRINTNEED" Html="<font face='Comic Sans MS,arial,verdana' color='red'></font>" Width="150" />
                                <ext:ToolbarFill />
                                <ext:Button runat="server" Text="CANCELAR">
                                    <Listeners>
                                        <%--<Click Handler ="" />--%>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Text="GUARDAR">
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </BottomBar>
                 <Listeners>
                     <AfterRender Handler="DeviceConnected();">
                     </AfterRender>
                 </Listeners>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
     
    </form>
</body>
</html>

