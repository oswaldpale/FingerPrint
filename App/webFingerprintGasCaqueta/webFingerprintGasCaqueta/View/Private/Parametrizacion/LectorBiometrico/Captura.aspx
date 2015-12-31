<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captura.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.LectorBiometrico.Captura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
    
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
	                    App.LFINGERPRINTNEED.setHtml('<font face="Comic Sans MS,arial,verdana" color="red">Muestra de Huella Necesaria: ' + StateFingerPrintNeed + '</font>');
	                }
	            }
	            if (typeof (NotifyBiometricDevice) != "undefined" || NotifyBiometricDevice != null) {

	                if (NotifyBiometricDevice != obj.MessageBiometricDevice()) {
	                    NotifyBiometricDevice = obj.MessageBiometricDevice();
	                    App.TBIOMETRICOESTADO.clear();
	                    App.TBIOMETRICOESTADO.appendLine(NotifyBiometricDevice);

	                }
	                CheckFingerPrint = obj.CheckFingerprint();
	                if (typeof (CheckFingerPrint) != "undefined" || CheckFingerPrint != null) {
	                    if (CheckFingerPrint == 'true') {
	                        StateFingerPrintNeed = obj.StateEnrroller();
	                        BitmapDactilar = obj.BitmapDactilar();
	                        App.direct.CreateSessionImage(BitmapDactilar, StateFingerPrintNeed);
	                        obj.checkFingerprint = 'false';
	                        obj.bitmapDactilar = null;
	                        App.LFINGERPRINTNEED.setHtml('<font face="Comic Sans MS,arial,verdana" color="red">Muestra de Huella Necesaria: ' + StateFingerPrintNeed + '</font>');
	                    } else {

	                        if (StateFingerPrintNeed == 0) {
	                            parametro.registrarHuella(obj.Footprint(), '112345', {
	                                success: function (result) {
	                                    App.TBIOMETRICOESTADO.appendLine('Finalizado Incripción de la Huella!');
	                                    App.TBIOMETRICOESTADO.appendLine('Guardado Exitosamente!');
	                                }, failure: function (errorMsg) {
	                                    App.TBIOMETRICOESTADO.appendLine('Ha ocurrido un error!');
	                                }
	                            });
	                            obj.stateEnrroller = -1;
	                        }
	                    }
	                }
	            } else {
	                NotifyBiometricDevice = obj.MessageBiometricDevice();
	                App.TBIOMETRICOESTADO.clear();
	                App.TBIOMETRICOESTADO.appendLine(NotifyBiometricDevice);
	               

	            }
	            Concurrent.Thread.sleep(800);
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
                                <ext:Label runat="server" ID="LFINGERPRINTNEED"  Width="250" />
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

