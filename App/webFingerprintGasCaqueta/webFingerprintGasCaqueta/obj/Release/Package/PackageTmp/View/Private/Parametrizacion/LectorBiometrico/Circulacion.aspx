<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Circulacion.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Public.Empleado_circulacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
	    function DeviceConnected(){
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

                <ext:FormPanel runat="server" BodyPadding="8" AutoScroll="true" Title="VALIDACION EMPLEADO." Weight="900" Icon="UserKey">
                    <FieldDefaults LabelAlign="Right" LabelWidth="115" MsgTarget="Side" />
                    <Items>
                        <ext:Panel runat="server" Layout="ColumnLayout" MarginSpec="2">
                            <Items>
                                <ext:Label runat="server" Text="Identificación:"   />
                                <ext:TextField runat="server" ID="TFILTRO" >
                                   <%-- <Listeners>
                                        <KeyPress Handler="if(e.getKey() == Ext.EventObject.ENTER){
                                                            FhuellaUsuario();
                                                           }"   
                                                  Buffer="200"  />
                                                                                
                                    </Listeners>--%>
                                </ext:TextField>
                                <ext:Button ID="Bbuscar" Text="Buscar" runat="server" >
                                    <Listeners>
                                        <Click Handler ="FhuellaUsuario();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server">
                            <Items>
                                <ext:TextField runat="server" ID="TTIPOUSUARIO" FieldLabel="TIPO USUARIO:" ReadOnly="true" />
                                 <ext:TextField runat="server" ID="TUSUARIO" FieldLabel="USUARIO: " ReadOnly="true" />
                            </Items>
                        </ext:Panel>
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
                     
                    </Items>
                    <BottomBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Label runat="server" ID="LBIOMETRICOSTATE"  Width="250" />
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
     
    </form>
</body>
</html>
