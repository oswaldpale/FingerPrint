<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscripcion.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.CapturarHuella" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        var 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager2" Theme="Crisp" runat="server" />

        <ext:Viewport runat="server" >
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:FormPanel runat="server"  BodyPadding="8" AutoScroll="true" Title="INSCRIPCÍON DE HUELLA."  Weight="600" Layout="ColumnLayout">
                    <FieldDefaults LabelAlign="Right" LabelWidth="115" MsgTarget="Side" />
                      <Items>
                          <ext:Panel  runat="server"  Border="false"  AutoScroll="true" Region="East" Height="200"  BodyPadding="20">

                              <Items>
                                  <ext:Image  ID="IMPERFIL" runat="server" ImageUrl="../../../../Content/images/SinFoto.jpg" Width="160px" Height="160px" >
                                  </ext:Image>
                              </Items>
                          </ext:Panel>
                          <ext:Panel  runat="server"  Border="false"  AutoScroll="true" Region="West" Height="200"  BodyPadding="20">

                              <Items>
                                  <ext:Image  ID="Image1"  runat="server" ImageUrl="../../../../Content/images/SinHuella.png" Width="160px" Height="160px" >
                                  
                                  </ext:Image>
                                 
                              </Items>
                          </ext:Panel>
                      </Items>  
                    <Buttons>
                        <ext:Button runat="server" Text="CAPTURA">
                        </ext:Button>
                        <ext:Button runat="server" Text="GUARDAR">
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
