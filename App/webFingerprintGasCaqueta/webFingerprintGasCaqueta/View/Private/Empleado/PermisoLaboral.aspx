<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermisoLaboral.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Empleado.PermisoLaboral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" Locale="es-CO" />
    <form id="Form1" runat="server">
        <div>
            <ext:Viewport ID="VPPRESENTACION" runat="server" Layout="border">
                <Items>
                    <ext:Panel ID="PPRESENTACION" runat="server" Layout="Fit" Region="Center" Padding="5" Frame="true" Border="true">
                        <Items>
                            <ext:GridPanel ID="GPERMISO" runat="server" AutoDataBind="true" Frame="true" Border="true">
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:TextField ID="TFPERMISO" runat="server" EmptyText="Nombre para buscar" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                <Listeners>
                                                    <KeyPress Handler="findUser(App.GPERMISO.store, App.TFPERMISO.getValue(), Ext.EventObject);" />
                                                </Listeners>
                                            </ext:TextField>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store ID="SPERMISO" runat="server">
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
                                        <ext:RowNumbererColumn runat="server" />
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
                                        <ext:CommandColumn ID="CommandColumn1" runat="server" Width="30">
                                            <Commands>
                                                <ext:GridCommand Icon="Delete" CommandName="del">
                                                    <ToolTip Text="Eliminar Horario" />
                                                </ext:GridCommand>
                                            </Commands>
                                            <%-- <Listeners>
                                                <Command Fn="ClickCommand" />
                                            </Listeners>--%>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>

                            </ext:GridPanel>
                        </Items>
                        <BottomBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ToolbarFill />
                                    <ext:Button ID="BREGISTRO" runat="server" Icon="Add" Text="NUEVO PERMISO">
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

            <ext:Window ID="WREGISTRO" runat="server" Draggable="false" Resizable="true" Width="580"  Icon="UserTick" Title="Nueva Permiso" Hidden="true" Modal="true">
                <Items>
                    <ext:FormPanel runat="server" ID="FREGISTRO" Padding="5" >
                        <Items>
                            <ext:Panel ID="PREGISTRO" runat="server">
                                <Items>
                                    <ext:Container runat="server" Padding="10">
                                        <Items>
                                            <ext:TextField ID="TFECHASOLICITUD" FieldLabel="FECHA SOLICITUD" LabelWidth="120" Width="270" ReadOnly="true" runat="server" Flex="1" AllowBlank="false" />
                                            <ext:TextField ID="TEMPLEADO" FieldLabel="EMPLEADO <font color ='red'>*</font> " MarginSpec="10 0 0 0" runat="server" LabelWidth="120" Width="550" Flex="1" AllowBlank="false" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container runat="server" ID="COPCION" Layout="HBoxLayout" >
                                        <Items>
                                            <ext:CycleButton ID="BTIPOHORA" runat="server" Padding="5" ShowText="true" Width="120" MarginSpec="5 0 5 10 ">
                                                <Menu>
                                                    <ext:Menu ID="MTIPOHORA" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MDIA" runat="server" Text="DIA">
                                                                <Listeners>
                                                                    <Click Handler="App.FHORA.hide();App.DFECHAINI.allowBlank=false;App.DFECHAFIN.allowBlank=false;App.FDIA.show();App.DFECHAHORA.hide();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MHORA" runat="server" Text="HORA">
                                                                <Listeners>
                                                                    <Click Handler="App.FHORA.show();App.THINICIO.allowBlank=false;App.THFIN.allowBlank=false;App.FDIA.hide();App.DFECHAHORA.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:CycleButton>
                                            <ext:DateField runat="server" ID="DFECHAHORA" PaddingSpec="5" EmptyText="FECHA PERMISO" Width="145" MarginSpec="5 0 5 5" />
                                            <ext:CycleButton ID="CESTADO" runat="server" Padding="5" ShowText="true" Width="130" MarginSpec="5 0 5 5 " UI="Info">
                                                <Menu>
                                                    <ext:Menu runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem1" runat="server" Text="ACTIVO" />
                                                            <ext:MenuItem ID="MenuItem2" runat="server" Text="INACTIVO" />
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:CycleButton>
                                        </Items>
                                    </ext:Container>

                                    <ext:FormPanel runat="server" ID="FHORA" Layout="HBoxLayout" Height="50" Padding="10">
                                        <Items>
                                            <ext:TimeField ID="THINICIO" runat="server" FieldLabel="HORA INICIO:" LabelWidth="120" Width="270" MarginSpec="5 0 5 5 " Increment="30" Format="hh:mm tt" />
                                            <ext:TimeField ID="THFIN" runat="server" FieldLabel="HORA FIN:" LabelWidth="100" Width="270" MarginSpec="5 0 5 5 " Increment="30" Format="hh:mm tt" />
                                        </Items>
                                    </ext:FormPanel>
                                    <ext:FormPanel runat="server" ID="FDIA" Layout="HBoxLayout" Hidden="true" Height="50" Padding="10">
                                        <Items>
                                            <ext:DateField runat="server" ID="DFECHAINI"  FieldLabel="FECHA INICIO" LabelWidth="100" Width="250"  Vtype="daterange" EndDateField="DFECHAFIN" />
                                            <ext:DateField runat="server" ID="DFECHAFIN" FieldLabel="FECHA FIN" LabelWidth="80" Width="270"  Vtype="daterange" StartDateField="DFECHAINI" />
                                        </Items>
                                    </ext:FormPanel>
                                </Items>
                            </ext:Panel>
                        </Items>
                        <Listeners>
                            <ValidityChange Handler="#{BGUARDAR}.setDisabled(!valid);" />
                        </Listeners>
                        <BottomBar>
                            <ext:Toolbar ID="Toolbar3" runat="server" UI="Info">
                                <Items>
                                    <ext:ToolbarFill />
                                    <ext:Button ID="BCANCELAR" runat="server" Text="Cancelar">
                                        <Listeners>
                                            <Click Handler="App.FREGISTRO.reset();App.WREGISTRO.hide();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" ID="BGUARDAR" Icon="Add" Text="Guardar" FormBind="true">
                                        <%-- <Listeners>
                                    <Click Handler="if(#{FREGISTRO}.getForm().isValid()) {App.direct.registrarHorario(App.THINICIO.getValue(),App.THFIN.getValue());}else{ return false;}  " />
                                </Listeners>--%>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:FormPanel>
                </Items>

                <%-- <Listeners>
                    <BeforeHide Handler="App.FREGISTRO.reset();parametro.consultarHorarios();" />
                </Listeners>--%>
            </ext:Window>
        </div>

    </form>
</body>
</html>
