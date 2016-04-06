<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Horario.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.Horario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        
        var ClickCommand = function (grid, command, record, row) {
            if (command == 'del') {
                Ext.Msg.confirm('Confirmación', 'Estas seguro de eliminar el Horario?',
                function (btn) {
                    if (btn === 'yes') {
                        if (App.direct.eliminarHorario(record.data.ID)) {
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
      <ext:ResourceManager ID="ResourceManager1" runat="server" Locale="es-CO" />
      <form id="Form1" runat="server">
        <div>
            <ext:Viewport ID="VPPRESENTACION" runat="server" Layout="border">
                <Items>
                    <ext:Panel ID="PPRESENTACION" runat="server" Layout="Fit" Region="Center" Padding="5" Frame="true" Border="true">
                        <Items>
                            <ext:GridPanel ID="GPHORARIO" runat="server" AutoDataBind="true" Frame="true" Border="true" >
                                <TopBar>
                                    <ext:Toolbar ID="Toolbar1" runat="server">
                                        <Items>
                                            <ext:TextField ID="TFHORARIO" runat="server" EmptyText="Nombre para buscar" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                <Listeners>
                                                    <KeyPress Handler="findUser(App.GPHORARIO.store, App.TFHORARIO.getValue(), Ext.EventObject);"/>
                                                </Listeners>
                                            </ext:TextField>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store ID="SHORARIO" runat="server">
                                        <Model>
                                            <ext:Model ID="Model1" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="ID" />
                                                    <ext:ModelField Name="NOMBREHORARARIO" />
                                                    <ext:ModelField Name="HORA_INICIO" />
                                                    <ext:ModelField Name="HORA_FIN" />
                                                    <ext:ModelField Name="TIEMPO_TARDE" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                                                                        
                                    </ext:Store>
                                </Store>
                                <ColumnModel>
                                    <Columns>
                                        <ext:RowNumbererColumn ID="RowNumbererColumn1" runat="server" />
                                        <ext:Column ID="Column1" ColumnID="CNOMBREHORARIO" runat="server" DataIndex="NOMBREHORARARIO" Header="NOMBRE" Flex="3">
                                            <Editor>
                                                <ext:TextField ID="TextField1" runat="server" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column ID="Column2" ColumnID="CHORA_INICIO" runat="server" DataIndex="HORA_INICIO" Header="HORA INICIO" Flex="1">
                                            <Editor>
                                                <ext:TextField ID="TextField2" runat="server" />
                                            </Editor>
                                        </ext:Column>
                                         <ext:Column ID="Column3" ColumnID="CHORA_FIN" runat="server" DataIndex="HORA_FIN" Header="HORA FIN" Flex="1">
                                            <Editor>
                                                <ext:TextField ID="TextField3" runat="server" />
                                            </Editor>
                                        </ext:Column>  
                                         <ext:Column ID="Column4" ColumnID="CTIEMPO_TARDE" runat="server" DataIndex="TIEMPO_TARDE" Header="TIEMPO TARDE(min)" Width="180">
                                            <Editor>
                                                <ext:TextField ID="TextField4" runat="server" />
                                            </Editor>
                                         </ext:Column>
                                        <ext:CommandColumn runat="server" Width="30">
                                            <Commands>
                                                <ext:GridCommand Icon="Delete" CommandName="del">
                                                    <ToolTip Text="Eliminar Horario" />
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
                            <ext:Toolbar ID="Toolbar2" runat="server">
                                <Items>
                                    <ext:ToolbarFill />
                                    <ext:Button ID="Button1" runat="server" Icon="Add" Text="NUEVO HORARIO">
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

            <ext:Window ID="WREGISTRO" runat="server" Draggable="false" Resizable="true"  Width="300" Icon="Calendar" Title="Nueva Horario" Hidden="true" Modal="true">
                <Items>
                    <ext:FormPanel runat="server" ID="FREGISTRO" Padding="5" Layout="ColumnLayout">
                    <Items>
                        <ext:Panel ID="Panel1" runat="server"  DefaultWidth="280">
                        <Items>
                            <ext:TextField ID="TNOMBRE" FieldLabel="Nombre:"  runat="server" Flex="1"  AllowBlank="false" />
                            <ext:TimeField   ID="THINICIO"  runat="server" FieldLabel="Hora Inicio:"  Increment="30"  Format="hh:mm tt"   />
                            <ext:TimeField   ID="THFIN"  runat="server" FieldLabel="Hora Fin:"  Increment="30"  Format="hh:mm tt"   />
                            <ext:TextField ID="TTIEMPOTARDE" FieldLabel="Tiempo Tarde(min):"  MaskRe="[0-9]" runat="server" Flex="1"  AllowBlank="false" />
                        </Items>
                        </ext:Panel>
                        </Items>
                        <Listeners>
                            <ValidityChange Handler="#{BGUARDAR}.setDisabled(!valid);" />
                        </Listeners>
                    </ext:FormPanel>
                </Items>
                <BottomBar>
                    <ext:Toolbar ID="Toolbar3" runat="server">
                        <Items>
                            <ext:ToolbarFill />
                               <ext:Button ID="BCANCELAR" runat="server"  Text="Cancelar" >
                                <Listeners>
                                    <Click Handler="App.FREGISTRO.reset();App.WREGISTRO.hide();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button runat="server" ID="BGUARDAR" Icon="Add" Text="Guardar" FormBind="true">
                                <Listeners>
                                    <Click Handler="if(#{FREGISTRO}.getForm().isValid()) {App.direct.registrarHorario(App.THINICIO.getValue(),App.THFIN.getValue());}else{ return false;}  " />
                                </Listeners>
                            </ext:Button>

                        </Items>
                    </ext:Toolbar>
                </BottomBar>
                <Listeners>
                    <BeforeHide Handler="App.FREGISTRO.reset();parametro.consultarHorarios();" />
                </Listeners>
            </ext:Window>
        </div>

    </form>
</body>
</html>

