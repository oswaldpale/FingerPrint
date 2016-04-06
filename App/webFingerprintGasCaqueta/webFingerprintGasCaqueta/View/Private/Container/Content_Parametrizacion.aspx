<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Content_Parametrizacion.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Container.Content_Parametrizacion" %>

<html>
<head id="Head1" runat="server">
    <title>CONTENIDO PARAMETRIZACION</title>
    <link href="../../../Content/css/Style.css" rel="stylesheet" />
    <style type="text/css">
        /**/
        #unlicensed {
            display: none !important;
        }
    </style>
    <script type="text/javascript">
        var addTab = function (tabPanel, menuPanel, menuItem, url) {
          
            var menuText = menuItem.text;
            var tab = tabPanel.getComponent("id" + menuItem);

            if (!tab) {
                tab = tabPanel.add({
                    id: "id" + menuText,
                    title: Ext.util.Format.uppercase(menuText),
                    closable: true,
                    menuItem: menuItem,
                    loader: {
                        url: url,
                        renderer: "frame",
                        loadMask: {
                            showMask: true,
                            msg: "Cargando ..."
                        }
                    }
                });

                tab.on("activate", function (tab) {
                    menuPanel.setSelection(tab.menuItem);
                });
            }

            tabPanel.setActiveTab(tab);
        }
        function ConfirmResult(btn) {
            if (btn == 'yes') {
                addTab(App.TDETALLE,App.MBIOMETRIA,App.MHUELLA,'../Empleado/ListarEmpleados.aspx');
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp">
        </ext:ResourceManager>
        <div>
            <ext:Viewport ID="Viewport1" runat="server" Layout="border" UI="Default">
                <Items>
                    <ext:Panel runat="server" ID="PPRINCIPAL" Width="300" Region="West" Split="true" Title="CONTENIDO" Layout="Accordion">
                        <Items>
                            <ext:MenuPanel ID="MHORARIOS" runat="server" Collapsible="true" Title="HORARIOS" SaveSelection="false" Icon="TimelineMarker">
                                <Menu runat="server">
                                    <Items>
                                        <ext:MenuItem ID="MFRANJA" runat="server" Text="Franja Horaria" Icon="Time">
                                            <Listeners>
                                                <Click Handler="addTab(#{TDETALLE}, #{MHORARIOS},#{MFRANJA},'../Parametrizacion/Horario.aspx');" />
                                            </Listeners>
                                        </ext:MenuItem>
                                        <ext:MenuSeparator />
                                        <ext:MenuItem ID="MHORARIO" runat="server" Text="Horario Semanal" Icon="CalendarSelectWeek">
                                            <Listeners>
                                                <Click Handler="addTab(#{TDETALLE}, #{MHORARIOS},#{MHORARIO},'../Parametrizacion/PeriodoSemanal.aspx');" />
                                            </Listeners>
                                        </ext:MenuItem>
                                        <ext:MenuSeparator />
                                        <ext:MenuItem ID="MEMPLEADOHORARIO" runat="server" Text="Horario Empleado" Icon="UserTick">
                                            <Listeners>
                                                <Click Handler="addTab(#{TDETALLE}, #{MHORARIOS},#{MEMPLEADOHORARIO},'../Empleado/HorarioEmpleado.aspx');" />
                                            </Listeners>
                                        </ext:MenuItem>
                                        <ext:MenuSeparator />
                                    </Items>
                                </Menu>
                            </ext:MenuPanel>
                            <ext:MenuPanel ID="MCALENDARIO"
                                runat="server"
                                Title="CALENDARIO"
                                SaveSelection="false"
                                Icon="CalendarAdd">
                                <Menu runat="server">
                                    <Items>
                                        <ext:MenuItem ID="MFESTIVO" runat="server" Text="Festivos" Icon="CalendarViewWeek">
                                            <Listeners>
                                                <Click Handler="addTab(#{TDETALLE}, #{MCALENDARIO},#{MFESTIVO},'../Parametrizacion/Festivos.aspx');" />
                                            </Listeners>
                                        </ext:MenuItem>
                                    </Items>
                                </Menu>
                            </ext:MenuPanel>
                            <ext:MenuPanel ID="MBIOMETRIA"
                                runat="server"
                                Title="BIOMETRIA"
                                SaveSelection="false"
                                IconCls="shortcut-icon-footprintregister icon-footprintregister">
                                <Menu runat="server">
                                    <Items>
                                        <ext:MenuItem ID="MHUELLA" runat="server" Text="Huella Dactilar" IconCls="shortcut-icon-footprint icon-footprint">
                                            <Listeners>
                                                <Click Handler="
                                                     var nav = navigator.appName;
                                                     alert(nav);
                                                     if(nav == 'Microsoft Internet Explorer'){
                                                        addTab(#{TDETALLE}, #{MBIOMETRIA},#{MHUELLA},'../Empleado/ListarEmpleados.aspx');      
                                                     }else{
                                                        Ext.Msg.show({
                                                            title: 'El registro dactilar solo funciona con Internet Explorer!',
                                                            msg: '¿Desea Abrir la pestaña con este navegador?',
                                                            buttons: Ext.Msg.YESNO,
                                                            fn: ConfirmResult,
                                                            animEl: 'elId',
                                                            icon: Ext.MessageBox.INFO
                                                        });
                                                     }
                                                    " />
                                            </Listeners>
                                        </ext:MenuItem>
                                    </Items>
                                </Menu>
                            </ext:MenuPanel>
                            <ext:MenuPanel ID="MINCIPERMISO"
                                runat="server"
                                Title="INCIDENCIA Y PERMISOS"
                                SaveSelection="false"
                                Icon="UserAlert">
                                <Menu runat="server">
                                    <Items>
                                        <ext:MenuItem ID="MINCIDENCIA" runat="server" Text="Incidencia" Icon="UserAlert">
                                            <Listeners>
                                                <Click Handler="addTab(#{TDETALLE}, #{MINCIPERMISO},#{MINCIDENCIA},'../Empleado/ListarEmpleados.aspx');" />
                                            </Listeners>
                                        </ext:MenuItem>
                                        <ext:MenuItem ID="MPERMISO" runat="server" Text="Permisos" Icon="UserTick">
                                            <Listeners>
                                                <Click Handler="addTab(#{TDETALLE}, #{MINCIPERMISO},#{MPERMISO},'../Empleado/ListarEmpleados.aspx');" />
                                            </Listeners>
                                        </ext:MenuItem>
                                    </Items>
                                </Menu>
                            </ext:MenuPanel>
                        </Items>
                    </ext:Panel>
                    <ext:TabPanel ID="TDETALLE" runat="server" Region="Center" Layout="FitLayout">
                        <Items>
                        </Items>
                    </ext:TabPanel>
                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
