<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlAccesoEmpleado.aspx.cs" Inherits="webFingerprintGasCaqueta.Report.View.ControlAccesoEmpleado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
            
            debugger;
            var i = 0,
                length = records.length,
                total = 12,
                record;
            var hours = 0, minutes, seconds;
            debugger;
            for (; i < length; ++i) {
                record = records[i];
                hours += record.get('DURACION');
            }

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
                <ext:FormPanel ID="FPRINCIPAL" runat="server" Width="1200" Height="580" Border="true"   TitleAlign="Center" BodyPadding="8" AutoScroll="true" UI="Default">
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
                                        <ext:DateField runat="server" ID="DFECHAFIN" Width="200" MarginSpec="0 10 0 10" />
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

                        <ext:FieldSet  runat="server" DefaultWidth="1160"  Height="450" Title="LISTADO DE ASISTENCIAS" >
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
                                                     <ext:Column runat="server" DataIndex="IDENTIFICACION" Text="IDENTIFICACIÓN" Align="Left" Width="150"  SummaryType="Count" >
                                                           <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' IDENTIFICACIÓN)' : '(1 IDENTIFICACIÓN)');" />
                                                     </ext:Column>
                                                     <ext:Column runat="server" DataIndex="EMPLEADO" Text="EMPLEADO" Align="Left" Width="400" >
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                     </ext:Column>
                                                     <ext:Column runat="server" DataIndex="FECHA" Text="FECHA" Align="Left" Width="120" >
                                                          <SummaryRenderer Handler="return '&nbsp;';" />
                                                    </ext:Column>
                                                     <ext:Column runat="server" DataIndex="HORAINICIO" Text="HORA INGRESO" Align="Left" Width="130">
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                     </ext:Column>
                                                     <ext:Column runat="server" DataIndex="HORAFIN" Text="HORA SALIDA" Align="Left" Width="130">
                                                           <SummaryRenderer Handler="return '&nbsp;';" />
                                                      </ext:Column>
                                                     <ext:Column runat="server" DataIndex="DURACION" Text="DURACIÓN" Align="Left" Width="120" CustomSummaryType="TotalHoras">
                                                     </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <Features>
                                                <ext:Summary ID="Summary" runat="server" />
                                            </Features>
                                            <BottomBar>
                                                <ext:PagingToolbar runat="server" HideRefresh="true" />
                                               <%-- <ext:Toolbar runat="server" >
                                                    <Items>
                                                     
                                                       

                                                    </Items>
                                                </ext:Toolbar>--%>
                                            </BottomBar>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FieldSet>
                    </Items>
                    <FooterBar>
                        <ext:Toolbar runat="server" ID="asdas">
                            <Items>
                             <%--   <ext:Button runat="server" ID="btn_exportar" Text="EXPORTAR" Icon="PageExcel" Scale="Small"
                                    Hidden="false" Disabled="true" OnClick="ToExcel2" AutoPostBack="true">
                                   
                                </ext:Button>--%>
                            </Items>
                        </ext:Toolbar>
                    </FooterBar>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>

</html>

