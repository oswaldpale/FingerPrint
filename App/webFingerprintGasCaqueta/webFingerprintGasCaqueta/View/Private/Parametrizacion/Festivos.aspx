<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Festivos.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.Festivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DIAS FESTIVOS</title>
     <script type="text/javascript">
        
        var ClickCommand = function (grid, command, record, row) {
            if (command == 'del') {
                Ext.Msg.confirm('Confirmación', 'Estas seguro de eliminar el Festivos?',
                function (btn) {
                    if (btn === 'yes') {
                        if (parametro.eliminarFestivo(record.data.IDENTIFICACION)) {
                            Ext.Msg.notify("Notificación", "Eliminado exitosamente.");
                            parametro.consultarHorarios();
                        } else {
                            Ext.Msg.Notify("Notificación","Ha ocurrido un error!..");
                        }
                    }
                });
            }
        }
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
                            <ext:GridPanel ID="GPFESTIVOS" runat="server" >
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:TextField ID="TFDIAS" runat="server" EmptyText="Fecha o Nombre para filtrar" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                <Listeners>
                                                    <KeyPress Handler="findUser(App.GPFESTIVO.store, App.TFDIAS.getValue(), Ext.EventObject);"/>
                                                </Listeners>
                                            </ext:TextField>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store ID="SFESTIVOS" runat="server">
                                        <Model>
                                            <ext:Model runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="IDENTIFICACION" />
                                                    <ext:ModelField Name="FECHA" />
                                                    <ext:ModelField Name="NOMBREFESTIVO" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                                                                        
                                    </ext:Store>
                                </Store>
                                <ColumnModel>
                                    <Columns>
                                        <ext:RowNumbererColumn runat="server" />
                                        <ext:Column ColumnID="CFECHA" runat="server" DataIndex="FECHA" Header="FECHA" Flex="2">
                                            <Editor>
                                                <ext:TextField runat="server" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column ColumnID="CNOMBREFESTIVO" runat="server" DataIndex="NOMBREFESTIVO" Header="NOMBRE" Flex="3">
                                            <Editor>
                                                <ext:TextField runat="server" />
                                            </Editor>
                                        </ext:Column> 
                                        <ext:CommandColumn runat="server" Width="60">
                                            <Commands>
                                                <ext:GridCommand Icon="Delete" CommandName="del">
                                                    <ToolTip Text="Eliminar Festivos" />
                                                </ext:GridCommand>
                                            </Commands>
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
                                    <ext:Button runat="server" Icon="Add" Text="NUEVO FESTIVO">
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

            <ext:Window ID="WREGISTRO" runat="server" Draggable="false" Resizable="true" Height="150" Width="280" Icon="Calendar" Title="Nueva Festivo" Hidden="true" Modal="true">
                <Items>
                    <ext:FormPanel runat="server" ID="FREGISTRO" Padding="15" Layout="ColumnLayout">
                    <Items>
                        <ext:Panel runat="server"  Region="East">
                        <Items>
                            <ext:DateField ID="TFECHA" FieldLabel="Fecha:" LabelWidth="60" runat="server" Flex="1" IsRemoteValidation="true"  AllowBlank="false" F>
                                 <RemoteValidation OnValidation = "consultarFechaExistente" />
                            </ext:DateField>
                            <ext:TextField ID="TNOMBRE" FieldLabel="Nombre:" LabelWidth="60" runat="server" Flex="1"  AllowBlank="false" />
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
                                    <Click Handler="if(#{FREGISTRO}.getForm().isValid()) {parametro.registrarFestivo();}else{ return false;}  " />
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
