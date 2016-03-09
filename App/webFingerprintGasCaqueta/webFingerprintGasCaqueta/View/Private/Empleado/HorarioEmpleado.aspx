<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HorarioEmpleado.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Empleado.Horario" %>



<!DOCTYPE html>

<html>
<head runat="server">
    <title>HORARIOS EMPLEADOS</title>
    <style>
        #WestPanel-placeholder-innerCt {
            background: url(collapsed-west.png) no-repeat center;
        }

        #SouthPanel-placeholder-innerCt {
            background: url(collapsed-south.png) no-repeat center;
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
            <ext:FormPanel ID="FPRIMARIO" runat="server" Width="1200"  Height="670"   UI="Primary" Border="true" Padding="5" Layout="BorderLayout">
                <Items>
                    <ext:Panel ID="WestPanel"  runat="server" Icon="CalendarSelectWeek" Region="West" Collapsible="true"  MinWidth="300"  Split="true" Width="300"  Title="HORARIO SEMANAL" Collapsed="false" BodyPadding="5" >
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
                            </ext:GridPanel>
                        </Items>
                        <Listeners>
                            <AfterRender Handler="this.setTitle('HORARIO SEMANAL');" />
                            <BeforeCollapse Handler="this.setTitle('');" />
                            <BeforeExpand Handler="this.setTitle(this.initialConfig.title);" />
                        </Listeners>
                    </ext:Panel>
                    <ext:Panel runat="server" Region="Center" Enabled="true" Layout="BorderLayout" UI="Primary">
                        <Items>
                            <ext:Panel runat="server" Title="LISTADO EMPLEADOS" Region="Center" Icon="User" Frame="true" Width="200"   Collapsed="false"  AnimCollapse="true" Collapsible="true">
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
                                            <ext:Store runat="server" ID="SEMPLEADOS" PageSize="15">
                                                <Model>
                                                    <ext:Model runat="server">
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
                                            <ext:CheckboxSelectionModel runat="server" Mode="Multi" />
                                        </SelectionModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel runat="server" Title="DETALLE HORARIO SEMANA" Height="260" Region="South" Frame="true" Collapsed="true" Collapsible="true" >
                                <Items>
                                    <ext:GridPanel runat="server" ID="GHORARIOSEMANA" Height="250">
                                         <Store>
                                            <ext:Store runat="server" ID="Store1">
                                                <Model>
                                                    <ext:Model runat="server">
                                                        <Fields>
                                                            <ext:ModelField Name="IDSEMANA" />
                                                            <ext:ModelField Name="IDPERIODO" />
                                                            <ext:ModelField Name="DIASEMANA" />
                                                            <ext:ModelField Name="HORARIO" />
                                                            <ext:ModelField Name="DURACION" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                       <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" ID="CDIASEMANA" Text="IDENTIFICACIÓN" DataIndex="IDENTIFICACION" Width="130" />
                                            <ext:Column runat="server" ID="CHORARIO" Text="EMPLEADO" DataIndex="NOMBRE" Flex="4" />
                                            <ext:Column runat="server" ID="Column3" Text="CARGO" DataIndex="TIPO" Flex="3"  />
                                            <ext:Column runat="server" ID="Column4" Text="HORARIO" DataIndex="EXISTHORARIO" Flex="1"  />
                                        </Columns>
                                    </ColumnModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Panel>
                       
                    <ext:Panel ID="SouthPanel" runat="server" Region="South" Collapsible="true" Split="true" Height="80" Title="OPCIONES" Floatable="false">
                        <Items>
                            <ext:Panel runat="server" Width="200">
                                <Content>
                                    <ext:DateRangeField runat="server" />
                                </Content>
                            </ext:Panel>
                        </Items>
                        <Listeners>
                            <AfterRender Handler="this.setTitle('');" />
                            <BeforeCollapse Handler="this.setTitle('');" />
                            <BeforeExpand Handler="this.setTitle(this.initialConfig.title);" />
                        </Listeners>
                    </ext:Panel>
                </Items>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
</body>
</html>
