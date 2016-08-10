<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaTrabajo.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.AreaTrabajo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DEPENDENCIA</title>

     <style type="text/css">
      /**/
      #unlicensed{
	        display: none !important;
      }
	 </style>
     <script type="text/javascript">
        
        var ClickCommand = function (grid, command, record, row) {
            if (command == 'del') {
                Ext.Msg.confirm('Confirmación', 'Estas seguro de eliminar esta dependencia?',
                function (btn) {
                    if (btn === 'yes') {
                        if (App.direct.eliminarArea(record.data.CODIGO)) {
                            App.direct.consultarArea();
                            Ext.Msg.notify("Notificación", "Eliminado exitosamente.");
                           
                        } else {
                            Ext.Msg.notify("Notificación","Ha ocurrido un error!..");
                        }
                    }
                });
            }
        }

        var Edit = function (editor,e) {
            //App.direct.modificarArea(e.record.data.CODIGO, e.record.data.AREA, e.record.data.EXT);
            Ext.Msg.notify("Notificación", "Datos Actualizados!.");
        };

        var validateSave = function () {
            var plugin = this.editingPlugin;
            if (this.getForm().isValid()) { // local validation
               
                App.direct.modificarArea(plugin.context.record.data.CODIGO, this.getValues(false, false), {
                    success: function (result) {
                        if (!result.valid) {
                                             
                            return;
                        }
                        Ext.Msg.notify("Notificación", "Datos Actualizados!.");
                        plugin.completeEdit();
                        App.GPAREA.getStore().commitChanges();
                    }
                });
            }
        };

        var findArea = function (Store, texto, e) {
            if (e.getKey() == 13) {
                var store = Store,
                    text = texto;
                store.clearFilter();
                if (Ext.isEmpty(text, false)) {
                    return;
                }
                var re = new RegExp(".*" + text + ".*", "i");
                store.filterBy(function (node) {
                    var RESUMEN = node.data.AREA + node.data.EXT + node.data.CODIGO;
                    var a = re.test(RESUMEN);
                    return a;
                });
            }
        };
    </script>
</head>
<body>
      <ext:ResourceManager ID="ResourceManager1" runat="server" />
     <form runat="server">
        <div>
            <ext:Viewport ID="VPPRESENTACION" runat="server" Layout="border">
                <Items>
                    <ext:Panel ID="PPRESENTACION" runat="server" Layout="Fit" Region="Center" Padding="5">
                        <Items>
                            <ext:GridPanel ID="GPAREA" runat="server" >
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:TextField ID="TFDIAS" runat="server" EmptyText="escriba la dependencia o extensión para filtrar" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                <Listeners>
                                                    <KeyPress Handler="findArea(App.GPAREA.store, App.TFDIAS.getValue(), Ext.EventObject);"/>
                                                </Listeners>
                                            </ext:TextField>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store ID="SAREA" runat="server">
                                        <Model>
                                            <ext:Model runat="server" IDProperty="CODIGO">
                                                <Fields>
                                                    <ext:ModelField Name="CODIGO" />
                                                    <ext:ModelField Name="AREA" />
                                                    <ext:ModelField Name="EXT" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                                                                        
                                    </ext:Store>
                                </Store>
                                <ColumnModel>
                                    <Columns>
                                        <ext:RowNumbererColumn runat="server" />
                                        <ext:Column ColumnID="CCODIGO" runat="server" DataIndex="CODIGO" Header="CODIGO" Flex="2" />
                                        <ext:Column ColumnID="CAREA" runat="server" DataIndex="AREA" Header="DEPENDENCIA" Flex="3">
                                            <Editor>
                                                <ext:TextField runat="server" />
                                            </Editor>
                                        </ext:Column> 
                                        <ext:Column ColumnID="CEXT" runat="server" DataIndex="EXT" Header="EXTENSIÓN" Flex="3">
                                            <Editor>
                                                <ext:TextField runat="server" />
                                            </Editor>
                                        </ext:Column> 
                                        <ext:CommandColumn runat="server" Width="60">
                                            <Commands>
                                                <ext:GridCommand Icon="Delete" CommandName="del">
                                                    <ToolTip Text="Eliminar Dependencia" />
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Fn="ClickCommand" />
                                            </Listeners>
                                        </ext:CommandColumn>                                          
                                    </Columns>
                                </ColumnModel>
                             
                                <Plugins>
                                    <ext:RowEditing runat="server" ClicksToMoveEditor="1" AutoCancel="false" SaveHandler="validateSave" />
                                </Plugins>
                            </ext:GridPanel>
                        </Items>
                        <BottomBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Icon="Add" Text="NUEVO DEPENDENCIA">
                                        <Listeners>
                                            <Click Handler="App.WREGISTRO.show();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:Panel>
                </Items>
            </ext:Viewport>

            <ext:Window ID="WREGISTRO" runat="server" Draggable="false" Resizable="true" Height="190" Width="300" Icon="MapAdd" Title="Nueva Dependencia" Hidden="true" Modal="true">
                <Items>
                    <ext:FormPanel runat="server" ID="FREGISTRO" Padding="15" Layout="ColumnLayout">
                    <Items>
                        <ext:Panel runat="server"  Region="East">
                        <Items>
                            <ext:TextField ID="TCODIGO" FieldLabel="Codigo:" LabelWidth="90" runat="server" Flex="1"  AllowBlank="false" MaskRe="[0-9]" />
                            <ext:TextField ID="TAREA" FieldLabel="Dependencia:" LabelWidth="90" runat="server" Flex="1"  AllowBlank="false" />
                            <ext:TextField ID="TEXT" FieldLabel="Extensión:" LabelWidth="90" runat="server" Flex="1"  AllowBlank="false" />
                        </Items>
                        </ext:Panel>
                        </Items>
                        <Listeners>
                            <ValidityChange Handler="#{BGUARDAR}.setDisabled(!valid);" />
                        </Listeners>
                    </ext:FormPanel>
                </Items>
                <BottomBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:ToolbarFill />
                               <ext:Button ID="BCANCELAR" runat="server"  Text="Cancelar" >
                                <Listeners>
                                    <Click Handler="App.FREGISTRO.reset();App.WREGISTRO.hide();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button runat="server" ID="BGUARDAR" Icon="Add" Text="Guardar" FormBind="true">
                                <Listeners>
                                    <Click Handler="if(#{FREGISTRO}.getForm().isValid()) {
                                                       if(App.direct.registrarArea()){
                                                            App.direct.consultarArea();
                                                            App.WREGISTRO.hide();
                                                            App.FREGISTRO.reset();
                                                            Ext.Msg.notify('Notificación', 'Registrado Exitosamente.');
                                                       }else{
                                                          Ext.Msg.notify('Notificación', 'Ha ocurrido un error.');
                                                       }
                                                    }else{ return false;}  " />
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

