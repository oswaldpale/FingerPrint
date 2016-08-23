<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermisoLaboral.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Empleado.PermisoLaboral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PERMISO LABORAL </title>
    <script type="text/javascript">

        
        var findUser = function (Store, texto, e) {
            if (e.getKey() == 13) {
                var store = Store,
                    text = texto;
                store.clearFilter();
                if (Ext.isEmpty(text, false)) {
                    return;
                }
                var re = new RegExp(".*" + text + ".*", "i");
                store.filterBy(function (node) {
                    var RESUMEN = node.data.MIDENTIFICACION + node.data.MNOMBRE + node.data.MTIPO;
                    var a = re.test(RESUMEN);
                    return a;
                });
            }
        };

        var findPermiso = function (Store, texto, e) {

            var store = Store,
                text = texto;
            store.clearFilter();
            if (Ext.isEmpty(text, false)) {
                return;
            }
            var re = new RegExp(".*" + text + ".*", "i");
            store.filterBy(function (node) {
                var RESUMEN = node.data.NOMBRE + node.data.PERMISO + node.data.CODEMPLEADO + node.data.TIPO;
                var a = re.test(RESUMEN);
                return a;
            });

        };

        var registrarPermiso = function () {

            var tipohora = App.CHORA.getValue();
            console.log('entro1');
            if (App.FREGISTRO.isValid()) {
                if (tipohora == 'CHORA' ) {
                    if( App.direct.registrarPermisoHora(tipohora, App.THINICIO.getValue(), App.THFIN.getValue())){
                        Ext.Msg.notify("Notificación", "Registrado exitosamente.");
                        App.direct.CargarPermisosActivos();
                    }
                 } else {
                    if (App.direct._registrarPermisoDia(tipohora)) {
                        Ext.Msg.notify("Notificación", "Registrado exitosamente.");
                        App.direct.CargarPermisosActivos();
                    }
                }
            }
        }

        var eliminarPermiso = function (grid, command, record, row) {
            if (command == 'del') {
                Ext.Msg.confirm('Confirmación', 'Estas seguro de eliminar este permiso?',
                function (btn) {
                    if (btn === 'yes') {
                        if (App.direct.eliminarPermiso(record.data.CODIGO)) {
                            App.direct.CargarPermisosActivos();
                            Ext.Msg.notify("Notificación", "Eliminado exitosamente.");
                           
                        } else {
                            Ext.Msg.Notify("Notificación", "Ha ocurrido un error!..");
                        }
                    }
                });
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp"  Locale="en-US" />
    <form id="Form1" runat="server">
        <div>
            <ext:Viewport ID="VPPRESENTACION" runat="server" Layout="border">
                <Items>
                    <ext:Hidden runat="server" ID="HCODEMPLEADO" />
                    <ext:Panel ID="PPRESENTACION" runat="server" Layout="Fit" Region="Center" Padding="5" UI="Primary" >
                        <Items>
                            <ext:GridPanel ID="GPERMISO" runat="server" AutoDataBind="true" Height="200">
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:TextField ID="TFPERMISO" runat="server" EmptyText="Nombre para buscar" Width="400" EnableKeyEvents="true" Icon="Magnifier">
                                                <Listeners>
                                                    <KeyPress Handler="findPermiso(App.GPERMISO.store, App.TFPERMISO.getValue(), Ext.EventObject);" />
                                                </Listeners>
                                            </ext:TextField>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store ID="SPERMISO" runat="server" GroupField="TIPOHORA">
                                        <Model>
                                            <ext:Model ID="Model1" runat="server" >
                                                <Fields>
                                                    <ext:ModelField Name="CODIGO" />
                                                    <ext:ModelField Name="FECHASOLICITUD" />
                                                    <ext:ModelField Name="CODEMPLEADO" />
                                                    <ext:ModelField Name="NOMBRE" />
                                                    <ext:ModelField Name="PERMISO" />
                                                    <ext:ModelField Name="TIPOHORA" />
                                                    <ext:ModelField Name="FECHAINICIO" />
                                                    <ext:ModelField Name="FECHAFIN" />
                                                    <ext:ModelField Name="FECHAHORA" />
                                                    <ext:ModelField Name="HORAINICIO" />
                                                    <ext:ModelField Name="HORAFIN" />
                                                    <ext:ModelField Name="DESCRIPCION" />
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
                                        <ext:Column ID="Column1" ColumnID="CFECHASOLICITUD" runat="server" DataIndex="FECHASOLICITUD" Header="FECHA SOLICITUD" Width="110" Hidden="true" />
                                        <ext:Column ID="Column9" ColumnID="CODEMPLEADO" runat="server" DataIndex="CODEMPLEADO" Header="IDENTIFICACIÓN" Width="130" />
                                        <ext:Column ID="Column2" ColumnID="CFUNCIONARIO" runat="server" DataIndex="NOMBRE" Header="FUNCIONARIO" Width="200" />
                                        <ext:Column ID="Column3" ColumnID="CTIPOHORA" runat="server" DataIndex="TIPOHORA" Header="TIEMPO" Width="80" />
                                        <ext:Column ID="Column11" ColumnID="CDILIGENCIA" runat="server" DataIndex="PERMISO" Header="DILIGENCIA" Width="100" />
                                        <ext:Column ID="Column4" ColumnID="CFECHAINICIO" runat="server" DataIndex="FECHAINICIO" Header="FECHA INICIO" Width="120" />
                                        <ext:Column ID="Column5" ColumnID="CFECHAFIN" runat="server" DataIndex="FECHAFIN" Header="FECHA FIN" Width="120" />
                                        <ext:Column ID="Column10" ColumnID="CFECHAHORA" runat="server" DataIndex="FECHAHORA" Header="FECHA HORA" Width="110" />
                                        <ext:Column ID="Column7" ColumnID="CHORAINICIO" runat="server" DataIndex="HORAINICIO" Header="HORA INICIO" Width="110" />
                                        <ext:Column ID="Column8" ColumnID="CHORAFIN" runat="server" DataIndex="HORAFIN" Header="HORA FIN" Width="110" />
                                        <ext:Column ID="Column6" ColumnID="COBSERVACION" runat="server" DataIndex="DESCRIPCION" Header="OBSERVACIÓN" Width="300" />

                                        <ext:CommandColumn ID="CommandColumn1" runat="server" Width="60">
                                            <Commands>
                                                <ext:GridCommand Icon="Delete" CommandName="del">
                                                    <ToolTip Text="Eliminar Permiso" />
                                                </ext:GridCommand>
                                            </Commands>
                                             <listeners>
                                                <Command Fn="eliminarPermiso" />
                                            </listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <Features>
                                    <ext:Grouping
                                        ID="Group1"
                                        runat="server"
                                       GroupHeaderTplString="Tiempo : {name} ({rows.length} Item{[values.rows.length > 1 ? 's' : '']})"
                                        HideGroupedHeader="true"
                                        EnableGroupingMenu="false" />
                                </Features>
                            </ext:GridPanel>
                        </Items>
                        <BottomBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ToolbarFill />
                                    <ext:Button ID="BREGISTRO" runat="server" Icon="Add" Text="NUEVO PERMISO">
                                        <Listeners>
                                            <Click Handler="App.WREGISTRO.show();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:Panel>
                </Items>
            </ext:Viewport>
            <ext:Window ID="WREGISTRO" runat="server" Draggable="false" Resizable="true" Width="595" Icon="UserTick" Title="Nueva Permiso" Hidden="true" Modal="true">
                <Items>
                    <ext:FormPanel runat="server" ID="FREGISTRO" Padding="5">
                        <Items>
                            <ext:Panel ID="PREGISTRO" runat="server">
                                <Items>
                                    <ext:FieldSet runat="server" Padding="10">
                                        <Items>
                                            <ext:Container runat="server" Layout="HBoxLayout">
                                                <Items>
                                                   <ext:TextField ID="TFECHASOLICITUD" FieldLabel="FECHA SOLICITUD" LabelWidth="115" Width="265" ReadOnly="true" runat="server" MarginSpec="5 0 5 5 " AllowBlank="false" />
                                                    <ext:ComboBox ID="CDILIGENCIA" FieldLabel="TIPO SOLICITUD" LabelWidth="100" Width="280" runat="server" ValueField="CODIGO" DisplayField="TIPO" AllowBlank="false" MarginSpec="5 0 5 5 " >
                                                        <Store>
                                                            <ext:Store runat="server" ID="STIPO">  
                                                                <Fields>
                                                                     <ext:ModelField Name="CODIGO" />
                                                                     <ext:ModelField Name="TIPO" />
                                                                </Fields>
                                                            </ext:Store>
                                                        </Store>
                                                    </ext:ComboBox>
                                               </Items>
                                            </ext:Container>
                                            <ext:DropDownField ID="DEMPLEADO" FieldLabel="EMPLEADO <font color ='red'>*</font> " MarginSpec="5 0 5 5 " runat="server" LabelWidth="115" Width="550" Flex="1" AllowBlank="false" Editable="false"  >
                                                <Listeners>
                                                    <Expand Handler="this.picker.setWidth(650);" />
                                                </Listeners>
                                                <Listeners>
                                                    <IconClick Handler="this.picker.setWidth(650);" />
                                                </Listeners>
                                                <Component>
                                                    <ext:GridPanel ID="GEMPLEADO" runat="server" ForceFit="true" Padding="4" Frame="true" UI="Primary">
                                                        <TopBar>
                                                            <ext:Toolbar runat="server">
                                                                <Items>
                                                                    <ext:TextField ID="TFEMPLEADO" runat="server" EmptyText="Identificación,permiso o  nombre del funcionario para buscar" Width="400" EnableKeyEvents="true" Icon="Magnifier" ClearCls="true">
                                                                        <Listeners>
                                                                            <KeyPress Handler="findUser(App.GEMPLEADO.store, App.TFEMPLEADO.getValue(), Ext.EventObject);" Buffer="200" />
                                                                        </Listeners>
                                                                        <ToolTips>
                                                                            <ext:ToolTip runat="server" Title="Presionar enter para buscar" Width="200" />
                                                                        </ToolTips>
                                                                    </ext:TextField>
                                                                </Items>
                                                            </ext:Toolbar>
                                                        </TopBar>
                                                        <Store>
                                                            <ext:Store ID="SEMPLEADO" runat="server" PageSize="10">
                                                                <Model>
                                                                    <ext:Model runat="server">
                                                                        <Fields>
                                                                            <ext:ModelField Name="MCODIGO" />
                                                                            <ext:ModelField Name="MIDENTIFICACION" />
                                                                            <ext:ModelField Name="MNOMBRE" />
                                                                            <ext:ModelField Name="MTIPO" />
                                                                        </Fields>
                                                                    </ext:Model>
                                                                </Model>
                                                            </ext:Store>
                                                        </Store>
                                                        <ColumnModel>
                                                            <Columns>
                                                                <ext:Column ID="CIDENTIFICACION" runat="server" DataIndex="MIDENTIFICACION" Header="IDENTIFICACIÓN" Width="100" />
                                                                <ext:Column ID="CNOMBRE" runat="server" DataIndex="MNOMBRE" Header="FUNCIONARIO" Flex="1" />
                                                                <ext:Column ID="CTIPO" runat="server" DataIndex="MTIPO" Header="CARGO" Width="150" />
                                                            </Columns>
                                                        </ColumnModel>
                                                        <BottomBar>
                                                            <ext:PagingToolbar runat="server" AutoRender="true" StoreID="SEMPLEADO">
                                                            </ext:PagingToolbar>
                                                        </BottomBar>
                                                        <SelectionModel>
                                                            <ext:RowSelectionModel  runat="server" Mode="Single" />
                                                        </SelectionModel>
                                                        <Listeners>
                                                            <RowDblClick Handler="App.HCODEMPLEADO.setValue(record.get('MCODIGO')); App.DEMPLEADO.setValue('(' + record.get('MIDENTIFICACION')+') ' + record.get('MNOMBRE') );App.SEMPLEADO.clearFilter();App.TFEMPLEADO.clear();" />
                                                        </Listeners>
                                                    </ext:GridPanel>
                                                </Component>
                                            </ext:DropDownField>
                                        </Items>
                                    </ext:FieldSet>
                                    <ext:Container runat="server" ID="COPCION" Layout="HBoxLayout">
                                        <Items>
                                            <ext:ComboBox runat="server" ID="CHORA" AllowBlank="false" FieldLabel="TIEMPO <font color ='red'>*</font> " ForceSelection="true" LabelWidth="120" Width="270" MarginSpec="5 0 5 10"  >
                                                <Items>
                                                    <ext:ListItem Value="CHORA"  Text="HORA" />
                                                    <ext:ListItem Value="CDIA" Text="DIA" />
                                                </Items>
                                                <Listeners>
                                                    <Select handler="if(this.getValue() =='CDIA'){
                                                                         App.FHORA.hide();  
                                                                         App.THINICIO.allowBlank=true;App.THFIN.allowBlank=true;
                                                                         App.DFECHAINI.allowBlank=false;App.DFECHAFIN.allowBlank=false;
                                                                         App.FDIA.show();App.DFECHAHORA.hide(); App.DFECHAHORA.allowBlack = true;
                                                                     }else{
                                                                         App.FHORA.show();
                                                                         App.DFECHAHORA.show(); App.DFECHAHORA.allowBlack = false;
                                                                         App.THINICIO.allowBlank=false;App.THFIN.allowBlank=false;
                                                                         App.DFECHAINI.allowBlank=true;App.DFECHAFIN.allowBlank=true;
                                                                         App.FDIA.hide();App.DFECHAHORA.show();
                                                                     } " />
                                                </Listeners>
                                            </ext:ComboBox>
                                            
                                            <ext:DateField runat="server" ID="DFECHAHORA" PaddingSpec="5" EmptyText="FECHA PERMISO" Width="145" Hidden="true" MarginSpec="5 0 5 5"/>
                                            <ext:CycleButton ID="CESTADO" runat="server" Padding="5" ShowText="true" Width="130" MarginSpec="5 0 5 5" >
                                                <Menu>
                                                    <ext:Menu runat="server">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Text="ACTIVO" />
                                                            <ext:MenuItem  runat="server" Text="INACTIVO" />
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:CycleButton>
                                        </Items>
                                    </ext:Container>
                                    <ext:FormPanel runat="server">
                                        <Items>
                                            <ext:Container runat="server" ID="FHORA" Layout="HBoxLayout" Height="60" Padding="10" Hidden="true">
                                                <Items>
           
                                                    <ext:TimeField ID="THINICIO" runat="server" FieldLabel="HORA INICIO <font color ='red'>*</font> " LabelWidth="115" Width="265" MarginSpec="5 0 5 5" Increment="30" Format="hh:mm tt" AllowBlank="false" MinTime="5:00" >
                                                        <Listeners>
                                                            <Select Handler="App.THFIN.clear();App.THFIN.setMinValue(App.THINICIO.getValue());App.THFIN.renderData;" />
                                                        </Listeners>
                                                    </ext:TimeField>
                                                    <ext:TimeField ID="THFIN" runat="server" FieldLabel="HORA FIN <font color ='red'>*</font> " MaxTime="18:00" LabelWidth="100" Width="270" MarginSpec="5 0 5 5 " Increment="30" Format="hh:mm tt" AllowBlank="false" />
                                                </Items>
                                            </ext:Container>
                                            <ext:Container runat="server" ID="FDIA" Layout="HBoxLayout" Height="60" Padding="10" Hidden="true" >
                                                <Items>
                                                    <ext:DateField runat="server" ID="DFECHAINI" FieldLabel="FECHA INICIO <font color ='red'>*</font> " LabelWidth="115" Width="265" MarginSpec="5 0 5 5 " />
                                                    <ext:DateField runat="server" ID="DFECHAFIN" FieldLabel="FECHA FIN <font color ='red'>*</font> " LabelWidth="100" Width="270" MarginSpec="5 0 5 5 " />
                                                </Items>
                                            </ext:Container>
                                        </Items>
                                    </ext:FormPanel>
                                     <ext:FieldSet runat="server" ID="FOBSERVACION"  Title="Observación"  Height="140" Padding="10">
                                        <Items>
                                            <ext:TextArea runat="server" ID="TOBSERVACION" Height="95" Width="555" />
                                        </Items>
                                    </ext:FieldSet>
                                </Items>
                            </ext:Panel>
                        </Items>
                        <Buttons>
                            <ext:Button ID="BCANCELAR" runat="server" Text="Cancelar">
                                <Listeners>
                                    <Click Handler="App.FREGISTRO.reset();App.WREGISTRO.hide();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button runat="server" ID="BGUARDAR" Icon="Add" Text="Guardar"  >
                                 <Listeners>
                                    <Click Fn="registrarPermiso" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Items>
            </ext:Window>
        </div>
    </form>
</body>
</html>
