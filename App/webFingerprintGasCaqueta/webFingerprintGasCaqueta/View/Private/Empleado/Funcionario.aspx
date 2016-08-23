<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Funcionario.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Empleado.Funcionario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FUNCIONARIO</title>
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

        var findDependencia = function (Store, texto, e) {

            var store = Store,
                    text = texto;
            store.clearFilter();
            if (Ext.isEmpty(text, false)) {
                return;
            }
            var re = new RegExp(".*" + text + ".*", "i");
            store.filterBy(function (node) {
                var RESUMEN = node.data.CODIGO + node.data.AREA + node.data.EXT;
                var a = re.test(RESUMEN);
                return a;
            });

        };

        var findCentrocosto = function (Store, texto, e) {

            var store = Store,
                    text = texto;
            store.clearFilter();
            if (Ext.isEmpty(text, false)) {
                return;
            }
            var re = new RegExp(".*" + text + ".*", "i");
            store.filterBy(function (node) {
                var RESUMEN = node.data.CODIGO + node.data.CENTROCOSTO;
                var a = re.test(RESUMEN);
                return a;
            });

        };

        var findMunicipio = function (Store, texto, e) {

            var store = Store,
                    text = texto;
            store.clearFilter();
            if (Ext.isEmpty(text, false)) {
                return;
            }
            var re = new RegExp(".*" + text + ".*", "i");
            store.filterBy(function (node) {
                var RESUMEN = node.data.CODIGO + node.data.DESTINO;
                var a = re.test(RESUMEN);
                return a;
            });

        };

        var findCargo = function (Store, texto, e) {

            var store = Store,
                    text = texto;
            store.clearFilter();
            if (Ext.isEmpty(text, false)) {
                return;
            }
            var re = new RegExp(".*" + text + ".*", "i");
            store.filterBy(function (node) {
                var RESUMEN = node.data.CODIGO + node.data.CARGO;
                var a = re.test(RESUMEN);
                return a;
            });

        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp" />
        <ext:Hidden ID="HCARGO" runat="server" />
        <ext:Hidden ID="HCODDEP" runat="server" />
        <ext:Hidden ID="HMUNICIPIO" runat="server" />
        <ext:Hidden ID="HCENTROCOSTO" runat="server" />


        <ext:Viewport ID="Viewport1" runat="server">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:FormPanel ID="FPRINCIPAL" runat="server" Width="1020" Height="650" TitleAlign="Center" BodyPadding="10" Icon="User" Title="Funcionario" UI="Info" Border="true">
                    <FieldDefaults LabelAlign="Top" LabelWidth="100" />
                    <Defaults>
                        <ext:Parameter Name="margin" Value="0 0 10 0" Mode="Value" />
                    </Defaults>
                    <Items>
                        <ext:FieldSet runat="server" Title="Información">
                            <Items>
                                <ext:Panel runat="server" Layout="HBoxLayout">
                                    <Items>
                                        <ext:Panel runat="server" Region="Center" Padding="10" ButtonAlign="Center" Width="800">
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
                                                        <ext:DropDownField runat="server" ID="DDMUNICIPIO" FieldLabel="MUNICIPIO" MarginSpec="0 3 0 0" >
                                                            <Listeners>
                                                                <Expand Handler="this.picker.setWidth(350);" />
                                                            </Listeners>
                                                            <Listeners>
                                                                <IconClick Handler="this.picker.setWidth(350);" />
                                                            </Listeners>
                                                            <Component>
                                                                <ext:GridPanel ID="GDMUNICIPIO" runat="server" ForceFit="true" Padding="4" Height="350" Frame="true" UI="Info">
                                                                    <TopBar>
                                                                        <ext:Toolbar runat="server">
                                                                            <Items>
                                                                                <ext:TextField ID="TFMUNICIPIO" runat="server" EmptyText="codigo o municipio para filtrar" Width="380" EnableKeyEvents="true" Icon="Magnifier" ClearCls="true">
                                                                                    <Listeners>
                                                                                        <KeyPress Handler="findMunicipio(App.GDMUNICIPIO.store, App.TFMUNICIPIO.getValue(), Ext.EventObject);" Buffer="200" />
                                                                                    </Listeners>
                                                                                    <Plugins>
                                                                                        <ext:ClearButton runat="server">
                                                                                            <Listeners>
                                                                                                <Clear Handler="var store = App.GDMUNICIPIO.store; store.clearFilter();" />
                                                                                            </Listeners>
                                                                                        </ext:ClearButton>
                                                                                    </Plugins>
                                                                                    <ToolTips>
                                                                                        <ext:ToolTip runat="server" Title="Presionar enter para buscar" Width="200" />
                                                                                    </ToolTips>
                                                                                </ext:TextField>
                                                                            </Items>
                                                                        </ext:Toolbar>
                                                                    </TopBar>
                                                                    <Store>
                                                                        <ext:Store ID="SMUNICIPIO" runat="server" PageSize="10">
                                                                            <Model>
                                                                                <ext:Model runat="server">
                                                                                    <Fields>
                                                                                        <ext:ModelField Name="CODIGO" />
                                                                                        <ext:ModelField Name="DESTINO" />
                                                                                    </Fields>
                                                                                </ext:Model>
                                                                            </Model>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <ColumnModel>
                                                                        <Columns>
                                                                            <ext:Column runat="server" DataIndex="CODIGO" Header="DESTINO" Width="100" />
                                                                            <ext:Column runat="server" DataIndex="DESTINO" Header="DESTINO" Width="250" />
                                                                        </Columns>
                                                                    </ColumnModel>
                                                                    <SelectionModel>
                                                                        <ext:RowSelectionModel runat="server" Mode="Single" />
                                                                    </SelectionModel>
                                                                    <Listeners>
                                                                        <RowDblClick Handler="App.HMUNICIPIO.setValue(record.get('CODIGO')); App.DDMUNICIPIO.setValue(record.get('DESTINO'));App.SMUNICIPIO.clearFilter();App.TFMUNICIPIO.clear();" />
                                                                    </Listeners>
                                                                </ext:GridPanel>
                                                            </Component>
                                                        </ext:DropDownField>
                                                        <ext:TextField ID="CEPS" runat="server" Flex="1" MarginSpec="0 3 0 0" AllowBlank="true" ReadOnly="true" FieldLabel="EPS" />
                                                        <ext:TextField ID="CARP" runat="server" Flex="1" MarginSpec="0 3 0 0" AllowBlank="true" ReadOnly="true" FieldLabel="ARP" />
                                                    </Items>
                                                </ext:FieldContainer>
                                                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                                                    <Items>
                                                        <ext:TextField ID="TextField1" runat="server" Width="90" Disabled="false" MaskRe="/[0-9]/" MarginSpec="0 3 0 0" FieldLabel="Celular" />
                                                     
                                                        <ext:DropDownField runat="server" ID="DDEPENDENCIA" FieldLabel="Dependencia" MarginSpec="0 3 0 0" >
                                                            <Listeners>
                                                                <Expand Handler="this.picker.setWidth(500);" />
                                                            </Listeners>
                                                            <Listeners>
                                                                <IconClick Handler="this.picker.setWidth(500);" />
                                                            </Listeners>
                                                            <Component>
                                                                <ext:GridPanel ID="GDEPENDENCIA" runat="server" ForceFit="true" Padding="4" Frame="true" UI="Info">
                                                                    <TopBar>
                                                                        <ext:Toolbar runat="server">
                                                                            <Items>
                                                                                <ext:TextField ID="TFDEPENDENCIA" runat="server" EmptyText="codigo,dependencia o  extensión para filtrar" Width="380" EnableKeyEvents="true" Icon="Magnifier" ClearCls="true">
                                                                                    <Listeners>
                                                                                        <KeyPress Handler="findDependencia(App.GDEPENDENCIA.store, App.TFDEPENDENCIA.getValue(), Ext.EventObject);" Buffer="200" />
                                                                                    </Listeners>
                                                                                    <Plugins>
                                                                                        <ext:ClearButton runat="server">
                                                                                            <Listeners>
                                                                                                <Clear Handler="var store = App.GDEPENDENCIA.store; store.clearFilter();" />
                                                                                            </Listeners>
                                                                                        </ext:ClearButton>
                                                                                    </Plugins>
                                                                                    <ToolTips>
                                                                                        <ext:ToolTip runat="server" Title="Presionar enter para buscar" Width="200" />
                                                                                    </ToolTips>
                                                                                </ext:TextField>
                                                                            </Items>
                                                                        </ext:Toolbar>
                                                                    </TopBar>
                                                                    <Store>
                                                                        <ext:Store ID="SDEPENDENCIA" runat="server" PageSize="10">
                                                                            <Model>
                                                                                <ext:Model runat="server">
                                                                                    <Fields>
                                                                                        <ext:ModelField Name="CODIGO" />
                                                                                        <ext:ModelField Name="AREA" />
                                                                                        <ext:ModelField Name="EXT" />
                                                                                    </Fields>
                                                                                </ext:Model>
                                                                            </Model>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <ColumnModel>
                                                                        <Columns>
                                                                            <ext:Column ID="CCODIGO" runat="server" DataIndex="CODIGO" Header="CODIGO" Width="80" />
                                                                            <ext:Column ID="CDEPENDENCIA" runat="server" DataIndex="AREA" Header="DEPENDENCIA" Width="300" />
                                                                            <ext:Column ID="CEXT" runat="server" DataIndex="EXT" Header="EXTENSIÓN" Width="100" />
                                                                        </Columns>
                                                                    </ColumnModel>
                                                                    <BottomBar>
                                                                        <ext:PagingToolbar runat="server" AutoRender="true" StoreID="SDEPENDENCIA">
                                                                        </ext:PagingToolbar>
                                                                    </BottomBar>
                                                                    <SelectionModel>
                                                                        <ext:RowSelectionModel runat="server" Mode="Single" />
                                                                    </SelectionModel>
                                                                    <Listeners>
                                                                        <RowDblClick Handler="App.HCODDEP.setValue(record.get('CODIGO')); App.DDEPENDENCIA.setValue(record.get('AREA'));App.SDEPENDENCIA.clearFilter();App.TFDEPENDENCIA.clear();" />
                                                                    </Listeners>
                                                                </ext:GridPanel>
                                                            </Component>
                                                        </ext:DropDownField>

                                                        <ext:DropDownField runat="server" ID="DCARGO" FieldLabel="TIPO EMPLEADO" MarginSpec="0 3 0 0" >
                                                            <Listeners>
                                                                <Expand Handler="this.picker.setWidth(500);" />
                                                            </Listeners>
                                                            <Listeners>
                                                                <IconClick Handler="this.picker.setWidth(500);" />
                                                            </Listeners>
                                                            <Component>
                                                                <ext:GridPanel ID="GDCARGO" runat="server" ForceFit="true" Padding="4" Frame="true" UI="Info">
                                                                    <TopBar>
                                                                        <ext:Toolbar runat="server">
                                                                            <Items>
                                                                                <ext:TextField ID="TFCARGO" runat="server" EmptyText="codigo o cargo para filtrar" Width="300" EnableKeyEvents="true" Icon="Magnifier" ClearCls="true">
                                                                                    <Listeners>
                                                                                        <KeyPress Handler="findCargo(App.GDCARGO.store, App.TFCARGO.getValue(), Ext.EventObject);" Buffer="200" />
                                                                                    </Listeners>
                                                                                    <Plugins>
                                                                                        <ext:ClearButton runat="server">
                                                                                            <Listeners>
                                                                                                <Clear Handler="var store = App.GDCARGO.store; store.clearFilter();" />
                                                                                            </Listeners>
                                                                                        </ext:ClearButton>
                                                                                    </Plugins>
                                                                                    <ToolTips>
                                                                                        <ext:ToolTip runat="server" Title="Presionar enter para buscar" Width="200" />
                                                                                    </ToolTips>
                                                                                </ext:TextField>
                                                                            </Items>
                                                                        </ext:Toolbar>
                                                                    </TopBar>
                                                                    <Store>
                                                                        <ext:Store runat="server" ID="SCARGO" PageSize="10" >
                                                                            <Model>
                                                                                <ext:Model runat="server" IDProperty="IDCARGO">
                                                                                    <Fields>
                                                                                        <ext:ModelField Name="CODIGO" />
                                                                                        <ext:ModelField Name="CARGO" />
                                                                                    </Fields>
                                                                                </ext:Model>
                                                                            </Model>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <ColumnModel>
                                                                        <Columns>
                                                                            <ext:Column runat="server" DataIndex="CODIGO" Header="CODIGO" Flex="1" />
                                                                            <ext:Column runat="server" DataIndex="CARGO" Header="CARGO" Flex="4" />
                                                                        </Columns>
                                                                    </ColumnModel>
                                                                    <BottomBar>
                                                                        <ext:PagingToolbar runat="server" AutoRender="true" StoreID="SCARGO">
                                                                        </ext:PagingToolbar>
                                                                    </BottomBar>
                                                                    <SelectionModel>
                                                                        <ext:RowSelectionModel runat="server" Mode="Single" />
                                                                    </SelectionModel>
                                                                    <Listeners>
                                                                        <RowDblClick Handler="App.HCARGO.setValue(record.get('CODIGO')); App.DCARGO.setValue(record.get('CARGO') );App.SCARGO.clearFilter();App.TFCARGO.clear();" />
                                                                    </Listeners>
                                                                </ext:GridPanel>
                                                            </Component>
                                                        </ext:DropDownField>

                                                         <ext:DropDownField runat="server" ID="DDCENTROCOSTO" FieldLabel="CENTRO COSTO" MarginSpec="0 3 0 0" >
                                                            <Listeners>
                                                                <Expand Handler="this.picker.setWidth(520);" />
                                                            </Listeners>
                                                            <Listeners>
                                                                <IconClick Handler="this.picker.setWidth(520);" />
                                                            </Listeners>
                                                            <Component>
                                                                <ext:GridPanel ID="GDCENTROCOSTO" runat="server" ForceFit="true" Padding="4" Frame="true" UI="Info">
                                                                    <TopBar>
                                                                        <ext:Toolbar runat="server">
                                                                            <Items>
                                                                                <ext:TextField ID="TFCENTROCOSTO" runat="server" EmptyText="codigo o cargo para filtrar" Width="300" EnableKeyEvents="true" Icon="Magnifier" ClearCls="true">
                                                                                    <Listeners>
                                                                                        <KeyPress Handler="findCentrocosto(App.GDCENTROCOSTO.store, App.TFCENTROCOSTO.getValue(), Ext.EventObject);" Buffer="200" />
                                                                                    </Listeners>
                                                                                    <Plugins>
                                                                                        <ext:ClearButton runat="server">
                                                                                            <Listeners>
                                                                                                <Clear Handler="var store = App.GDCENTROCOSTO.store; store.clearFilter();" />
                                                                                            </Listeners>
                                                                                        </ext:ClearButton>
                                                                                    </Plugins>
                                                                                    <ToolTips>
                                                                                        <ext:ToolTip runat="server" Title="Presionar enter para buscar" Width="200" />
                                                                                    </ToolTips>
                                                                                </ext:TextField>
                                                                            </Items>
                                                                        </ext:Toolbar>
                                                                    </TopBar>
                                                                    <Store>
                                                                        <ext:Store runat="server" ID="SCENTROCOSTO" PageSize="10" >
                                                                            <Model>
                                                                                <ext:Model runat="server" IDProperty="CODIGO">
                                                                                    <Fields>
                                                                                        <ext:ModelField Name="CODIGO" />
                                                                                        <ext:ModelField Name="CENTROCOSTO" />
                                                                                    </Fields>
                                                                                </ext:Model>
                                                                            </Model>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <ColumnModel>
                                                                        <Columns>
                                                                            <ext:Column runat="server" DataIndex="CODIGO" Header="CODIGO" Flex="1" />
                                                                            <ext:Column runat="server" DataIndex="CENTROCOSTO" Header="CARGO" Flex="4" />
                                                                        </Columns>
                                                                    </ColumnModel>
                                                                    <BottomBar>
                                                                        <ext:PagingToolbar runat="server" AutoRender="true" StoreID="SCENTROCOSTO">
                                                                        </ext:PagingToolbar>
                                                                    </BottomBar>
                                                                    <SelectionModel>
                                                                        <ext:RowSelectionModel runat="server" Mode="Single" />
                                                                    </SelectionModel>
                                                                    <Listeners>
                                                                        <RowDblClick Handler="App.HCENTROCOSTO.setValue(record.get('CODIGO')); App.DDCENTROCOSTO.setValue(record.get('CENTROCOSTO') );App.SCENTROCOSTO.clearFilter();App.TFCENTROCOSTO.clear();" />
                                                                    </Listeners>
                                                                </ext:GridPanel>
                                                            </Component>
                                                        </ext:DropDownField>
                                                
                                                    </Items>
                                                </ext:FieldContainer>
                                            </Items>
                                            <Buttons>
                                                <ext:Button runat="server" ID="BNUEVO" Text="NUEVO" Icon="UserAdd" Scale="Small" UI="Default" />

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
                        <ext:Container runat="server">
                            <Items>
                                <ext:Panel ID="PLISTAEMPLEADO" runat="server" Flex="1">
                                    <Items>
                                        <ext:GridPanel ID="GridPanel1" runat="server" Flex="1" Height="310" Border="true" UI="Primary">
                                            <Store>
                                                <ext:Store ID="store_empleados" runat="server">
                                                    <Model>
                                                        <ext:Model ID="Model5" runat="server" IDProperty="codigo">
                                                            <Fields>
                                                                <ext:ModelField Name="IDEMPLEADO" />
                                                                <ext:ModelField Name="CEDULA" />
                                                                <ext:ModelField Name="USUARIO" />
                                                                <ext:ModelField Name="NOMBRE" />
                                                                <ext:ModelField Name="APELLIDO1" />
                                                                <ext:ModelField Name="APELLIDO2" />
                                                                <ext:ModelField Name="TELEFONO" />
                                                                <ext:ModelField Name="CODTIPO" />
                                                                <ext:ModelField Name="TIPO" />
                                                                <ext:ModelField Name="DIRECCION" />
                                                                <ext:ModelField Name="CELULAR" />
                                                                <ext:ModelField Name="TELEFONO" />
                                                                <ext:ModelField Name="CODAREA" />
                                                                <ext:ModelField Name="AREA" />
                                                                <ext:ModelField Name="FOTO" />
                                                                <ext:ModelField Name="IDCENTROCOSTO" />
                                                                <ext:ModelField Name="CENTROCOSTO" />
                                                                <ext:ModelField Name="ELIMINADO" Type="Boolean">
                                                                    <Convert Handler="return value === 'A';" />
                                                                </ext:ModelField>
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:Column runat="server" DataIndex="IDENTIFICACION" Text="CEDULA" Width="100" />
                                                    <ext:Column runat="server" DataIndex="USUARIO" Text="NOMBRE" Flex="3" />
                                                    <ext:Column runat="server" DataIndex="TELEFONO" Text="TELEFONO"  Width="100" />
                                                    <ext:Column runat="server" DataIndex="DIRECCION" Text="DIRECCIÓN" Flex="2" />
                                                    <ext:Column runat="server" DataIndex="CENTROCOSTO" Text="CENTRO COSTO" Flex="2" />
                                                    <ext:Column runat="server" DataIndex="TIPO" Text="CARGO" Flex="2" />

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

