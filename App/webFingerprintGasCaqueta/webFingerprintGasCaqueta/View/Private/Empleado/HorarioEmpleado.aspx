<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HorarioEmpleado.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Empleado.Horario" %>
<html>
<head runat="server">
    <title>HORARIOS EMPLEADOS</title>
    <style>
        .complete .x-grid-cell-inner {
            text-decoration : line-through;
            color : #777;
        }
      
    </style>
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
                    var RESUMEN = node.data.IDENTIFICACION + node.data.NOMBRE + node.data.TIPO;
                    var a = re.test(RESUMEN);
                    return a;
                });
            }
        };

    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <ext:Viewport runat="server">
        <LayoutConfig>
            <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
        </LayoutConfig>
        <Items>
            <ext:Hidden runat="server" ID="HPERIODO" />
            <ext:FormPanel ID="FPRIMARIO" runat="server" Width="1200"  Height="700"   UI="Primary" Border="true" Padding="5" Layout="BorderLayout">
                <Items>
                    <ext:Panel ID="PHORARIO"  runat="server" Icon="CalendarSelectWeek" Region="West" Collapsible="true"  MinWidth="300"  Split="true" Width="300"  Title="HORARIO SEMANAL" Collapsed="false" BodyPadding="5" >
                        <Items>
                            <ext:GridPanel ID="GHORARIOS"  runat="server" >
                                <Store>
                                    <ext:Store runat="server" ID="SHORARIO">
                                        <Fields>
                                            <ext:ModelField Name="IDPERIODO"/>
                                            <ext:ModelField Name="HORARIO"/>
                                            <ext:ModelField Name="DURACION" />
                                        </Fields>
                                    </ext:Store>
                                </Store>
                                <ColumnModel runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn runat="server" />
                                            <ext:Column runat="server" ID="CMHORARIO" Text="HORARIO" DataIndex="HORARIO" Flex="3" />
                                            <ext:Column runat="server" ID="CMURACION" Text="DURACION" DataIndex="DURACION" Width="90"  />
                                        </Columns>
                                    </ColumnModel>
                               <SelectionModel>
                                   <ext:RowSelectionModel runat="server">
                                       <Listeners>
                                           <Select Handler=" 
                                               App.PHORARIO.collapse();
                                               App.PHORARIOSEMANA.expand();
                                               App.PEMPLEADO.expand(); 
                                               App.HPERIODO.setValue(record.data.IDPERIODO);
                                               App.PEMPLEADO.setTitle('LISTA DE EMPLEADOS' + '(' +record.data.HORARIO +')');
                                               parametro.consultarHorariosPorPeriodo(record.data.IDPERIODO);
                                               "
                                           />
                                       </Listeners>
                                   </ext:RowSelectionModel>
                               </SelectionModel>
                            </ext:GridPanel>
                        </Items>
                        <Listeners>
                            <AfterRender Handler="this.setTitle('HORARIO SEMANAL');" />
                            <BeforeCollapse Handler="this.setTitle('HORARIO SEMANAL');" />
                            <BeforeExpand Handler="this.setTitle(this.initialConfig.title);" />
                        </Listeners>
                        <Buttons>
                            <ext:Button ID="BHORARIOSEMANAL" runat="server" Icon="Add" Text="AGREGAR" >
                                <Listeners>
                                    <Click Handler="parametro.AbrirVentanaHorario();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                    <ext:Panel runat="server" Region="Center" Enabled="true" Layout="BorderLayout" UI="Primary">
                        <Items>
                            <ext:Panel runat="server" ID="PEMPLEADO" Title="LISTADO EMPLEADOS" Region="Center" Icon="User" Frame="true" Width="200"   Collapsible="true" Collapsed="true">
                                <Items>
                                    <ext:GridPanel ID="GEMPLEADOS" runat="server">
                                        <TopBar>
                                        <ext:Toolbar runat="server">
                                            <Items>
                                                <ext:TextField ID="TFEMPLEADO" runat="server" EmptyText="Identificación o  nombre para buscar" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                    <Listeners>
                                                        <KeyPress Handler="findUser(App.GEMPLEADOS.store, App.TFEMPLEADO.getValue(), Ext.EventObject);" Buffer="200" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Presionar enter para buscar" />
                                                    </ToolTips>
                                                </ext:TextField>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                        <Store>
                                            <ext:Store runat="server" ID="SEMPLEADOS" PageSize="11">
                                                <Model>
                                                    <ext:Model runat="server"  ID="CODIGO">
                                                        <Fields>
                                                            <ext:ModelField Name="CODIGO" />
                                                            <ext:ModelField Name="IDENTIFICACION" />
                                                            <ext:ModelField Name="NOMBRE" />
                                                            <ext:ModelField Name="TIPO" />
                                                            <ext:ModelField Name="EXISTHORARIO" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                       <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" ID="CIDENTIFICACION" Text="IDENTIFICACIÓN" DataIndex="IDENTIFICACION" Width="130" />
                                            <ext:Column runat="server" ID="cNOMBRE" Text="EMPLEADO" DataIndex="NOMBRE" Flex="4" />
                                            <ext:Column runat="server" ID="CTIPO" Text="CARGO" DataIndex="TIPO" Width="200"  />
                                            <ext:Column runat="server" ID="CEXISTHORARIO" Text="HORARIO" DataIndex="EXISTHORARIO" Width="80"  />
                                        </Columns>
                                    </ColumnModel>
                                    <BottomBar>
                                        <ext:PagingToolbar runat="server" AutoRender="true" StoreID="SEMPLEADOS" />
                                    </BottomBar>
                                        <SelectionModel>
                                            <ext:CheckboxSelectionModel  runat="server" Mode="Multi" />
                                        </SelectionModel>
                                        <Listeners>
                                            <BeforeSelect Handler="App.FOPCION.expand(); App.PHORARIOSEMANA.collapse();" />
                                        </Listeners>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel ID="PHORARIOSEMANA" runat="server" Title="DETALLE HORARIO SEMANA" Height="180" Region="South" Frame="true" Collapsed="true" Collapsible="true" >
                                <Items>
                                    <ext:GridPanel runat="server" ID="GHORARIOSEMANA" >
                                         <Store>
                                            <ext:Store runat="server" ID="Store1">
                                                <Model>
                                                    <ext:Model runat="server">
                                                        <Fields>
                                                            <ext:ModelField Name="LUNES" />
                                                            <ext:ModelField Name="MARTES" />
                                                            <ext:ModelField Name="MIERCOLES" />
                                                            <ext:ModelField Name="JUEVES" />
                                                            <ext:ModelField Name="VIERNES" />
                                                            <ext:ModelField Name="SABADO" />
                                                            <ext:ModelField Name="DOMINGO" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                       <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" ID="CDIASEMANA" Text="LUNES" DataIndex="LUNES" Flex="1" />
                                            <ext:Column runat="server" ID="CHORARIO" Text="MARTES" DataIndex="MARTES" Flex="1" />
                                            <ext:Column runat="server" ID="Column3" Text="MIERCOLES" DataIndex="MIERCOLES" Flex="1"  />
                                            <ext:Column runat="server" ID="Column4" Text="JUEVES" DataIndex="JUEVES" Flex="1"  />
                                            <ext:Column runat="server" ID="Column1" Text="VIERNES" DataIndex="VIERNES" Flex="1"  />
                                            <ext:Column runat="server" ID="Column2" Text="SABADO" DataIndex="SABADO" Flex="1"  />
                                            <ext:Column runat="server" ID="Column5" Text="DOMINGO" DataIndex="DOMINGO" Flex="1"  />
                                        </Columns>
                                    </ColumnModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Panel>
                       
                    <ext:FormPanel ID="FOPCION" runat="server" Region="South" Collapsible="true" Collapsed="true" Split="true" Height="80" Title="PREFERENCIA HORARIO" Floatable="false">
                        <Items>
                            <ext:Panel runat="server" Layout="HBoxLayout">
                               <Items>
                                  <ext:Container runat="server" Padding="7" Width="150" >
                                      <Items>
                                        
                                          <ext:CycleButton  ID="BTIPOHORARIO" runat="server" Padding="5" ShowText="true" Width="130"  >
                                              <Menu>
                                                  <ext:Menu ID="MTIPO" runat="server">
                                                      <Items>
                                                          <ext:MenuItem ID="MFIJO"  runat="server" Text="FIJO">
                                                              <Listeners>
                                                                  <Click Handler="App.CFECHAS.hide();App.DFECHAINI.allowBlank=true;App.DFECHAFIN.allowBlank=true;App.FOPCION.reset();" />
                                                              </Listeners>
                                                          </ext:MenuItem>
                                                          <ext:MenuItem ID="MPERIODO" runat="server" Text="POR PERIODO">
                                                              <Listeners>
                                                                  <Click Handler="App.CFECHAS.show();App.DFECHAINI.allowBlank=false;App.DFECHAFIN.allowBlank=false;App.FOPCION.reset();" />
                                                              </Listeners>
                                                          </ext:MenuItem>
                                                      </Items>
                                                  </ext:Menu>
                                              </Menu>
                                          </ext:CycleButton>
                                      </Items>
                                  </ext:Container>
                                  <ext:Container runat="server" ID="CFECHAS" Layout="HBoxLayout" Width="580" Padding="5" Hidden="true" >
                                      <Items>
                                          <ext:DateField runat="server" ID="DFECHAINI" Padding="5" FieldLabel="FECHA INICIO" LabelWidth="100"   Vtype="daterange" EndDateField="DFECHAFIN" />
                                          <ext:DateField runat="server" ID="DFECHAFIN" Padding="5" FieldLabel="FECHA FIN" LabelWidth="90"   Vtype="daterange"   StartDateField="DFECHAINI" />
                                      </Items>
                                  </ext:Container> 
                                   <ext:Container runat="server"  Width="370" Padding="5" Layout="HBoxLayout" >
                                       <Items>
                                         <ext:NumberField runat="server" ID="NRETRASO" FieldLabel="RETARDO(MIN)" Padding="5" Width="180" LabelWidth="100" MinValue="0" AllowBlank="false" />
                                         <ext:Checkbox runat="server"  ID="CFESTIVO"  FieldLabel="INCLUIR FESTIVOS" Padding="5" Width="150" LabelWidth="130" />
                                       </Items>
                                   </ext:Container>
                               </Items>
                            </ext:Panel>
                        </Items>
                        <Listeners>
                            <AfterRender Handler="this.setTitle('PREFERENCIA HORARIO');" />
                            <BeforeCollapse Handler="this.setTitle('PREFERENCIA HORARIO');" />
                            <BeforeExpand Handler="this.setTitle(this.initialConfig.title);" />
                        </Listeners>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="BGUARDAR" runat="server" Text="GUARDAR" FormBind="true">
                        <Listeners>
                            <Click Handler="var opcionHorario = App.BTIPOHORARIO.activeItem;
                                            if(App.FPRIMARIO.isValid()){
                                                parametro.RegistrarHorarioEmpleado(App.HPERIODO.getValue(),opcionHorario.id,App.CFESTIVO.checked,App.NRETRASO.getValue());
                                            }else{
                                                 Ext.Msg.show({
                                                   title: 'Notificación',
                                                   msg: 'Faltan por llenar campos',
                                                   buttons: Ext.Msg.OK,
                                                   icon: Ext.window.MessageBox.INFO
                                                 });  
                                            }" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
</body>
</html>
