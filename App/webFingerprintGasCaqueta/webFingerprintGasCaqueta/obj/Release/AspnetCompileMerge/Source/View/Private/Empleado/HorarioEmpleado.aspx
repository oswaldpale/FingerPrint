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
        var registrarHorarioEmpleado = function () {
           
            var opcionHorario = App.BTIPOHORARIO.activeItem;
            var fini = "";
            var ffin = "";
            if (App.FPRIMARIO.isValid()) {
                if(App.BTIPOHORARIO.activeItem.id=='MPERIODO'){
                    fini = App.DFECHAINI.getValue().toLocaleDateString();
                    ffin = App.DFECHAFIN.getValue().toLocaleDateString();
                }

                parametro.RegistrarHorarioEmpleado(App.HPERIODO.getValue(), opcionHorario.id, App.CFESTIVO.checked, App.NRETRASO.getValue(), fini, ffin);

            } else {
                Ext.Msg.show({
                    title: 'Notificación',
                    msg: 'Faltan por llenar campos',
                    buttons: Ext.Msg.OK,
                    icon: Ext.window.MessageBox.INFO
                });
            }
        }

        var modificarHorarioEmpleado = function () {

            var opcionHorario = App.BTIPOHORARIO.activeItem;
            var fini = "";
            var ffin = "";

            if (App.FPRIMARIO.isValid()) {
                if (App.BTIPOHORARIO.activeItem.id == 'MPERIODO') {

                    fini = App.DFECHAINI.getValue().toLocaleDateString();
                    ffin = App.DFECHAFIN.getValue().toLocaleDateString();
                }
                parametro.ModificarHorarioEmpleado(App.HPERIODO.getValue(), opcionHorario.id, App.CFESTIVO.checked, App.NRETRASO.getValue(), fini, ffin);
            } else {
                Ext.Msg.show({
                    title: 'Notificación',
                    msg: 'Faltan por llenar campos',
                    buttons: Ext.Msg.OK,
                    icon: Ext.window.MessageBox.INFO
                });
            }
        }

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
            <ext:FormPanel ID="FPRIMARIO" runat="server" Width="700"  Height="600"   UI="Primary" Border="true" Padding="5" Layout="BorderLayout">
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
                                               App.HPERIODO.setValue(record.data.IDPERIODO);
                                               console.log(record.data.IDPERIODO);
                                               App.PSEMANA.setTitle('HORARIO ACTUAL: ' + record.data.HORARIO);
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
                    <ext:Panel runat="server" Region="Center"  UI="Primary" ID="PSEMANA" Title="HORARIO ACTUAL: No asignado">
                        <Items>
                           <ext:GridPanel ID="GHORARIO"  runat="server" >
                                <Store>
                                    <ext:Store runat="server" ID="SLABORAL"  >
                                        <Fields>
                                            <ext:ModelField Name="ID" SortDir="DESC" Type="Int" />
                                            <ext:ModelField Name="DIAID"/>
                                            <ext:ModelField Name="HORARIO"/>
                                        </Fields>
                                    </ext:Store>
                                </Store>
                                <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" ID="Column1" Text="SEMANA" DataIndex="DIAID" Width="130" />
                                            <ext:Column runat="server" ID="Column2" Text="HORARIO" DataIndex="HORARIO" Flex="1"  />
                                        </Columns>
                                    </ColumnModel>
                              
                            </ext:GridPanel>
                        </Items>
                  </ext:Panel>       
                       
                    <ext:FormPanel ID="FOPCION" runat="server" Region="South" Collapsible="true" Collapsed="true" Split="true" Height="150" Title="PREFERENCIA HORARIO" Floatable="false">
                        <Items>
                            <ext:Panel runat="server"  >
                               <Items>
                                  <ext:Container runat="server" Padding="7" Width="150" Layout="HBoxLayout" >
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
                                  <ext:Container runat="server" ID="CFECHAS" Layout="HBoxLayout" Width="600"  Hidden="true" >
                                      <Items>
                                          <ext:DateField runat="server" ID="DFECHAINI" Padding="5" FieldLabel="FECHA INICIO" LabelWidth="100"   Vtype="daterange" EndDateField="DFECHAFIN" />
                                          <ext:DateField runat="server" ID="DFECHAFIN" Padding="5" FieldLabel="FECHA FIN" LabelWidth="90"   Vtype="daterange"   StartDateField="DFECHAINI" />
                                      </Items>
                                  </ext:Container> 
                                   <ext:Container runat="server"  Width="350"  Layout="HBoxLayout" >
                                       <Items>
                                         <ext:NumberField runat="server" ID="NRETRASO" FieldLabel="RETARDO(MIN)" Padding="5" Width="170" LabelWidth="100" MinValue="0" AllowBlank="false" />
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
                           <Click Fn="registrarHorarioEmpleado" />
                       </Listeners>
                    </ext:Button>
                    <ext:Button ID="BMODIFICAR" runat="server" Text="ACTUALIZAR" FormBind="true" Hidden="true">
                       <Listeners>
                           <Click Fn="modificarHorarioEmpleado" />
                       </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
</body>
</html>
