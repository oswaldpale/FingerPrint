<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeriodoSemanal.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.PeriodoSemanal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" />

        <ext:Panel runat="server" Width="850" Height="500" Layout="ColumnLayout">
            <Items>
                <ext:Panel runat="server">
                    <Items>
                        <ext:GridPanel
                            ID="GPERIODO" runat="server" MultiSelect="true" Width="450" Height="400" Border="true">
                            <Store>
                                <ext:Store ID="SHORARIO" runat="server">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="ID" />
                                                <ext:ModelField Name="NOMBRE" />
                                                <ext:ModelField Name="HORARIO" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel>
                                <Columns>
                                    <ext:RowNumbererColumn runat="server" />
                                    <ext:Column runat="server" Text="NOMBRE" Flex="2" DataIndex="NOMBRE" />
                                    <ext:Column runat="server" Text="HORARIO" Flex="2" DataIndex="HORARIO" />
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:GridView runat="server">
                                    <%--<Plugins>
                                <ext:GridDragDrop runat="server" DragGroup="firstGridDDGroup" DropGroup="secondGridDDGroup"/>
                            </Plugins>--%>
                                    <%-- <Listeners>
                                <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" Delay="1" />
                                <Drop Handler="var dropOn = overModel ? ' ' + dropPosition + ' ' + overModel.get('Name') : ' on empty view'; 
                                               Ext.net.Notification.show({title:'Drag from right to left', html:'Dropped ' + data.records[0].get('Name') + dropOn});" />
                            </Listeners>--%>
                                </ext:GridView>
                            </View>
                            <BottomBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:ToolbarFill runat="server" />
                                        <ext:Button ID="BADICIONAR" runat="server" Icon="Add" Text="HORARIO">
                                            <Listeners>
                                                <Click Handler="parametro.AbrirVentanaHorario();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>

                <ext:GridPanel ID="GSEMANA" runat="server" MultiSelect="true" Width="400" Height="400" >
                    <Store>
                        <ext:Store ID="SSEMANA" runat="server">
                            <Model>
                                <ext:Model runat="server" IDProperty="ID">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="DIA" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:RowNumbererColumn runat="server" />
                            <ext:Column runat="server" Text="Dia" DataIndex="DIA" Flex="1" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" Mode="Multi" />
                    </SelectionModel>
                    <Plugins>
                        <%-- <ext:RowExpander runat="server" >
                            <Loader runat="server" DirectMethod="#{DirectMethods}.gridPanelHorario" Mode="Component">
                                <LoadMask ShowMask="true" />
                                <Params>
                                    <ext:Parameter Name="IDSEMANA" Value="this.record.getId()" Mode="Raw" />
                                </Params>
                            </Loader>
                        </ext:RowExpander>--%>
                        <ext:RowExpander ID="REHORARIO" runat="server">
                            <Listeners>

                                <Expand Handler="parametro.consultarPeriodoHorario(record.data.ID)" Delay="1" />
                            </Listeners>

                            <Component>
                                <ext:GridPanel runat="server" ID="GPERIODOHORARIO" Width="300">
                                    <Store>
                                        <ext:Store ID="SPERIODOHORARIO" runat="server">
                                            <Model>
                                                <ext:Model runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="IDHORARIO" />
                                                        <ext:ModelField Name="HORARIO" />
                                                        <ext:ModelField Name="DURACION" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:RowNumbererColumn runat="server" />
                                            <ext:Column runat="server" Text="HORARIO" Flex="1" DataIndex="HORARIO" />
                                            <ext:Column runat="server" Text="TIEMPO TRABAJO" Flex="2" DataIndex="DURACION" />
                                        </Columns>
                                    </ColumnModel>
                                </ext:GridPanel>
                            </Component>
                        </ext:RowExpander>
                    </Plugins>
                    <%--                    <Features>
                        <ext:Grouping
                            runat="server"
                            HideGroupedHeader="true"
                            GroupHeaderTplString="Cuisine: {name} ({rows.length} Item{[values.rows.length > 1 ? 's' : '']})"
                            StartCollapsed="true" />
                    </Features>--%>

                    <%--<View>
                        <ext:GridView runat="server">
                            <Plugins>
                                <ext:GridDragDrop runat="server" DragGroup="secondGridDDGroup" DropGroup="firstGridDDGroup"/>
                            </Plugins>
                            <Listeners>
                                <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" Delay="1" />
                                <Drop Handler="var dropOn = overModel ? ' ' + dropPosition + ' ' + overModel.get('Name') : ' on empty view'; 
                                               Ext.net.Notification.show({title:'Drag from left to right', html:'Dropped ' + data.records[0].get('Name') + dropOn});" />
                            </Listeners>
                        </ext:GridView>
                    </View> --%>
                </ext:GridPanel>
            </Items>
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:ToolbarFill runat="server" />
                        <ext:Button runat="server" Text="GUARDAR" Icon="Disk">
                            <%--<Listeners>
                                <Click Handler="#{Store1}.loadData(#{Store1}.proxy.data); #{Store2}.removeAll();" />
                            </Listeners>--%>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:Panel>
    </form>
</html>
