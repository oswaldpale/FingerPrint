<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visitante.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Visitante.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../../Content/css/Style.css" rel="stylesheet" />
    <title></title>
    <script type="text/javascript">
        var Jidentificacion, Jdedo;
        var prepareCommand = function (grid, toolbar, rowIndex, record) {
            var firstButton = toolbar.items.get(0);
            var firstButton2 = toolbar.items.get(1);

            if (record.data.EXISTHUEPRIMARY == 'true') {
                firstButton.setIconCls('shortcut-icon-footprintregister icon-footprintregister');
            }
            if (record.data.EXISTHUESECOND == 'true') {
                firstButton2.setIconCls('shortcut-icon-footprintregister icon-footprintregister');
            }
        };

        function AbrirVentanaIncripcionHuella(record) {
            parametro.AbrirVentanaIncripcionHuella(record.get("IDENTIFICACION"), 'Primario');
        }

        var ClickCommand = function (grid, command, record, row) {
            Jidentificacion = record.get("IDENTIFICACION");

            if (command == 'fingerprint1') {
                Jdedo = 'Primario'
                if (record.get("EXISTHUEPRIMARY") == 'true') {

                    Ext.Msg.show({
                        title: 'Notificación',
                        msg: '¿Desea reemplazar la huella existente?',
                        buttons: Ext.Msg.YESNO,
                        fn: ConfirmResult,
                        animEl: 'elId',
                        icon: Ext.MessageBox.INFO
                    });
                } else {
                    AbrirVentanaIncripcionHuella(record)
                }
            }

            if (command == 'fingerprint2') {
                Jdedo = 'Secundario'
                if (record.get("EXISTHUESECOND") == 'true') {

                    Ext.Msg.show({
                        title: 'Notificación',
                        msg: '¿Desea reemplazar la huella existente?',
                        buttons: Ext.Msg.YESNO,
                        fn: ConfirmResult,
                        animEl: 'elId',
                        icon: Ext.MessageBox.INFO
                    });
                } else {
                    AbrirVentanaIncripcionHuella(record)
                }
            }
        };
        function ConfirmResult(btn) {
            if (btn == 'yes') {
                parametro.EliminarHuella(Jidentificacion, Jdedo, {
                    success: function (result) {
                        parametro.AbrirVentanaIncripcionHuella(Jidentificacion, Jdedo);
                    }, failure: function (errorMsg) {
                        Ext.net.Notification.show({
                            html: 'Ha ocurrido un error.!', title: 'Notificación'
                        });
                    }
                });
            }
        }

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
                    var RESUMEN = node.data.IDENTIFICACION + node.data.NOMBRE;
                    var a = re.test(RESUMEN);
                    return a;
                });
            }
        };

    </script>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp" />
    <form runat="server">
        <div>
            <ext:Viewport ID="VPPRESENTACION" runat="server">
                <LayoutConfig>
                    <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
                </LayoutConfig>
                <Items>
                    <ext:FormPanel ID="FPRINCIPAL" runat="server" Width="900" Height="650" TitleAlign="Center" BodyPadding="10" Icon="User" Title="Visitante" UI="Info" Border="true">
                        <Items>
                            <ext:FormPanel runat="server" ID="FREGISTRO" Padding="15" Layout="ColumnLayout">
                                <Items>
                                    <ext:Panel runat="server" Region="East" Width="640">
                                        <Items>
                                            <ext:TextField ID="TIDENTIFICACION" FieldLabel="Identificación" runat="server" Width="300" AllowBlank="false" MaskRe="[0-9]" IsRemoteValidation="true">
                                                <RemoteValidation OnValidation="consultarSiExisteVisitante" />
                                            </ext:TextField>
                                            <ext:TextField ID="TNOMBRE" FieldLabel="Nombre" runat="server" Width="300" AllowBlank="false" />
                                            <ext:TextField ID="TAPELLIDO1" FieldLabel="Primer Apellido" runat="server" Width="300" AllowBlank="false" />
                                            <ext:TextField ID="TAPELLIDO2" FieldLabel="Seg Apellido" runat="server" Width="300" AllowBlank="false" />
                                            <ext:TextArea ID="TOBSERVACIÓN" FieldLabel="Observación" runat="server" Width="300" Height="50" AllowBlank="true" />
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel runat="server" Width="180" MarginSpec="0 0 0 10" Frame="true">
                                        <Items>
                                            <ext:Panel runat="server">
                                                <Items>
                                                    <ext:Image ID="IMPERFIL" runat="server" Width="160px" Height="180" />
                                                    <ext:Button ID="BFOTO" runat="server" Width="160px" Text="Cambiar Foto" />
                                                </Items>
                                            </ext:Panel>
                                        </Items>
                                     
                                    </ext:Panel>
                                </Items>
                                <Listeners>
                                    <ValidityChange Handler="#{BGUARDAR}.setDisabled(!valid);" />
                                </Listeners>
                                <Buttons>
                                    <ext:Button runat="server" ID="BNUEVO" Text="NUEVO" Icon="UserAdd" Scale="Small" UI="Default" />

                                    <ext:Button runat="server" ID="Button1" Text="ACTUALIZAR" Icon="Reload" Scale="Small" Disabled="true" UI="Success"
                                        Hidden="false">
                                        <Listeners>
                                        </Listeners>
                                    </ext:Button>

                                    <ext:Button runat="server" ID="Button2" Text="GUARDAR" Icon="Disk" Scale="Small" UI="Info">
                                        <Listeners>
                                        </Listeners>
                                    </ext:Button>
                                </Buttons>
                            </ext:FormPanel>
                            <ext:Panel ID="PPRESENTACION" runat="server" Width="1000" Height="650" Region="Center" Padding="5">
                                <Items>
                                    <ext:GridPanel ID="GPVISITANTE" runat="server">
                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:TextField ID="TFVISITANTE" runat="server" EmptyText="Identificación o  nombre para buscar" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                        <Listeners>
                                                            <KeyPress Handler="findUser(App.GPVISITANTE.store, App.TFVISITANTE.getValue(), Ext.EventObject);" />
                                                        </Listeners>
                                                    </ext:TextField>
                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>
                                        <Store>
                                            <ext:Store ID="SVISITANTE" runat="server">
                                                <Model>
                                                    <ext:Model runat="server">
                                                        <Fields>
                                                            <ext:ModelField Name="IDENTIFICACION" />
                                                            <ext:ModelField Name="NOMBRE" />
                                                            <ext:ModelField Name="OBSERVACION" />
                                                            <ext:ModelField Name="EXISTHUEPRIMARY" />
                                                            <ext:ModelField Name="EXISTHUESECOND" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>

                                            </ext:Store>
                                        </Store>
                                        <ColumnModel>
                                            <Columns>
                                                <ext:RowNumbererColumn runat="server" />
                                                <ext:Column ID="CIDENTIFICACION" runat="server" DataIndex="IDENTIFICACION" Header="IDENTIFICACION" Width="150">
                                                </ext:Column>
                                                <ext:Column ColumnID="CNOMBRE" runat="server" DataIndex="NOMBRE" Header="NOMBRE" Flex="3">
                                                    <Editor>
                                                        <ext:TextField runat="server" />
                                                    </Editor>
                                                </ext:Column>
                                                <ext:Column ColumnID="COBSERVACION" runat="server" DataIndex="OBSERVACION" Header="OBSERVACIÓN" Flex="3">
                                                    <Editor>
                                                        <ext:TextField runat="server" />
                                                    </Editor>
                                                </ext:Column>
                                                <ext:CommandColumn runat="server" Width="70" Text="HUELLA">
                                                    <Commands>
                                                        <ext:GridCommand CommandName="fingerprint1" IconCls="shortcut-icon-footprint icon-footprint">
                                                            <ToolTip Text="Registrar huella primaria" />
                                                        </ext:GridCommand>
                                                        <ext:GridCommand CommandName="fingerprint2" IconCls="shortcut-icon-footprint icon-footprint">
                                                            <ToolTip Text="Registrar huella secundaria" />
                                                        </ext:GridCommand>

                                                    </Commands>
                                                    <PrepareToolbar Fn="prepareCommand" />
                                                    <Listeners>
                                                        <Command Fn="ClickCommand" />
                                                    </Listeners>
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>

                                    </ext:GridPanel>
                                </Items>
                                <BottomBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:ToolbarFill />
                                            <ext:Button runat="server" Icon="Add" Text="NUEVO VISITANTE">
                                                <Listeners>
                                                    <Click Handler="App.WREGISTRO.show();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </BottomBar>
                            </ext:Panel>
                        </Items>
                    </ext:FormPanel>

                </Items>
            </ext:Viewport>

            <ext:Window ID="WREGISTRO" runat="server" Draggable="false" Resizable="true" Height="290" Width="600" Icon="UserB" Title="Nueva Visitante" Hidden="true" Modal="true">
                <Items>
                </Items>
                <BottomBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:ToolbarFill />
                            <ext:Button ID="BCANCELAR" runat="server" Text="Cancelar">
                                <Listeners>
                                    <Click Handler="App.FREGISTRO.reset();App.WREGISTRO.hide();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button runat="server" ID="BGUARDAR" Icon="Add" Text="Guardar" FormBind="true">
                                <Listeners>
                                    <Click Handler="if(#{FREGISTRO}.getForm().isValid()) {parametro.registrarVisitante();}else{ return false;}  " />
                                </Listeners>
                            </ext:Button>

                        </Items>
                    </ext:Toolbar>
                </BottomBar>
                <Listeners>
                    <BeforeHide Handler="App.FREGISTRO.reset();" />
                </Listeners>
            </ext:Window>
        </div>

    </form>
</body>
</html>
