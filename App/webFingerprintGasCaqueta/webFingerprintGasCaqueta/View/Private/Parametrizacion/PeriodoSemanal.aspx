<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeriodoSemanal.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.PeriodoSemanal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PeriodoSemanal</title>
    <script type="text/javascript">
        var beforenodedrop = function (node, data, overModel, dropPosition, dropFn) {
            if (Ext.isArray(data.records)) {
                var idsemana = overModel.id.replace('N', '');
                var records = data.records,
                    rec;

                data.records = [];

                for (var i = 0; i < records.length; i++) {
                    rec = records[i];
                }

                return true;
            }
        };
        var beforerecorddrop = function (node, data, overModel, dropPosition, dropFn) {

            if (node.innerText.trim() !== "SEMANA") {
                if (Ext.isArray(data.records)) {
                    var idsemana = overModel.id.replace('N', '');
                    var records = data.records,
                        rec;
                    var _result;
                    data.records = [];
                    for (var i = 0; i < records.length; i++) {
                        rec = records[i];
                        parametro.registrarPeriodo(idsemana, rec.get("ID"), rec.get("HORARIO"));
                    }
                }
                return true;
            }
        }

        var deleteNode = function (node, record, data, overModel) {
            debugger;
            var idsemana = data.data.parentId.replace('N', '');
            var idhorariodia = data.id.replace('HS', '');
            parametro.eliminarHorarioSemana(idsemana, idhorariodia, {
                success: function (result) {
                    if (result == true) {
                        App.TSEMANAHORARIO.store.remove(data);
                        Ext.net.Notification.show({
                            html: 'Eliminado Exitosamente.!', title: 'Notificación'
                        });
                    }
                }, failure: function (errorMsg) {
                    Ext.net.Notification.show({
                        html: 'Ha ocurrido un error.!', title: 'Notificación'
                    });
                }

            });

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Hidden runat="server" ID="HIDPERIODO" />
        <ext:Panel ID="Panel1" runat="server" Width="850" Height="500" Layout="BorderLayout">

            <Items>
                <ext:GridPanel
                    ID="GPERIODO" runat="server" MultiSelect="true" Width="550" Height="350" Region="Center" MarginSpec="5 0 5 5" Border="true">
                    <Store>
                        <ext:Store ID="SHORARIO" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
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
                            <ext:RowNumbererColumn ID="RowNumbererColumn1" runat="server" />
                            <ext:Column ID="Column1" runat="server" Text="NOMBRE" Flex="2" DataIndex="NOMBRE" />
                            <ext:Column ID="Column2" runat="server" Text="HORARIO" Flex="2" DataIndex="HORARIO" />
                        </Columns>
                    </ColumnModel>
                    <View>
                        <ext:GridView ID="GridView1" runat="server">
                            <Plugins>
                                <ext:GridDragDrop ID="GridDragDrop1" runat="server" DragGroup="grid2tree" DropGroup="tree2grid" />
                            </Plugins>
                            <Listeners>
                                <BeforeDrop Fn="beforenodedrop" />
                            </Listeners>
                        </ext:GridView>
                    </View>
                    <BottomBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                <ext:Button ID="BADICIONAR" runat="server" Icon="Add" Text="HORARIO">
                                    <Listeners>
                                        <Click Handler="parametro.AbrirVentanaHorario();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </BottomBar>
                </ext:GridPanel>
                <ext:TreePanel ID="TSEMANAHORARIO"
                    runat="server"
                    Region="East"
                    Width="300"
                    MarginSpec="5 5 5 0"
                    Split="true">
                    <Root>
                        <%--<ext:Node NodeID="NSEMANA"  Expanded="true" >
                            <Children>
                                <ext:Node Text="Lunes" NodeID="NLunes" AllowDrag="false"/>
                                <ext:Node Text="Martes" NodeID="NMartes"  AllowDrag="false"/>
                                <ext:Node Text="Miercoles" NodeID="NMiercoles"  AllowDrag="false"/>
                                <ext:Node Text="Jueves" NodeID="NJueves"  AllowDrag="false"/>
                                <ext:Node Text="Viernes" NodeID="NViernes"  AllowDrag="false"/>
                                <ext:Node Text="Sabado" NodeID="NSabado"  AllowDrag="false"/>
                                <ext:Node Text="Domingo" NodeID="NDomingo"  AllowDrag="false"/>
                            </Children>
                        </ext:Node>--%>
                    </Root>
                    <View>
                        <ext:TreeView ID="TreeView1" runat="server">
                            <Plugins>
                                <ext:TreeViewDragDrop ID="TreeViewDragDrop1" runat="server" DragGroup="tree2grid" DropGroup="grid2tree" />
                            </Plugins>
                            <Listeners>
                                <BeforeDrop Fn="beforerecorddrop" />
                            </Listeners>
                        </ext:TreeView>
                    </View>

                    <ColumnModel>
                        <Columns>
                            <ext:TreeColumn ID="TDESCRIPCION" runat="server" Flex="1" DataIndex="text" />
                            <ext:CommandColumn ID="CommandColumn1" runat="server" Width="40">
                                <Commands>
                                    <ext:GridCommand CommandName="Delete" Icon="Delete" ToolTip-Text="Eliminar Franja Horaria" />
                                </Commands>
                                <PrepareToolbar Handler="return record.data.leaf;" />
                                <Listeners>
                                    <Command Fn="deleteNode" />
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:TreeSelectionModel runat="server" Mode="Multi" />
                    </SelectionModel>
                </ext:TreePanel>
            </Items>
        </ext:Panel>

    </form>
</body>
</html>
