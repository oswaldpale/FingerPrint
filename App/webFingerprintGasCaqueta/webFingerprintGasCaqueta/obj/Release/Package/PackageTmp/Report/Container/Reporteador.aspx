<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporteador.aspx.cs" Inherits="webFingerprintGasCaqueta.Report.Reporteador" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informes Control De Asistencias</title>
    <style type="text/css">
        /**/
	    #unlicensed{
		    display: none !important;
	    }
    </style>
    <script type="text/javascript">
        var addTab = function (tabPanel, menuPanel, menuItem, url) {
            debugger;
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
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp" >
    </ext:ResourceManager>
    <div>
        <ext:Viewport ID="Viewport1" runat="server" Layout="border" UI="Default">
            <Items>
                <ext:MenuPanel ID="MenuPanel1" runat="server" Collapsible="true" Region="West" Split="true" Title="Informes" Width="200">
                    <Menu ID="Menu2" runat="server">
                        <Items>                           
                            <ext:MenuItem ID="MenuItem1" runat="server" Text="Entrada/Salida Empleados" Icon="UserGo">
                                <Listeners>
                                    <Click Handler="addTab(#{TabPanel1}, #{MenuPanel1},#{MenuItem1},'../View/ControlAccesoEmpleado.aspx');" />
                                </Listeners>
                            </ext:MenuItem>
                            <ext:MenuSeparator />
                  <%--          <ext:MenuItem ID="MenuItem4" runat="server" Text="Salida" Icon="Report">
                                <Listeners>
                                    <Click Handler="addTab(#{TabPanel1}, #{MenuPanel1}, 'InformeSuministro.aspx');" />
                                </Listeners>
                            </ext:MenuItem>                          
                            <ext:MenuSeparator />
                            <ext:MenuItem ID="MenuItem3" runat="server" Text="Articulos" Icon="Report">
                                <Listeners>
                                    <Click Handler="addTab(#{TabPanel1}, #{MenuPanel1}, 'InformeArticulos.aspx');" />
                                </Listeners>
                            </ext:MenuItem>
                            <ext:MenuSeparator />--%>
                        </Items>
                    </Menu>
                </ext:MenuPanel>
                <ext:TabPanel ID="TabPanel1" runat="server" Region="Center" Layout="FitLayout">
                    <Items>
                     
                    </Items>
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
