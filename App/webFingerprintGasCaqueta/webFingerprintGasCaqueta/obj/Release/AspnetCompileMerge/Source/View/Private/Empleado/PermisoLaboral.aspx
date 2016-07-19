<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermisoLaboral.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Empleado.PermisoLaboral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PERMISO LABORAL </title>
    <script type="text/javascript">
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
    <ext:ResourceManager ID="ResourceManager1" runat="server" Locale="es-CO" />
    <form id="Form1" runat="server">
        <div>
            <ext:Viewport ID="VPPRESENTACION" runat="server" Layout="border">
                <Items>
                    <ext:Hidden runat="server" ID="HCODEMPLEADO" />
                    <ext:Panel ID="PPRESENTACION" runat="server" Layout="Fit" Region="Center" Padding="5" Frame="true" Border="true">
                        <Items>
                            <ext:GridPanel ID="GPERMISO" runat="server" AutoDataBind="true" Frame="true" Border="true" Height="200">
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
            <ext:Window ID="WREGISTRO" runat="server" Draggable="false" Resizable="true" Width="590" Icon="UserTick" Title="Nueva Permiso" Hidden="true" Modal="true">
                <Items>
                    <ext:FormPanel runat="server" ID="FREGISTRO" Padding="5">
                        <Items>
                            <ext:Panel ID="PREGISTRO" runat="server">
                                <Items>
                                    <ext:FieldSet runat="server" Padding="10">
                                        <Items>
                                            <ext:Container runat="server" Layout="HBoxLayout">
                                                <Items>
                                                   <ext:TextField ID="TFECHASOLICITUD" FieldLabel="FECHA SOLICITUD" LabelWidth="115" Width="265" ReadOnly="true" runat="server" MarginSpec="5 0 5 5 " AllowBlank="false" />
                                                    <ext:ComboBox ID="CDILIGENCIA" FieldLabel="TIPO SOLICITUD" LabelWidth="100" Width="280" runat="server" ValueField="CODIGO" DisplayField="TIPO" AllowBlank="false" MarginSpec="5 0 5 5 " >
                                                        <Store>
                                                            <ext:Store runat="server" ID="STIPO">  
                                                                <Fields>
                                                                     <ext:ModelField Name="CODIGO" />
                                                                     <ext:ModelField Name="TIPO" />
                                                                </Fields>
                                                            </ext:Store>
                                                        </Store>
                                                    </ext:ComboBox>
                                               </Items>
                                            </ext:Container>
                                            <ext:DropDownField ID="DEMPLEADO" FieldLabel="EMPLEADO <font color ='red'>*</font> " MarginSpec="5 0 5 5 " runat="server" LabelWidth="115" Width="550" Flex="1" AllowBlank="false" Editable="false"  >
                                                <Listeners>
                                                    <Expand Handler="this.picker.setWidth(650);" />
                                                </Listeners>
                                                <Listeners>
                                                    <IconClick Handler="this.picker.setWidth(650);" />
                                                </Listeners>
                                                <Component>
                                                    <ext:GridPanel ID="GEMPLEADO" runat="server" ForceFit="true" Padding="4" Frame="true" UI="Primary">
                                                        <TopBar>
                                                            <ext:Toolbar runat="server">
                                                                <Items>
                                                                    <ext:TextField ID="TFEMPLEADO" runat="server" EmptyText="Identificación o  nombre para buscar" Width="400" EnableKeyEvents="true" Icon="Magnifier" ClearCls="true">
                                                                        <Listeners>
                                                                            <KeyPress Handler="findUser(App.GEMPLEADO.store, App.TFEMPLEADO.getValue(), Ext.EventObject);" Buffer="200" />
                                                                        </Listeners>
                                                                        <ToolTips>
                                                                            <ext:ToolTip runat="server" Title="Presionar enter para buscar" Width="200" />
                                                                        </ToolTips>
                                                                        <Plugins>
                                                                            <ext:ClearButton runat="server">
                                                                                <Listeners>
                                                                                    <Clear Handler="App.SEMPLEADO.clearFilter();" />
                                                                                </Listeners>
                                                                            </ext:ClearButton>
                                                                        </Plugins>
                                                                    </ext:TextField>
                                                                </Items>
                                                            </ext:Toolbar>
                                                        </TopBar>
                                                        <Store>
                                                            <ext:Store ID="SEMPLEADO" runat="server" PageSize="10">
                                                                <Model>
                                                                    <ext:Model runat="server">
                                                                        <Fields>
                                                                            <ext:ModelField Name="MCODIGO" />
                                                                            <ext:ModelField Name="MIDENTIFICACION" />
                                                                            <ext:ModelField Name="MNOMBRE" />
                                                                            <ext:ModelField Name="MTIPO" />
                                                                        </Fields>
                                                                    </ext:Model>
                                                                </Model>
                                                            </ext:Store>
                                                        </Store>
                                                        <ColumnModel>
                                                            <Columns>
                                                                <ext:Column ID="CIDENTIFICACION" runat="server" DataIndex="MIDENTIFICACION" Header="IDENTIFICACIÓN" Width="100" />
                                                                <ext:Column ID="CNOMBRE" runat="server" DataIndex="MNOMBRE" Header="FUNCIONARIO" Flex="1" />
                                                                <ext:Column ID="CTIPO" runat="server" DataIndex="MTIPO" Header="CARGO" Width="150" />
                                                            </Columns>
                                                        </ColumnModel>
                                                        <BottomBar>
                                                            <ext:PagingToolbar runat="server" AutoRender="true" StoreID="SEMPLEADO">
                                                            </ext:PagingToolbar>
                                                        </BottomBar>
                                                        <SelectionModel>
                                                            <ext:RowSelectionModel  runat="server" Mode="Single" />
                                                        </SelectionModel>
                                                        <Listeners>
                                                            <RowDblClick Handler="App.HCODEMPLEADO.setValue(record.get('MCODIGO')); App.DEMPLEADO.setValue('(' + record.get('MIDENTIFICACION')+') ' + record.get('MNOMBRE') );App.SEMPLEADO.clearFilter();App.TFEMPLEADO.clear();" />
                                                        </Listeners>
                                                    </ext:GridPanel>
                                                </Component>
                                            </ext:DropDownField>
                                        </Items>
                                    </ext:FieldSet>
                                    <ext:Container runat="server" ID="COPCION" Layout="HBoxLayout">
                                        <Items>
                                            <ext:CycleButton ID="BTIPOHORA" runat="server" Padding="5" ShowText="true" Width="120" MarginSpec="5 0 5 10 " >
                                                <Menu>
                                                    <ext:Menu ID="MTIPOHORA" runat="server">
                                                        <Items>
                                                             <ext:MenuItem ID="MHORA" runat="server" Text="HORA">
                                                                <Listeners>
                                                                    <Click Handler="App.FHORA.show();App.THINICIO.allowBlank=false;App.THFIN.allowBlank=false;App.FDIA.hide();App.DFECHAHORA.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MDIA" runat="server" Text="DIA">
                                                                <Listeners>
                                                                    <Click Handler="App.FHORA.hide();App.DFECHAINI.allowBlank=false;App.DFECHAFIN.allowBlank=false;App.FDIA.show();App.DFECHAHORA.hide();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                           
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:CycleButton>
                                            <ext:DateField runat="server" ID="DFECHAHORA" PaddingSpec="5" EmptyText="FECHA PERMISO" Width="145" MarginSpec="5 0 5 5" AllowBlank="false" />
                                            <ext:CycleButton ID="CESTADO" runat="server" Padding="5" ShowText="true" Width="130" MarginSpec="5 0 5 5 " UI="Info">
                                                <Menu>
                                                    <ext:Menu runat="server">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Text="ACTIVO" />
                                                            <ext:MenuItem  runat="server" Text="INACTIVO" />
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:CycleButton>
                                        </Items>
                                    </ext:Container>

                                    <ext:FieldSet runat="server" ID="FHORA" Layout="HBoxLayout" Height="60" Padding="10">
                                        <Items>
                                            <ext:TimeField ID="THINICIO" runat="server" FieldLabel="HORA INICIO <font color ='red'>*</font> " MinTime="6:00" MaxTime="18:00" LabelWidth="115" Width="265" MarginSpec="5 0 5 5" Increment="30" Format="hh:mm tt">
                                               <Listeners>
                                                   <Select Handler="App.THFIN.clear();App.THFIN.setMinValue(App.THINICIO.getValue());App.THFIN.renderData;" />
                                               </Listeners>
                                            </ext:TimeField>
                                            <ext:TimeField ID="THFIN" runat="server" FieldLabel="HORA FIN <font color ='red'>*</font> " MaxTime="18:00" LabelWidth="100" Width="270" MarginSpec="5 0 5 5 " Increment="30" Format="hh:mm tt" />
                                        </Items>
                                    </ext:FieldSet>
                                    <ext:FieldSet runat="server" ID="FDIA" Layout="HBoxLayout" Hidden="true" Height="60" Padding="10">
                                        <Items>
                                            <ext:DateField runat="server" ID="DFECHAINI" FieldLabel="FECHA INICIO <font color ='red'>*</font> " LabelWidth="100" Width="250" Vtype="daterange" EndDateField="DFECHAFIN" />
                                            <ext:DateField runat="server" ID="DFECHAFIN" FieldLabel="FECHA FIN <font color ='red'>*</font> " LabelWidth="80" Width="390"  MarginSpec="5 0 5 5" Vtype="daterange" StartDateField="DFECHAINI" />
                                        </Items>
                                    </ext:FieldSet>
                                     <ext:FieldSet runat="server" ID="FOBSERVACION"  Title="Observación"  Height="140" Padding="10">
                                        <Items>
                                            <ext:TextArea runat="server" ID="TOBSERVACION" Height="95" Width="555" />
                                        </Items>
                                    </ext:FieldSet>
                                </Items>
                            </ext:Panel>
                        </Items>
                        <Listeners>
                            <ValidityChange Handler="#{BGUARDAR}.setDisabled(!valid);" />
                        </Listeners>
                        <Buttons>
                            <ext:Button ID="BCANCELAR" runat="server" Text="Cancelar">
                                <Listeners>
                                    <Click Handler="App.FREGISTRO.reset();App.WREGISTRO.hide();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button runat="server" ID="BGUARDAR" Icon="Add" Text="Guardar" FormBind="true">
                                 <Listeners>
                                    <Click Handler="if(#{FREGISTRO}.getForm().isValid()) {App.direct.registrarPermiso(App.BTIPOHORARIO.activeItem,App.DFECHAINI.getValue(),App.DFECHAFIN.getValue());}else{ return false;}  " />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
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
