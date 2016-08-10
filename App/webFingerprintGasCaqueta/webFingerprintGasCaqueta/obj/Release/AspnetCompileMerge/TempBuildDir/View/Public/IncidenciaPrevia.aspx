<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncidenciaPrevia.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Visitante.IncidenciaPrevia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Se genera la incidencia para el Funcionario</title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp" />
        <ext:FormPanel ID="WPRINCIPAL" runat="server" Draggable="false" Resizable="true" Width="500" >
                <Items>
                    <ext:FormPanel runat="server" ID="FREGISTRO" Padding="5" Layout="ColumnLayout" Border="true" Frame="true">
                        <FieldDefaults LabelAlign="Top" />
                        <Items>
                            <ext:Panel ID="PPREVIO" runat="server" DefaultWidth="480">
                                <Items>
                                    <ext:TextField ID="TINCIDENCIA" FieldLabel="Descripcion Incidencia:" runat="server" Flex="1" ReadOnly="true"  />
                                    <ext:ToolbarSpacer runat="server" Height="20" />
                                    <ext:TextArea ID="TOBSERVACION" FieldLabel="Justifique el tiempo de tardanza" runat="server" Height="200" AllowBlank="false" />
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
                            <ext:Button runat="server" ID="BGUARDAR" Text="Finalizar" FormBind="true" UI="Danger">
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
