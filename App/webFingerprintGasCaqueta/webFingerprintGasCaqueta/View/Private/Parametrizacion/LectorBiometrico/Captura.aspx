<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captura.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.LectorBiometrico.Captura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
    
    <script src="../../../../Content/js/Concurrent.Thread.js"></script>
  
     <style type="text/css">
      /**/
      #unlicensed{
	        display: none !important;
      }
	 </style>
	<script type="text/javascript">
	   
	    try {
	        var obj = new ActiveXObject("PluginDigitalPersona.pluginDigitalpersona");
	        var ImagenSrc;
	    } catch (e) {
	        var _ActiveXError = e;
	    }

	    function DeviceConnected() {
	        if (_ActiveXError != null) {
	            App.FCAPTURA.setDisabled(true);
	            Ext.Msg.show({
	                title: 'Advertencia!',
	                msg: 'El Navegador no esta configurado!',
	                buttons: Ext.Msg.YES,
	                animEl: 'elId',
	                icon: Ext.MessageBox.ERROR
	            });
	        } else {
	            obj.dedo = App.HDEDO.getValue();
	            obj.identificacion = App.HIDENTIFICACION.getValue();
	            var r = App.HIDENTIFICACION.getValue();
	            Concurrent.Thread.create(proceso);
            }
            
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
	                        ImagenSrc = BitmapDactilar;
	                     
	                        App.IMDACTILAR.setImageUrl('data:image/png;base64,' + BitmapDactilar +'');
	                        obj.checkFingerprint = 'false';
	                        obj.bitmapDactilar = null;
	                        App.LFINGERPRINTNEED.setHtml('<font face="Comic Sans MS,arial,verdana" color="red">Muestra de Huella Necesaria: ' + StateFingerPrintNeed + '</font>');
	                    } else {

	                        if (StateFingerPrintNeed == 0) {
	                            if (obj.ResultRegister())
	                            {
	                                App.TBIOMETRICOESTADO.appendLine('Finalizado Incripción de la Huella!');
	                                App.TBIOMETRICOESTADO.appendLine('Guardado Exitosamente!');
	                            } else {
	                                App.TBIOMETRICOESTADO.appendLine('Ha ocurrido un error!');
	                            }
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
        <ext:Hidden ID="HDEDO" runat="server" />
        <ext:Hidden ID="HIDENTIFICACION" runat="server" />
        <ext:Viewport runat="server" >
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>

                <ext:FormPanel ID="FCAPTURA" runat="server" BodyPadding="8" AutoScroll="true"  Weight="280">
                    <FieldDefaults LabelAlign="Right" LabelWidth="115" MsgTarget="Side" />
                    <Items>
                        <ext:Panel runat="server" Border="true" Width="280" >
                            <Items>
                                <ext:Panel runat="server" Border="false" Layout="CenterLayout" Height="200" BodyPadding="20">
                                    <Content>
                                        <ext:Image ID="IMDACTILAR" runat="server" ImageUrl="../../../../Content/images/SinHuella.png"  Width="200px" Height="170px">
                                        </ext:Image>
                                         <%--<img src="" alt="Imagen_Huella" width="200px"  weight="170px" />--%>
                                    </Content>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Border="false" Height="70" Layout="FormLayout" Width="280"  >
                            <Items>
                                <ext:TextArea runat="server"  ID="TBIOMETRICOESTADO" Border="false" Height="10"  EmptyText="Estado del Lector.." ReadOnly="true" />
                            </Items>
                        </ext:Panel>
                    </Items>
                    <BottomBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Label runat="server" ID="LFINGERPRINTNEED"  Width="250" />
                                <ext:ToolbarFill />
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
        <img src="{{ImagenSrc}}"/>
    </form>
</body>
</html>

