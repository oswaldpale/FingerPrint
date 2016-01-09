﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visitante.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Visitante.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <form runat="server">
        <div>
            <ext:Viewport ID="VPPRESENTACION" runat="server" Layout="border">
                <Items>
                    <ext:Panel ID="PPRESENTACION" runat="server" Layout="Fit" Region="Center" Padding="5">
                        <Items>
                            <ext:GridPanel ID="GPVISITANTE" runat="server" >
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:TextField ID="TFVISITANTE" runat="server" EmptyText="Identificación o  nombre para buscar" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                <Listeners>
                                                    <KeyPress Handler="findUser(GPVISITANTE.store, TFVISITANTE.getValue(), Ext.EventObject);" />
                                                </Listeners>
                                            </ext:TextField>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store ID="SVISITANTE" runat="server">
                                        <Model>
                                            <ext:Model runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="IDENTIFICACION" />
                                                    <ext:ModelField Name="NOMBRE" />
                                                    <ext:ModelField Name="OBSERVACION" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                                                                        
                                    </ext:Store>
                                </Store>
                                <ColumnModel>
                                    <Columns>
                                        <ext:RowNumbererColumn runat="server" />
                                        <ext:Column ID="CIDENTIFICACION" runat="server" DataIndex="COBSERVACION" Header="IDENTIFICACION" Width="150">
                                           
                                        </ext:Column>
                                        <ext:Column ColumnID="CNOMBRE" runat="server" DataIndex="NOMBRE" Header="NOMBRE" Flex="3">
                                            <Editor>
                                                <ext:TextField runat="server" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column ColumnID="COBSERVACION" runat="server" DataIndex="OBSERVACION" Header="OBSERVACIÓN" Flex="3">
                                            <Editor>
                                                <ext:TextField runat="server" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:CommandColumn runat="server" Width="70" Text="HUELLA">
                                            <Commands>
                                                <ext:GridCommand Icon="User" CommandName="fingerprint1">
                                                    <ToolTip Text="Registrar huella primaria" />
                                                </ext:GridCommand>
                                                <ext:GridCommand Icon="User" CommandName="fingerprint2">
                                                    <ToolTip Text="Registrar huella secundaria" />
                                                </ext:GridCommand>
                                            </Commands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                </SelectionModel>
                            </ext:GridPanel>
                        </Items>
                        <BottomBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Icon="Add" Text="NUEVO VISITANTE">
                                        <Listeners>
                                            <Click Handler="WREGISTRO.show();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:Panel>
                </Items>
            </ext:Viewport>

            <ext:Window ID="WREGISTRO" runat="server" Draggable="false" Resizable="false" Height="230" Width="350" Icon="DriveAdd" Title="Nueva Terminal" Hidden="true" Modal="true">
                <Items>
                    <ext:FormPanel runat="server" ID="FREGISTRO" Frame="true" Padding="10" LabelAlign="Top">
                        <Items>
                            <ext:ComboBox ID="CTIPO" FieldLabel="Tipo" runat="server" Width="300" EmptyText="Tipo de terminal" ForceSelection="true" AllowBlank="false">
                                <Items>
                                    <ext:ListItem Text="Biometrico" Value="Biometrico" />
                                    <ext:ListItem Text="Rfid" Value="Rfid" />
                                </Items>
                            </ext:ComboBox>
                            <ext:TextField ID="TTERM_IP" FieldLabel="Ip" runat="server" Width="300" EmptyText="Dirección del dispositivo" AllowBlank="false"  />
                            <ext:TextField ID="TTERM_PUERTO" FieldLabel="Puerto" runat="server" Width="300" EmptyText="Puerto de comunicación" AllowBlank="false" />

                        </Items>
                    </ext:FormPanel>
                </Items>
                <BottomBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:ToolbarFill />
                            <ext:Button runat="server" Icon="Add" Text="Guardar" FormBind="true">
                                <Listeners>
                                    <Click Handler="if(#{FREGISTRO}.getForm().isValid()) {parametro.crearTerminal(TTERM_PUERTO.getValue(), TTERM_IP.getValue(), CTIPO.getValue());}else{ return false;}  " />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </BottomBar>
                <Listeners>
                    <BeforeHide Handler="FTERMINAL.reset();" />
                </Listeners>
            </ext:Window>
        </div>

    </form>
</body>
</html>