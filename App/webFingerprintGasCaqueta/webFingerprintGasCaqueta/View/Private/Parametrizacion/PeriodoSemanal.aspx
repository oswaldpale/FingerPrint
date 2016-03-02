<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeriodoSemanal.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.PeriodoSemanal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PeriodoSemanal</title>
    <script type="text/javascript">
        var beforenodedrop = function (node, data, overModel, dropPosition, dropFn) {
            alert('entro2');
            debugger;
            if (Ext.isArray(data.records)) {
                var records = data.records,
                    rec;

                data.records = [];

                for (var i = 0; i < records.length; i++) {
                    rec = records[i];
                    rec.remove(true);
                }

                return true;
            }
        };
        var beforerecorddrop = function (node, data, overModel, dropPosition, dropFn) {
          
            if (node.innerText.trim() !== "SEMANA") {
                if (Ext.isArray(data.records)) {
                    var records = data.records,
                        rec;

                    data.records = [];
                    debugger;
                    for (var i = 0; i < records.length; i++) {
                        rec = records[i];

                        data.records.push({
                            text: rec.get("HORARIO"),
                            leaf: true,
                            ID: rec.get("ID"),
                            NOMBRE: rec.get("NOMBRE"),
                            HORARIO: rec.get("HORARIO")
                        });
                    }
                }
                return true;
            }
        };
        function deleteNode(tree) {
            var selectedNode = tree.getSelectionModel().getSelectedNode();
            if (selectedNode) {
                selectedNode.remove(true);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" />

        <ext:Panel runat="server" Width="850" Height="600" Layout="BorderLayout">
            <Items>
                <ext:GridPanel
                    ID="GPERIODO" runat="server" MultiSelect="true" Width="450" Height="400"  Region="Center"  MarginSpec="5 0 5 5" Border="true">
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
                <ext:TreePanel ID="TSEMANAHORARIO"
                    runat="server"
                    Region="East"
                    Width="300"
                    MarginSpec="5 5 5 0"
                    Split="true">
                    <Root>
                        <ext:Node Text="SEMANA" Expanded="true" AllowDrag="false">
                            <Children>
                                <ext:Node Text="Lunes" NodeID="NLunes" AllowDrag="false"/>
                                <ext:Node Text="Martes" NodeID="NMartes"  AllowDrag="false"/>
                                <ext:Node Text="Miercoles" NodeID="NMiercoles"  AllowDrag="false"/>
                                <ext:Node Text="Jueves" NodeID="NJueves"  AllowDrag="false"/>
                                <ext:Node Text="Viernes" NodeID="NViernes"  AllowDrag="false"/>
                                <ext:Node Text="Sabado" NodeID="NSabado"  AllowDrag="false"/>
                                <ext:Node Text="Domingo" NodeID="NDomingo"  AllowDrag="false"/>
                            </Children>
                        </ext:Node>
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
                            <ext:TreeColumn ID="TDESCRIPCION" runat="server" Flex="1"  DataIndex="text" />
                            <ext:CommandColumn runat="server" Width="40">
                                <Commands>
                                    <ext:GridCommand CommandName="Delete" Icon="Delete" ToolTip-Text="Eliminar Franja Horaria" />
                                </Commands>
                                <PrepareToolbar Handler="return record.data.leaf;" />
                                <Listeners>
                                    <Command Handler="deleteNode(TSEMANAHORARIO)" />
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>

                </ext:TreePanel>
            </Items>
        </ext:Panel>
        
    </form>
</body>
</html>
