<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChecadosIngresos.aspx.cs" Inherits="webFingerprintGasCaqueta.Report.View.ChecadosIngresos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .x-fieldset-header-default > .x-fieldset-header-text {
            padding: 10px 0;
            font-family: arial, sans-serif;
            color: #0B802E;
            font-size: 14px;
            font-weight: bold;
            font-style: italic;
        }

        .x-grid-body .x-grid-cell-CIDENTIFICACION {
            background-color : #f1f2f4;
        }
        .x-grid-body .x-grid-cell-CDURACION {
            background-color : #f1f2f4;
        }
        .x-grid-row-summary .x-grid-cell-CDURACION .x-grid-cell-inner{
            background-color : #e1e2e4;
        }

        .CIDENTIFICACION .x-grid-cell-inner {
            padding-left: 18px;
        }

        .x-grid-row-summary .x-grid-cell-inner {
            font-weight      : bold;
            font-size        : 11px;
            background-color : #f1f2f4;
        }
        .title-FDPRINCIPAL {
            font-family: verdana, sans-serif;
            color: #31914E;
            font-size: 12px;
            font-weight: bold;
            font-style: italic; 
        }
    </style>
    <script type="text/javascript">
        var findControl = function (Store, texto, e) {
           
            if (e.getKey() == 13) {
              
                var store = Store,
                    text = texto;
                store.clearFilter();
                if (Ext.isEmpty(text, false)) {
                    return;
                }
                var re = new RegExp(".*" + text + ".*", "i");
                store.filterBy(function (node) {
                    var RESUMEN = node.data.IDENTIFICACION + node.data.NOMBRE + node.data.USUARIO + node.data.TIPO + node.data.DEPENDENCIA;
                    var a = re.test(RESUMEN);
                    return a;
                });
            }
        };
      
        function ReportePorEmpleado() {
            var _GCONTROL = App.GCONTROL;
            var result = _GCONTROL.selection === null ? 'YES' : 'NO'; //  Si no existe una selección de la fila en el GridPanel.
            if (result == 'NO') {
                parametro.ReporteAsistenciaEmpleadoIndividual(_GCONTROL.selection.data.CODIGO);
            } else {
                Ext.net.Notification.show({
                    html: 'No se ha seleccionado un funcionario!', title: 'Notificación'
                });
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp" />
    
    <form id="form1" runat="server">
        
        <ext:Viewport runat="server" >
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:FormPanel ID="FPRINCIPAL" runat="server" Width="1150" Height="650" Border="true" TitleAlign="Center" BodyPadding="8" AutoScroll="true" UI="Success">
                    <FieldDefaults LabelAlign="Right" LabelWidth="115" MsgTarget="Side" />
                    <Items>
                        <ext:FieldSet  ID="FSPRINCIPAL" runat="server" DefaultWidth="1150"  Height="620" Title="LISTADO DE ASISTENCIAS"  Cls="dot-label" >
                            <Items>
                                <ext:Container runat="server" >
                                    <Items>
                                        <ext:GridPanel ID="GCONTROL" runat="server"  Height="580" Border="true" Width="1100" Frame="true"  >
                                            <TopBar>
                                                <ext:Toolbar runat="server">
                                                    <Items>
                                                        <ext:TextField ID="TFILTRO" runat="server" EmptyText="Buscar por identificación o dependencia" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                            <Listeners>
                                                                <KeyPress Handler="findControl(App.GCONTROL.store, App.TFILTRO.getValue(), Ext.EventObject);" />
                                                            </Listeners>
                                                            <Plugins>
                                                                <ext:ClearButton runat="server" >
                                                                    <Listeners>
                                                                        <Clear  Handler="var store = App.GCONTROL.store;store.clearFilter(); " />
                                                                    </Listeners>
                                                                </ext:ClearButton>
                                                            </Plugins>
                                                        </ext:TextField>
                                                    </Items>
                                                </ext:Toolbar>
                                            </TopBar>
                                            <Store>
                                                <ext:Store ID="SCONTROL" runat="server" GroupField="USUARIO" >
                                                    <Model>
                                                        <ext:Model runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="CODIGO" />
                                                                <ext:ModelField Name="IDENTIFICACION" Type="String" />
                                                                <ext:ModelField Name="NOMBRE" />
                                                                <ext:ModelField Name="TELEFONO" />
                                                                <ext:ModelField Name="TIPO" Type="String"  />
                                                                <ext:ModelField Name="USUARIO" />
                                                                <ext:ModelField Name="DEPENDENCIA" />
                                                                <ext:ModelField Name="HORAENTRADA" />
                                                                <ext:ModelField Name="OBSERVACION" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                    <Sorters>
                                                        <ext:DataSorter Property="name" />
                                                    </Sorters>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel>
                                                <Columns>
                                                     <ext:RowNumbererColumn runat="server" />
                                                     <ext:Column ID="CIDENTIFICACION" runat="server" DataIndex="IDENTIFICACION" Text="IDENTIFICACIÓN" Align="Left" Width="130"  SummaryType="Count" >
                                                           <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' FILAS)' : '(1 FILAS)');" />
                                                     </ext:Column>
                                                     <ext:Column ID="CPERSONA" runat="server" DataIndex="NOMBRE" Text="NOMBRE" Align="Left" Width="260" >
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                     </ext:Column>
                                                     <ext:Column ID="CTIPO" runat="server" DataIndex="TIPO" Text="CARGO" Align="Left" Width="130"  >
                                                          <SummaryRenderer Handler="return '&nbsp;';" />
                                                    </ext:Column>
                                                   
                                                      <ext:Column ID="CTELEFONO" runat="server" DataIndex="TELEFONO" Text="TELEFONO" Align="Left" Width="110">
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                     </ext:Column>
                                                     <ext:Column ID="CDEPENDENCIA" runat="server" DataIndex="DEPENDENCIA" Text="DEPENDENCIA" Align="Left" Width="290">
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                     </ext:Column>
                                                     <ext:Column ID="CHORA" runat="server" DataIndex="HORAENTRADA" Text="HORA ENTRADA" Align="Left" Flex="1" >
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                     </ext:Column>
                                                     <ext:Column ID="Column1" runat="server" DataIndex="OBSERVACION" Text="OBSERVACIÓN" Align="Left" Flex="1" Hidden="true">
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                     </ext:Column>
                                                   
                                                </Columns>
                                            </ColumnModel>
                                            <Features>
                                                <ext:Summary ID="Summary" runat="server" />
                                            </Features>
                                            <Features>
                                                <ext:Grouping
                                                    ID="Group1"
                                                    runat="server"
                                                    GroupHeaderTplString="USUARIO : {name} ({rows.length} Item{[values.rows.length > 1 ? 's' : '']})"
                                                    HideGroupedHeader="true"
                                                    EnableGroupingMenu="false" />
                                            </Features>
                                            <BottomBar>
                                                <ext:PagingToolbar runat="server" HideRefresh="true">
                                                   
                                                </ext:PagingToolbar>
                                            </BottomBar>
                                            <LeftBar />
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FieldSet>
                    </Items>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>

