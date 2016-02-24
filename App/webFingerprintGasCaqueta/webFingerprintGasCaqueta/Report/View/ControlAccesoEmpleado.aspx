<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlAccesoEmpleado.aspx.cs" Inherits="webFingerprintGasCaqueta.Report.View.ControlAccesoEmpleado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
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
    </style>
    <script type="text/javascript">
        var findEmployer = function (Store, texto, e) {
           
            if (e.getKey() == 13) {
              
                var store = Store,
                    text = texto;
                store.clearFilter();
                if (Ext.isEmpty(text, false)) {
                    return;
                }
                var re = new RegExp(".*" + text + ".*", "i");
                store.filterBy(function (node) {
                    var RESUMEN = node.data.IDENTIFICACION + node.data.EMPLEADO;
                    var a = re.test(RESUMEN);
                    return a;
                });
            }
        };
        var TotalHoras = function (records) {


            var i = 0,
                length = records.length,
                total,
                record;
            var h;
            var hours = 0, minutes = 0, seconds = 0;
            for (;i < length; ++i) {
                record = records[i];
                h = record.get('DURACION').split(":");
                seconds = parseInt(h[2].toString()) + seconds;
                if (seconds >= 60) {
                    seconds = seconds - 60;
                    minutes = minutes + 1;
                }
                minutes = minutes + parseInt(h[1].toString());
                if (minutes >= 60) {
                    minutes = minutes - 60;
                    hours = hours + 1;
                }
                hours = hours + parseInt(h[0].toString());
            }
            if (seconds < 9) {
                seconds = '0' + seconds;
            }
            if (minutes < 9) {
                minutes = '0' + minutes;
            }
            if (hours < 9) {
                hours = '0' + hours;
            }
            total = hours + ':' + minutes + ':' + seconds;
            return total;
        };
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
                <ext:FormPanel ID="FPRINCIPAL" runat="server" Width="1200" Height="600" Border="true"   TitleAlign="Center" BodyPadding="8" AutoScroll="true" UI="Default">
                    <FieldDefaults LabelAlign="Right" LabelWidth="115" MsgTarget="Side" />
                    <Items>
                        <ext:FieldSet runat="server" DefaultWidth="1250" Title="Filtros"  Height="70">
                            <Items>
                                <ext:Container runat="server" Layout="HBoxLayout">
                                    <Items>
                                        <ext:Label ID="LFECHAINICIO" runat="server" Width="200" Text="FECHA INICIO" MarginSpec="0 0 0 0" />
                                        <ext:Label ID="LFECHAFIN" runat="server" Width="200" Text="FECHA FIN" MarginSpec="0 10 0 10" />
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container1" runat="server" Layout="HBoxLayout">
                                    <Items>
                                        <ext:DateField runat="server" ID="DFECHAINICIO" Width="200" MarginSpec="0 0 0 0" />
                                        <ext:DateField runat="server" ID="DFECHAFIN" Width="200" MarginSpec="0 10 0 10"  />
                                        <ext:Button runat="server" ID="BFILTRO" Width="100" Text="Buscar" Icon="Zoom" Margins="0 0 0 10">
                                            <Listeners>
                                                <Click Handler="if(App.FPRINCIPAL.isValid()){
                                                                    parametro.FiltroAsistencia();
                                                                }else{true}
                                                                " />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FieldSet>

                        <ext:FieldSet  runat="server" DefaultWidth="1180"  Height="450" Title="LISTADO DE ASISTENCIAS" >
                            <Items>
                                <ext:Container runat="server" >
                                    <Items>
                                        <ext:GridPanel ID="GCONTROL" runat="server"  Height="400" Border="true" Width="1160" Frame="true"  >
                                            <TopBar>
                                                <ext:Toolbar runat="server">
                                                    <Items>
                                                        <ext:TextField ID="TFILTRO" runat="server" EmptyText="Buscar por identificación o Empleado" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                            <Listeners>
                                                                <KeyPress Handler="findEmployer(App.GCONTROL.store, App.TFILTRO.getValue(), Ext.EventObject);" />
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
                                                <ext:Store ID="SCONTROL" runat="server" >
                                                    <Model>
                                                        <ext:Model runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="CODIGO" />
                                                                <ext:ModelField Name="IDENTIFICACION" Type="String" />
                                                                <ext:ModelField Name="EMPLEADO" />
                                                                <ext:ModelField Name="FECHA" />
                                                                <ext:ModelField Name="HORAINICIO" />
                                                                <ext:ModelField Name="HORAFIN" />
                                                                <ext:ModelField Name="DURACION" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel>
                                                <Columns>
                                                     <ext:RowNumbererColumn runat="server" />
                                                     <ext:Column ID="CIDENTIFICACION" runat="server" DataIndex="IDENTIFICACION" Text="IDENTIFICACIÓN" Align="Left" Width="150"  SummaryType="Count" >
                                                           <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' FILAS)' : '(1 FILAS)');" />
                                                     </ext:Column>
                                                     <ext:Column ID="CEMPLEADO" runat="server" DataIndex="EMPLEADO" Text="EMPLEADO" Align="Left" Width="400" >
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                     </ext:Column>
                                                     <ext:Column ID="CFECHA" runat="server" DataIndex="FECHA" Text="FECHA" Align="Left" Width="130" >
                                                          <SummaryRenderer Handler="return '&nbsp;';" />
                                                    </ext:Column>
                                                     <ext:Column ID="CHORAINICIO" runat="server" DataIndex="HORAINICIO" Text="HORA INGRESO" Align="Left" Width="140">
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                     </ext:Column>
                                                     <ext:Column ID="CHORAFIN" runat="server" DataIndex="HORAFIN" Text="HORA SALIDA" Align="Left" Width="140">
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                      </ext:Column>
                                                     <ext:Column ID="CDURACION" runat="server" DataIndex="DURACION" Text="DURACIÓN" Align="Left" Width="140" CustomSummaryType="TotalHoras">
                                                        <SummaryRenderer Handler="return value + '';" />
                                                     </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <Features>
                                                <ext:Summary ID="Summary" runat="server" />
                                            </Features>
                                            <BottomBar>
                                                <ext:PagingToolbar runat="server" HideRefresh="true">
                                                    <Items>
                                                         <ext:Button runat="server" Text="EXPORTAR" Icon="Report" UI="Primary" >
                                                             <Listeners>
                                                                 <Click Handler="parametro.reporteAsistencia();" />
                                                             </Listeners>
                                                         </ext:Button>
                                                    </Items>
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

