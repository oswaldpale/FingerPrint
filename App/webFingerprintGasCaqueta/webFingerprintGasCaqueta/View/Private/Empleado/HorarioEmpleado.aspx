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
</head>
<body>
    <ext:ResourceManager runat="server" />
    <ext:Viewport runat="server">
        <LayoutConfig>
            <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
        </LayoutConfig>
        <Items>
            <ext:FormPanel ID="FPRIMARIO" runat="server"  Title="HORARIO EMPLEADO" Width="1100"  Height="650"   UI="Primary" Border="true" Padding="5" Layout="BorderLayout">
                <Items>
                    <ext:Panel ID="WestPanel"  runat="server" Icon="CalendarSelectWeek" Region="West" Collapsible="true"  MinWidth="300"  Split="true" Width="300"  Title="HORARIO SEMANAL" Collapsed="false" BodyPadding="5" >
                        <Listeners>
                            <AfterRender Handler="this.setTitle('HORARIO SEMANAL');" />
                            <BeforeCollapse Handler="this.setTitle('');" />
                            <BeforeExpand Handler="this.setTitle(this.initialConfig.title);" />
                        </Listeners>
                    </ext:Panel>
                    <ext:Panel runat="server" Region="Center" Enabled="true" Layout="BorderLayout" UI="Primary">
                        <Items>
                            <ext:Panel runat="server" Title="LISTADO EMPLEADOS" Region="Center" Icon="User" Frame="true" Width="200">
                                <Items>
                                    <ext:GridPanel ID="GEMPLEADOS" runat="server">
                                        <Store>
                                            <ext:Store runat="server" ID="SEMPLEADOS">
                                                <Model>
                                                    <ext:Model runat="server">
                                                        <Fields>
                                                            <ext:ModelField Name="ID" />
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
                                            <ext:CheckColumn runat="server" ID="CKECK" Width="50" />
                                            <ext:Column runat="server" ID="CIDENTIFICACION" Text="IDENTIFICACIÓN" DataIndex="IDENTIFICACION" Width="130" />
                                            <ext:Column runat="server" ID="cNOMBRE" Text="EMPLEADO" DataIndex="NOMBRE" Flex="4" />
                                            <ext:Column runat="server" ID="CTIPO" Text="CARGO" DataIndex="TIPO" Flex="3"  />
                                            <ext:Column runat="server" ID="CEXISTHORARIO" Text="HORARIO" DataIndex="EXISTHORARIO" Flex="1"  />
                                        </Columns>
                                    </ColumnModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel runat="server" Title="DETALLE HORARIO SEMANA" Height="300" Region="South" Frame="true" Collapsed="true">
                                <Items>
                                    <ext:GridPanel runat="server" ID="GHORARIOSEMANA" Height="300">
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
                       
                    <ext:Panel ID="SouthPanel" runat="server" Region="South" Collapsible="true" MinHeight="100" Split="true" Height="100" Title="OPCIONES" Floatable="false">
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
