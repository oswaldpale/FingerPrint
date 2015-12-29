<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscripcion.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.CapturarHuella" %>

<html>
<head>
	<title></title>
    <script src="../../Content/js/Concurrent.Thread.js"></script>
	<script type="text/javascript">
	 try {
	     var obj = new ActiveXObject("PluginDigitalPersona.pluginDigitalpersona");
	     if (obj != 'undefined') {   
	        Concurrent.Thread.create(proceso);
	     }
	 }catch (e) {
            alert('Incompatibilidad con ActiveX');
     }
        function mensaje(){
        		 alert(obj.MessageBiometricDevice());
        }
        function proceso() {
           
            while (true) {
                Ext.net.Notification.show({
                    html: ' entro ',
                    title: 'Notificación'
                });
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
                                        <ext:Image ID="Image1" runat="server" ImageUrl="../../../../Content/images/SinHuella.png" Width="160px" Height="160px">
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
                                <ext:ToolbarFill />
                                <ext:Button runat="server" Text="CAPTURA">
                                    <Listeners>
                                       
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Text="GUARDAR">
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </BottomBar>
                   
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
