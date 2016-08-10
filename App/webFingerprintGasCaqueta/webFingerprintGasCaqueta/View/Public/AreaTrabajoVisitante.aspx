<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaTrabajoVisitante.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Public.VisitaAreaTrabajo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Area que se encuentra el visitante en la empresa</title>
</head>
<body>
     <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp" />
        <ext:FormPanel ID="WPRINCIPAL" runat="server" Draggable="false" Resizable="true" Width="390" >
                <Items>
                    <ext:FormPanel runat="server" ID="FREGISTRO" Padding="5" Layout="ColumnLayout">
                        <FieldDefaults LabelAlign="Top" />
                        <Items>
                            <ext:Panel ID="PINCIDENCIAVISITA" runat="server" DefaultWidth="400">
                                <Items>
                                    <ext:ComboBox runat="server" ID="CAREATRABAJO" FieldLabel="DEPENDENCIA " ForceSelection="true" MarginSpec="0 3 0 0" DisplayField="AREA" ValueField="CODIGO" Width="380" AllowBlank="false">
                                        <Store>
                                            <ext:Store runat="server" ID="SDEPENDENCIA">
                                                <Model>
                                                    <ext:Model ID="Model2" runat="server" IDProperty="CODIGO">
                                                        <Fields>
                                                            <ext:ModelField Name="CODIGO" />
                                                            <ext:ModelField Name="EXT" />
                                                            <ext:ModelField Name="AREA" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                        <ListConfig Width="380" Height="300" ItemSelector=".x-boundlist-item">
                                            <Tpl ID="Tpl3" runat="server">
                                                <Html>
                                                    <tpl for=".">
						                               <tpl if="[xindex] == 1">
							                              <table class="cbStates-list">
						                                     </tpl>
						                                        <tr class="x-boundlist-item">      
                                                                 <td><b><font size=1>{CODIGO}</font></b></td>                                             
							                                     <td><font size=1>{AREA}</font></td>
                                                                 <td><font size=1>{EXT}</font></td>
						                                        </tr>
						                                      <tpl if="[xcount-xindex]==0">
							                               </table>
						                               </tpl>
					                                </tpl>
                                                </Html>
                                            </Tpl>
                                        </ListConfig>
                                    </ext:ComboBox>
                                    <ext:ToolbarSpacer runat="server" Height="20" />
                                    <ext:TextArea ID="TOBSERVACION" FieldLabel="RAZON DE LA VISITA:" runat="server" Width="380" Height="200" AllowBlank="false" />
                                </Items>
                            </ext:Panel>
                        </Items>
                        <Listeners>
                            <ValidityChange Handler="#{BGUARDAR}.setDisabled(!valid);" />
                        </Listeners>
                    </ext:FormPanel>
                </Items>
                <BottomBar>
                    <ext:Toolbar ID="Toolbar3" runat="server">
                        <Items>
                            <ext:ToolbarFill />
                            <ext:Button runat="server" ID="BGUARDAR" Text="Finalizar" FormBind="true" UI="Info">
                                <Listeners>
                                    <Click Handler="if(#{FREGISTRO}.getForm().isValid()) {App.direct.registrarHorario(App.THINICIO.getValue(),App.THFIN.getValue());}else{ return false;}  " />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </BottomBar>
                <Listeners>
                    <BeforeHide Handler="App.FREGISTRO.reset();parametro.consultarHorarios();" />
                </Listeners>
            </ext:FormPanel>
    </form>
</body>
</html>
