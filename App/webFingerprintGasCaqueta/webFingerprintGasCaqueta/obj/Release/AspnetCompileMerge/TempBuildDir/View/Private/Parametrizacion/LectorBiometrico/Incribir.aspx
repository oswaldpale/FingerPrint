<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Incribir.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.LectorBiometrico.Incribir" %>

<!DOCTYPE html>

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
            case 'register':
                var r = data.payload[0];
                switch (r.state) {
                    case 'procces':
                        App.LFINGERPRINTNEED.setHtml('<font face="Comic Sans MS,arial,verdana" color="red">Muestra de Huella Necesaria: ' + r.enrroller + '</font>');
                        break;
                    case 'complete':
                        App.LFINGERPRINTNEED.setHtml('<font face="Comic Sans MS,arial,verdana" color="red">Muestra de Huella Necesaria: ' + r.enrroller + '</font>');
                        App.TBIOMETRICOESTADO.appendLine('Finalizado Registro de la Huella!');
                        App.TBIOMETRICOESTADO.appendLine('Guardado Exitosamente!');
                        break;
                    case 'failed':
                        App.TBIOMETRICOESTADO.appendLine('Ha ocurrido un error!');
                        break;

                }

                App.IMDACTILAR.setImageUrl('data:image/png;base64,' + r.data + '');
                break;

            case 'connect':
                App.TBIOMETRICOESTADO.clear();
                App.TBIOMETRICOESTADO.appendLine('Conectado Dispositivo');
                break;

            case 'disconnect':
                App.TBIOMETRICOESTADO.clear();
                App.TBIOMETRICOESTADO.appendLine('Desconectado Dispositivo');
                break;
        }
        
    }

    function loadDevice() {   //local,products
        emit('connectserver', { type: String('products') });
        emit('register', { user: String(App.HIDENTIFICACION.getValue()), finger: String(App.HDEDO.getValue()) });
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <ext:ResourceManager ID="ResourceManager2" Theme="Crisp" runat="server" />
        <ext:Hidden ID="HDEDO" runat="server" />
        <ext:Hidden ID="HIDENTIFICACION" runat="server" />
        <ext:Viewport runat="server" >
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>

                <ext:FormPanel ID="FCAPTURA" runat="server" BodyPadding="2" AutoScroll="true"  Weight="280" UI="Info" Frame="true">
                    <FieldDefaults LabelAlign="Right" LabelWidth="115" MsgTarget="Side" />
                    <Items>
                        <ext:Panel runat="server"  Width="280" >
                            <Items>
                                <ext:Panel runat="server" Border="false" Layout="CenterLayout" Height="200" BodyPadding="20" Frame="true">
                                    <Content>
                                        <ext:Image ID="IMDACTILAR" runat="server" ImageUrl="../../../../Content/images/SinHuella.png"  Width="200px" Height="170px">
                                        </ext:Image>
                                         <%--<img src="" alt="Imagen_Huella" width="200px"  weight="170px" />--%>
                                    </Content>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Border="false" Height="80" Layout="FormLayout" Width="281" BorderSpec="1 0 0 0" UI="Info"  >
                            <Items>
                                <ext:TextArea runat="server"  ID="TBIOMETRICOESTADO"  Height="10" Width="270"  EmptyText="Estado del Lector.." ReadOnly="true" />
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
                        <AfterRender Handler="loadDevice(); ">
                        </AfterRender>
                    </Listeners>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
   
    </form>
</body>
</html>
