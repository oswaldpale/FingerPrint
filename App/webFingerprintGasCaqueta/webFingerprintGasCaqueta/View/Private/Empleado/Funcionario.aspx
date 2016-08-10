<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Funcionario.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Empleado.Funcionario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FUNCIONARIO</title>

    <link href="../Estilos/extjs-extension.css" rel="stylesheet" />
    <script src="http://gascaqueta.net/sigcweb/scripts/extjs-extension.js">
    </script>

    <style type="text/css">
        /**/
        #unlicensed {
            display: none !important;
        }
    </style>
    <script>

        var EditarFila = function (editor, e) {
            App.direct.EditarEmpleado(e.record.data.codigo);
        }

        var EditarGrillaDetalle = function (editor, e) {

            if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
                Detalle.Editar(e.record.data.codigo, e.record.data.idmunicipio, e.value, e.field);
            }

        };

        var MunicipioRenderer = function (value) {
            var r = App.store_gridMunicipio.getById(value);

            if (Ext.isEmpty(r)) {
                return "";
            }

            return r.data.municipio;
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp" />
        <ext:Hidden ID="idcosto" runat="server" />
        <ext:Hidden ID="idempleado" runat="server" Name="idempleado" />


        <ext:Viewport ID="Viewport1" runat="server">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:FormPanel ID="FPRINCIPAL" runat="server" Width="1000" Height="650" TitleAlign="Center" BodyPadding="10" Icon="User" Title="Funcionario" UI="Info" Border="true">
                    <FieldDefaults LabelAlign="Top" LabelWidth="100" />
                    <Defaults>
                        <ext:Parameter Name="margin" Value="0 0 10 0" Mode="Value" />
                    </Defaults>
                    <Items>
                        <ext:FieldSet runat="server" Title="Información">
                            <Items>
                                <ext:Panel runat="server" Layout="HBoxLayout">
                                    <Items>
                                        <ext:Panel runat="server" Region="Center" Padding="10" ButtonAlign="Center" Width="780" >
                                            <Items>
                                                <ext:Container runat="server" Layout="HBoxLayout">
                                                    <Items>
                                                        <ext:TextField ID="TCODIGO" runat="server" Width="90" MarginSpec="0 3 0 0" AllowBlank="false" FieldLabel="Codigo">
                                                            <AfterLabelTextTpl runat="server">
                                                                <Html>
                                                                    <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                                                </Html>
                                                            </AfterLabelTextTpl>
                                                        </ext:TextField>
                                                        <ext:TextField ID="TIDENTIFICACION" runat="server" Width="90" MarginSpec="0 3 0 0" AllowBlank="false" FieldLabel="Identificación">
                                                            <AfterLabelTextTpl runat="server">
                                                                <Html>
                                                                    <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                                                </Html>
                                                            </AfterLabelTextTpl>
                                                        </ext:TextField>
                                                        <ext:TextField ID="TNOMBRE" runat="server" Flex="3" Disabled="false" MarginSpec="0 3 0 0" AllowBlank="false" FieldLabel="Nombre">
                                                            <AfterLabelTextTpl runat="server">
                                                                <Html>
                                                                    <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                                                </Html>
                                                            </AfterLabelTextTpl>
                                                        </ext:TextField>

                                                        <ext:TextField ID="TPRIMERAPE" runat="server" Flex="2" Disabled="false" MarginSpec="0 3 0 0" AllowBlank="false" FieldLabel="Primer Apellido">
                                                            <AfterLabelTextTpl runat="server">
                                                                <Html>
                                                                    <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                                                </Html>
                                                            </AfterLabelTextTpl>
                                                        </ext:TextField>
                                                        <ext:TextField ID="TSEGUNDOAPE" runat="server" Flex="2" Disabled="false" MarginSpec="0 3 0 0" FieldLabel="Segundo Apellido" />
                                                    </Items>
                                                </ext:Container>

                                                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                                                    <Items>
                                                        <ext:TextField ID="TCELULAR" runat="server" Width="90" Disabled="false" MaskRe="/[0-9]/" MarginSpec="0 3 0 0" FieldLabel="Celular" />
                                                        <ext:TextField ID="TTELEFONO" runat="server" Width="90" Disabled="false" MaskRe="/[0-9]/" MarginSpec="0 3 0 0" FieldLabel="Telefono" />
                                                        <ext:TextField ID="TDIRECCION" runat="server" Flex="2" MarginSpec="0 3 0 0" AllowBlank="true" FieldLabel="Dirección" />
                                                        <ext:TextField ID="CEPS" runat="server" Flex="2" MarginSpec="0 3 0 0" AllowBlank="true" FieldLabel="EPS" />
                                                        <ext:TextField ID="CARP" runat="server" Flex="2" MarginSpec="0 3 0 0" AllowBlank="true" FieldLabel="ARP" />
                                                    </Items>
                                                </ext:FieldContainer>
                                                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                                                    <Items>
                                                        <ext:TextField ID="TextField1" runat="server" Width="90" Disabled="false" MaskRe="/[0-9]/" MarginSpec="0 3 0 0" FieldLabel="Celular" />
                                                        <ext:TextField ID="TextField2" runat="server" Width="90" Disabled="false" MaskRe="/[0-9]/" MarginSpec="0 3 0 0" FieldLabel="Telefono" />
                                                        <ext:TextField ID="TextField3" runat="server" Flex="2" MarginSpec="0 3 0 0" AllowBlank="true" FieldLabel="Dirección" />
                                                        <ext:ComboBox runat="server" ID="CTIPO" FieldLabel="Cargo" ForceSelection="true" MarginSpec="0 3 0 0" DisplayField="tipo" ValueField="idcargo" Width="200" AllowBlank="false">
                                                            <Store>
                                                                <ext:Store runat="server" ID="STIPO">
                                                                    <Model>
                                                                        <ext:Model ID="Model2" runat="server" IDProperty="IDCARGO">
                                                                            <Fields>
                                                                                <ext:ModelField Name="IDCARGO" />
                                                                                <ext:ModelField Name="CODIGO" />
                                                                                <ext:ModelField Name="TIPO" />
                                                                            </Fields>
                                                                        </ext:Model>
                                                                    </Model>
                                                                </ext:Store>
                                                            </Store>
                                                            <ListConfig Width="350" Height="300" ItemSelector=".x-boundlist-item">
                                                                       <Tpl ID="Tpl3" runat="server">
                                                                         <Html>
                                                                           <tpl for=".">
						                                                       <tpl if="[xindex] == 1">
							                                                      <table class="cbStates-list">
						                                                               </tpl>
						                                                                <tr class="x-boundlist-item">      
                                                                                         <td><b><font size=1>{CODIGO}</font></b></td>                                             
							                                                                <td><font size=1>{TIPO}</font></td>
                                                         
						                                                                </tr>
						                                                                <tpl if="[xcount-xindex]==0">
							                                                      </table>
						                                                    </tpl>
					                                                    </tpl>
                                                                    </Html>
                                                                </Tpl>
                                                            </ListConfig>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:FieldContainer>
                                            </Items>
                                            <Buttons>
                                                <ext:Button runat="server" ID="BNUEVO" Text="NUEVO" Icon="UserAdd" Scale="Small" UI="Default"  />
                                                
                                                <ext:Button runat="server" ID="Button1" Text="ACTUALIZAR" Icon="Reload" Scale="Small" Disabled="true" UI="Success"
                                                    Hidden="false">
                                                    <Listeners>
                                                        <%--  <Click Handler="if (#{FormPanel1}.getForm().isValid()) {App.direct.Actualizar([
                                                 App.txt_nombre.getValue(),
                                                 App.txt_apellido1.getValue(),
                                                 App.txt_apellido2.getValue(),
                                                 App.txt_direccion.getValue(),
                                                 App.txt_telefono.getValue(),
                                                 App.txt_celular.getValue(),
                                                 App.cbx_tipo.getValue(),
                                                 App.cbx_costo.getValue(),
                                                 App.cbx_economico.getValue(),
                                                 App.txt_identificacion.getValue(),
                                                
                                                ]);
                                                }else{'true'}
                                                " />--%>
                                                    </Listeners>
                                                </ext:Button>

                                                <ext:Button runat="server" ID="Button2" Text="GUARDAR" Icon="Disk" Scale="Small" UI="Info">
                                                    <Listeners>
                                                        <%--<Click Handler="if (#{FormPanel1}.getForm().isValid()) { App.direct.Guardar(
                                                [App.txt_identificacion.getValue(),                    
                                                App.txt_nombre.getValue(),
                                                App.txt_apellido1.getValue(),
                                                App.txt_apellido2.getValue(),
                                                App.cbx_tipo.getValue(),
                                                App.txt_telefono.getValue(),
                                                App.txt_celular.getValue(),
                                                App.txt_direccion.getValue(),
                                                App.cbx_costo.getValue(),
                                                App.cbx_economico.getValue(),
                                                ]
                                                );
                                                }else{'true'}" />--%>
                                                    </Listeners>
                                                </ext:Button>
                                            </Buttons>
                                        </ext:Panel>
                                        <ext:Panel runat="server" Region="West" MarginSpec="10 3 0 0">
                                            <Items>
                                                <ext:Image ID="IFOTO" runat="server" Width="160px" Height="160" />
                                                <ext:Button ID="TSUBIRFOTO" runat="server" Width="160px" Text="Cambiar Foto">
                                                    <Listeners>
                                                        <Click Handler="App.direct.AbrirCamaraWeb();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server">
                                    <Items>
                                        <ext:CycleButton Width="100" ID="btn_estado" runat="server" ShowText="true">
                                            <Menu>
                                                <ext:Menu ID="Menu3" runat="server">
                                                    <Items>
                                                        <ext:CheckMenuItem ID="CheckMenuItem_Activo" runat="server" Icon="Accept" Text="Activo"
                                                            Checked="true" />
                                                        <ext:CheckMenuItem ID="CheckMenuItem_Inactivo" runat="server" Icon="Delete" Text="Inactivo" />
                                                    </Items>

                                                </ext:Menu>
                                            </Menu>
                                        </ext:CycleButton>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:FieldSet>
                        <ext:Container  runat="server">
                            <Items>
                                <ext:Panel ID="PLISTAEMPLEADO" runat="server" Flex="1">
                                    <Items>
                                        <ext:GridPanel ID="GridPanel1" runat="server" Flex="1" Height="310" Border="true" UI="Primary">
                                            <Store>
                                                <ext:Store ID="store_empleados" runat="server">
                                                    <Model>
                                                        <ext:Model ID="Model5" runat="server" IDProperty="codigo">
                                                            <Fields>
                                                                <ext:ModelField Name="idempleado" />
                                                                <ext:ModelField Name="cedula" />
                                                                <ext:ModelField Name="nombre" />
                                                                <ext:ModelField Name="telefono" />
                                                                <ext:ModelField Name="direccion" />
                                                                <ext:ModelField Name="ccosto" />
                                                                <ext:ModelField Name="ceconomico" />
                                                                <ext:ModelField Name="celular" />
                                                                <ext:ModelField Name="idcosto" />
                                                                <ext:ModelField Name="ideconomico" />
                                                                <ext:ModelField Name="nombre1" />
                                                                <ext:ModelField Name="apellido1" />
                                                                <ext:ModelField Name="apellido2" />
                                                                <ext:ModelField Name="idtipo" />
                                                                <ext:ModelField Name="eliminado" Type="Boolean">
                                                                    <Convert Handler="return value === 'A';" />
                                                                </ext:ModelField>
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:Column ID="Column1" runat="server" DataIndex="cedula" Text="Codigo"
                                                        Width="90">
                                                      
                                                        <Items>
                                                            <ext:TextField ID="PriceFilter" runat="server">
                                                                <Listeners>
                                                                    <Change Handler="this.up('grid').applyFilter();" />
                                                                </Listeners>
                                                                <Plugins>
                                                                    <ext:ClearButton runat="server" />
                                                                </Plugins>
                                                            </ext:TextField>
                                                        </Items>

                                                    </ext:Column>
                                                    <ext:Column ID="Column2" runat="server" DataIndex="nombre" Text="Nombre"
                                                        Flex="3">
                                                       
                                                    </ext:Column>
                                                    <ext:Column ID="Column3" runat="server" DataIndex="telefono" Text="Telefono"
                                                        Width="80">
                                                    </ext:Column>

                                                    <ext:Column ID="Column5" runat="server" DataIndex="direccion" Text="Dirección"
                                                        Flex="2">
                                                    </ext:Column>
                                                    <ext:Column ID="Column6" runat="server" DataIndex="ccosto" Text="Centro Costo"
                                                        Flex="2">
                                                    </ext:Column>
                                                    <ext:Column ID="Column7" runat="server" DataIndex="ceconomico" Text="Centro Economico"
                                                        Flex="2">
                                                    </ext:Column>
                                                    <ext:Column ID="Column4" runat="server" DataIndex="ceconomico" Text="Centro Economico"
                                                        Flex="2">
                                                    </ext:Column>
                                                    <ext:CheckColumn runat="server" Text="Estado" Width="60" DataIndex="eliminado" />
                                                    <%--<ext:CommandColumn ID="CommandColumn8" runat="server" DataIndex="eliminado"  Align="Center" Width="27" >
                                                        <Commands>
                                                            <ext:GridCommand CommandName="btnDesactivar"  ToolTip-Text="Desactivar" />
                                                        </Commands>
                                                        <Listeners>
                                                            <Command Handler="App.direct.DesactivarEmpleado(record.data.idempleado)" />
                                                        </Listeners>
                                                    </ext:CommandColumn>--%>
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" Mode="Single" />
                                            </SelectionModel>

                                            <BottomBar>
                                                <ext:PagingToolbar ID="PagingToolbar3" runat="server" />
                                            </BottomBar>

                                            <Listeners>
                                                <%--<SelectionChange Handler="App.direct.EditarEmpleado(selected[0].data.idempleado);" />--%>
                                                <SelectionChange Handler="var d=selected[0].data,f=#{FormPanel1}.getForm();f.setValues(d);App.Button1.setDisabled(false);;App.Button2.setDisabled(true);App.direct.QuitarSeleccion(selected[0].data.eliminado);" />
                                                <%--<Select Handler="var d=records[0].data,f=#{FormPanel1}.getForm();f.setValues(d);f.setValues({destino:d.Cod_Destino+' - '+d.Destino1});" />--%>
                                            </Listeners>

                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>

