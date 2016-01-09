<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarEmpleados.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Empleado.ListarEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../../Content/css/Style.css" rel="stylesheet" />
    <title>LISTA DE EMPLEADOS</title>
    <script type="text/javascript">

        function AbrirVentanaIncripcionHuella(record) {
            parametro.AbrirVentanaIncripcionHuella(record.get("MCODIGO"), 'Primaria');
        }

        var prepareCommand = function (grid, command, record, row) {
            if (command == 'footprint1') {
                parametro.ConsultarEstadoHuella(record.get("MCODIGO"), 'Primaria', {
                    success: function (result) {
                        console.log(result);
                        if (result == 'true') {
                            alert(record.get("MCODIGO"));
                            Ext.Msg.show({
                                title: 'Notificación',
                                msg: '¿Desea reemplazar la huella existente?',
                                buttons: Ext.Msg.YESNO,
                                fn: alert(''),
                                animEl: 'elId',
                                icon: Ext.MessageBox.INFO
                            });
                        } else {
                            AbrirVentanaIncripcionHuella(record)
                        }
                    }
                });
               
            }
            if (command == 'footprint2') {
                parametro.AbrirVentanaIncripcionHuella(record.get("MCODIGO"), 'Secundario', {
                    success: function (result) {
                        ///aca puedo hacer algo... 
                    }, failure: function (errorMsg) {
                        Ext.net.Notification.show({
                            html: 'Ha ocurrido un error al abrir la pagina.!', title: 'Notificación'
                        });
                    }
                });
            }
        };

        var findUser = function (Store, texto, e) {
            if (e.getKey() == 13) {
                var store = Store,
                    text = texto;
                store.clearFilter();
                if (Ext.isEmpty(text, false)) {
                    return;
                }
                var re = new RegExp(".*" + text + ".*", "i");
                store.filterBy(function (node) {
                    var RESUMEN = node.data.MIDENTIFICACION + node.data.MNOMBRE + node.data.MTIPO;
                    var a = re.test(RESUMEN);
                    return a;
                });
            }
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <ext:ResourceManager ID="ResourceManager2" runat="server" />
        <ext:Viewport runat="server" >
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:FormPanel runat="server" BodyPadding="8" AutoScroll="true" Height="500" Width="920" >
                    <FieldDefaults LabelAlign="Right" LabelWidth="115" MsgTarget="Side" />
                    <Items>
                        <ext:GridPanel runat="server" ID="GEMPLEADO" Title="LISTA DE EMPLEADOS." Icon="User" Height="470" Width="900" Frame="true" Padding="2">
                                    <TopBar>
                                        <ext:Toolbar runat="server">
                                            <Items>
                                                <ext:TextField ID="TFEMPLEADO" runat="server" EmptyText="Identificación o  nombre para buscar" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                    <Listeners>
                                                        <KeyPress Handler="findUser(App.GEMPLEADO.store, App.TFEMPLEADO.getValue(), Ext.EventObject);" Buffer="200" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Presionar enter para buscar" />
                                                    </ToolTips>
                                                </ext:TextField>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Store>
                                        <ext:Store ID="SEMPLEADO" runat="server">
                                            <Model>
                                                <ext:Model runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="MCODIGO" />
                                                        <ext:ModelField Name="MIDENTIFICACION" />
                                                        <ext:ModelField Name="MNOMBRE" />
                                                        <ext:ModelField Name="MTIPO"  />
                                                        <ext:ModelField Name="MDPRIMARIO" />
                                                        <ext:ModelField Name="MDSECUNDARIO" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn runat="server" />
                                            <ext:Column runat="server" ID="MIDENTIFICACION" Text="IDENTIFICACIÓN" DataIndex="MIDENTIFICACION" Width="130" />
                                            <ext:Column runat="server" ID="MNOMBRE" Text="NOMBRE" DataIndex="MNOMBRE" Flex="3" />
                                            <ext:Column runat="server" ID="MTIPO" Text="TIPO" DataIndex="MTIPO" Flex="2"  />
                                            <ext:CommandColumn runat="server" Width="110" Text="FOTO/HUELLA">
                                                <Commands>
                                                    <ext:CommandSpacer Width="10" />
                                                    <ext:GridCommand Icon="Webcam" CommandName="webcam">
                                                        <ToolTip Text="Capturar Foto del Empleado" />
                                                    </ext:GridCommand>
                                                    <ext:CommandSpacer Width="15" />
                                                    <ext:GridCommand IconCls="shortcut-icon-footprint icon-footprint" CommandName="footprint1">
                                                        <ToolTip Text="Inscripción huella dactilar principal." />
                                                    </ext:GridCommand>
                                                  <ext:CommandSpacer Width="5" />
                                                    <ext:GridCommand IconCls="shortcut-icon-footprint icon-footprint" CommandName="footprint2">
                                                        <ToolTip Text="Inscripción de huella dactilar secundaria" />
                                                    </ext:GridCommand>
                                                </Commands>
                                                <Listeners>
                                                      <Command Fn="prepareCommand" />     
                                                </Listeners>
                                            </ext:CommandColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <BottomBar>
                                        <ext:PagingToolbar runat="server"  />
                                    </BottomBar>
                                   
                                </ext:GridPanel>
                    </Items>
                </ext:FormPanel>
             </Items>
        </ext:Viewport>
    </form>
</body>
</html>
