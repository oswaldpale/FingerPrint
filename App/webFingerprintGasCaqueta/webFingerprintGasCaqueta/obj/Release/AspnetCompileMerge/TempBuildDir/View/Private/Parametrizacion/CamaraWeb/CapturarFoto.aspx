<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapturarFoto.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.CapturarFoto" %>


<!DOCTYPE html>
<html>
<head>
    <title>CAMARA WEB</title>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/swfobject/2.2/swfobject.js"></script>
    <script type="text/javascript" src="../../../../Content/js/scriptcam.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#webcam").scriptcam({
                showMicrophoneErrors: false,
                onError: onError,
                cornerRadius: 20,
                disableHardwareAcceleration: 1,
                cornerColor: 'e3e5e2',
                onWebcamReady: onWebcamReady,
                uploadImage: '../../../../Content/images/upload1.png',
                onPictureAsBase64: base64_tofield_and_image
            });
        });
        function base64_tofield() {
            $('#formfield').val($.scriptcam.getFrameAsBase64());
        };
        function base64_toimage() {
            App.IFOTO.setImageUrl("data:image/png;base64," + $.scriptcam.getFrameAsBase64());
        };
        function base64_tofield_and_image(b64) {
            App.IFOTO.setImageUrl("data:image/png;base64," + b64 );
        };
        function changeCamera() {
            $.scriptcam.changeCamera($('#cameraNames').val());
        }
        function onError(errorId, errorMsg) {
            $("#btn1").attr("disabled", true);
            $("#btn2").attr("disabled", true);
            alert(errorMsg);
        }
        function onWebcamReady(cameraNames, camera, microphoneNames, microphone, volume) {
            $.each(cameraNames, function (index, text) {
                $('#cameraNames').append($('<option></option>').val(index).html(text))
            });
            $('#cameraNames').val(camera);
        }
    </script>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:FormPanel runat="server" UI="Primary" Width="690" Frame="true" >
        <Items>
            <ext:Panel runat="server" Height="320"  Layout="BorderLayout"  BodyPadding="5">
                <Items>
                    <ext:Panel runat="server" ID="PCAMARA" Padding="10"  Split="true"  Title="CAMARA" Icon="Camera"   Region="West"
                TitleCollapse="false"
                Floatable="false"
                Collapsed="true"
                Collapsible="true"
                BodyPadding="5" >
                        <Content>
                            <div >
                                <div id="webcam">
                                </div>
                            </div>
                           
                        </Content>
                         <Listeners>
                    <AfterRender Handler="this.setTitle('CAMARA');" />
                    <BeforeCollapse Handler="this.setTitle('CAMARA');" />
                    <BeforeExpand Handler="this.setTitle(this.initialConfig.title);" />
                </Listeners>
                    </ext:Panel>
                    <ext:Panel runat="server" ID="PFOTO" Padding="10" Height="300"  Split="true"  Title="FOTO PERFIL" Icon="ReportUser" Region="Center"  BodyPadding="5"   Floatable="false" Layout="CenterLayout"  >
                        <Items>
                            <ext:Image runat="server" ID="IFOTO" Width="280" Height="244" />
                        </Items>
                         <Listeners>
                    <AfterRender Handler="this.setTitle('FOTO PERFIL');" />
                    <BeforeCollapse Handler="this.setTitle('FOTO PERFIL');" />
                    <BeforeExpand Handler="this.setTitle(this.initialConfig.title);" />
                </Listeners>
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
        <FooterBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button runat="server" ID="BFOTO" Text="TOMAR FOTO" Icon="CameraGo">
                        <Listeners>
                            <Click Handler="base64_toimage()" />
                        </Listeners>
                    </ext:Button>
                    <ext:ToolbarFill />
                    <ext:Button runat="server" ID="BGUARDAR" Text="GUARDAR">
                        <Listeners>
                        </Listeners>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </FooterBar>
    </ext:FormPanel>
</body>
</html>
