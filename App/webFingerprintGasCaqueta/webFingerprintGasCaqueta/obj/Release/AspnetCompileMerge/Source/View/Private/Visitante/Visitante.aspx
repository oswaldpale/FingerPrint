<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visitante.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Visitante.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../../Content/css/Style.css" rel="stylesheet" />
    <title>VISITANTE</title>
    
    <script type="text/javascript">
        var Jidentificacion, Jdedo;
        var GLOBALCAMARA;
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

        var modificarVisitante = function () {
            if (App.direct.modificarVisistante()) {
                App.direct.ConsultarVisitantes();
                App.TIDENTIFICACION.setReadOnly(false);
                App.FREGISTRO.reset();
                App.IMPERFIL.setImageUrl('');
                Ext.Msg.notify("Notificación", "Actualización realizada");
            } else {
                Ext.Msg.notify("Notificación", "Ha ocurrido un error.");
            }
        }

     
        var registrarVisitante = function () {
           

                if(parametro.registrarVisitante()){
                    App.direct.ConsultarVisitantes();
                    App.BGUARDAR.hide();
                    App.BFOTO.setDisabled();
                    App.BACTUALIZAR.show();
                    Ext.Msg.notify('Notificación', 'Registrado Exitosamente.');
                
                }else{
                    Ext.Msg.notify('Notificación', 'Ha ocurrido un error.');
                }
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
                    <ext:FormPanel ID="FPRINCIPAL" runat="server" Region="Center" Width="960" Height="700" TitleAlign="Center" BodyPadding="10" Icon="User" Title="VISITANTE" UI="Info" Border="true">
                        <Items>
                            <ext:FormPanel runat="server" ID="FREGISTRO" Padding="15" Layout="ColumnLayout">
                                <Items>
                                    <ext:Panel runat="server" Region="Center" Width="710" Height="200" Layout="HBoxLayout" Title="INFORMACIÓN" >
                                        <Items>

                                            <ext:Panel runat="server" Width="360" Padding="10">
                                                <Items>
                                                    <ext:ToolbarSpacer runat="server" Height="10" />
                                                    <ext:TextField ID="TIDENTIFICACION" FieldLabel="IDENTIFICACIÓN" LabelWidth="140" runat="server" Width="330" AllowBlank="false" MaskRe="[0-9]" TabIndex="1" Name="IDENTIFICACION" />
                                                    <ext:TextField ID="TAPELLIDO1" FieldLabel="PRIMER APELLIDO" LabelWidth="140" runat="server" Width="330" AllowBlank="false" TabIndex="3" Name="APELLIDO1" />
                                                    <ext:TextField ID="TDIRECCIÓN" FieldLabel="DIRECCIÓN" LabelWidth="140" runat="server" Width="330" AllowBlank="false" TabIndex="5" Name="DIRECCION" />

                                                </Items>
                                            </ext:Panel>
                                            <ext:Panel runat="server" Width="360" Padding="10">
                                                <Items>
                                                    <ext:ToolbarSpacer runat="server" Height="10" />
                                                    <ext:TextField ID="TNOMBRE" FieldLabel="NOMBRE" LabelWidth="140" runat="server" Width="330" AllowBlank="false" TabIndex="2" Name="NOMBREUSUARIO" />
                                                    <ext:TextField ID="TAPELLIDO2" FieldLabel="SEGUNDO APELLIDO" LabelWidth="140" runat="server" Width="330" AllowBlank="false" TabIndex="4" Name="APELLIDO2"  />
                                                    <ext:TextField ID="TTELEFONO" FieldLabel="TELEFONO" LabelWidth="140" runat="server" Width="330" AllowBlank="false" MaskRe="[0-9]" TabIndex="6" Name="TELEFONO" />
                                                </Items>
                                            </ext:Panel>

                                        </Items>
                                        <Buttons>
                                            
                                            <ext:Button runat="server" ID="BNUEVO" Text="NUEVO" Icon="UserAdd" Scale="Small" UI="Default">
                                                <Listeners>
                                                    <Click Handler="App.FREGISTRO.reset();App.BGUARDAR.show();App.BACTUALIZAR.hide();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="BACTUALIZAR" Text="ACTUALIZAR" Icon="Reload"  Scale="Small" Hidden="true" UI="Success">
                                                <Listeners>
                                                    <Click Fn = "modificarVisitante" />
                                                </Listeners>
                                            </ext:Button>

                                            <ext:Button runat="server" ID="BGUARDAR" Text="GUARDAR" Icon="Disk" Scale="Small" UI="Info" >
                                                <Listeners>
                                                    <Click Fn="registrarVisitante" />
                                                </Listeners>
                                            </ext:Button>
                                        </Buttons>
                                    </ext:Panel>
                                    <ext:Panel runat="server" Width="170" MarginSpec="0 0 0 20" >
                                        <Items>
                                            <ext:Panel runat="server">
                                                <Items>
                                                    <ext:Image ID="IMPERFIL" runat="server" Width="170px" Height="175" />
                                                    <ext:Button ID="BFOTO" runat="server" Width="170px" Text="CAMBIAR FOTO" Disabled="true">
                                                        <Listeners>
                                                             <Click Handler="App.direct.AbrirCamaraWeb(); " />
                                                           
                                                        </Listeners>
                                                    </ext:Button>
                                                </Items>
                                            </ext:Panel>
                                        </Items>

                                    </ext:Panel>
                                </Items>
                                <Listeners>
                                    <ValidityChange Handler="#{BGUARDAR}.setDisabled(!valid);" />
                                </Listeners>

                            </ext:FormPanel>
                            <ext:Panel ID="PPRESENTACION" runat="server"  Height="400" UI="Success" Border="true" Region="Center">
                                <Items>
                                    <ext:GridPanel ID="GPVISITANTE" runat="server" Height="380" >
                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:TextField ID="TFVISITANTE" runat="server" EmptyText="Identificación, nombre o nombre para filtrar" Width="442" EnableKeyEvents="true" Icon="Magnifier">
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
                                                            <ext:ModelField Name="NOMBREUSUARIO" />
                                                            <ext:ModelField Name="APELLIDO1" />
                                                            <ext:ModelField Name="APELLIDO2" />
                                                            <ext:ModelField Name="TELEFONO" />
                                                            <ext:ModelField Name="DIRECCION" />
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
                                                <ext:Column ID="CIDENTIFICACION" runat="server" DataIndex="IDENTIFICACION" Header="IDENTIFICACION" Width="150" />
                                                <ext:Column ColumnID="CNOMBRE" runat="server" DataIndex="NOMBRE" Header="NOMBRE" Flex="2" />
                                                <ext:Column ColumnID="CTELEFONO" runat="server" DataIndex="TELEFONO" Header="TELEFONO" Flex="1" />
                                                <ext:Column ColumnID="CDIRECCION" runat="server" DataIndex="DIRECCION" Header="DIRECCIÓN" Flex="2" />
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
                                       <SelectionModel>
                                            <ext:RowSelectionModel ID="RSELECT" runat="server" Mode="Simple" />
                                        </SelectionModel>
                                          <Listeners>
                                            <Select Handler="var d=record.data; f=#{FREGISTRO}.getForm(); f.setValues(d);  App.BACTUALIZAR.show();App.BFOTO.setDisabled();App.BGUARDAR.hide();App.TIDENTIFICACION.setReadOnly(true);App.direct.cargarFotoVisitante(record.data.IDENTIFICACION);" />
                                        </Listeners>
                                        <BottomBar>
                                            <ext:PagingToolbar runat="server" />
                                        </BottomBar>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:FormPanel>
                </Items>
            </ext:Viewport>
        </div>

    </form>
</body>
</html>
