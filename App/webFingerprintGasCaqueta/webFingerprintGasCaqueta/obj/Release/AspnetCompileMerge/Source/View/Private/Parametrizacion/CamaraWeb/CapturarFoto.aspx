<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapturarFoto.aspx.cs" Inherits="webFingerprintGasCaqueta.View.Private.Parametrizacion.CapturarFoto" %>


<!DOCTYPE html>
<html>
<head>
    <title>CAMARA WEB</title>
         <style type="text/css">
      /**/
      #unlicensed{
	        display: none !important;
      }
	 </style>
    <script src="../../../../Content/js/jquery.min.js"></script>
    <script src="../../../../Content/js/swfobject.js"></script>
    <script type="text/javascript" src="../../../../Content/js/scriptcam.js"></script>
    <style type="text/css">
        .titleFoto {
            font-family: helvetica, sans-serif;
            color: #595959;
            font-size: 15px;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        var Base64Foto;
        $(document).ready(function () {
            $("#webcam").scriptcam({
                zoom: 1,
                width: 420,
                height: 343,
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
            Base64Foto = $.scriptcam.getFrameAsBase64();
            App.PCAMARA.hide();
            App.PFOTO.show();
            App.BFOTO.hide();
            App.BCAMBIAR.show();
            App.BGUARDAR.show();
        };
        function base64_tofield_and_image(b64) {
            App.IFOTO.setImageUrl("data:image/JPG;base64," + b64);
            Base64Foto = b64;
            App.PCAMARA.hide();
            App.PFOTO.show();
            App.BFOTO.hide();
            App.BCAMBIAR.show();
            App.BGUARDAR.show();
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


        var GuardarFotoCambio = function () {

            App.direct.guardarFotoPerfilUsuario(Base64Foto,{
                success: function (result) {
                    
                    if(result==true){
                        
                        console.log('entro');
                    }
                }
                
            });
            
        }
    </script>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Crisp" />
    <ext:FormPanel runat="server" Width="442"  >
        <Items>
            <ext:Panel runat="server" Height="430" Padding="10"  >
                <Items>
                    <ext:Panel runat="server" Height="70" >
                        <Items>
                            <ext:Label runat="server" Text="Hacer Foto" Cls="titleFoto" />
                            <ext:Breadcrumb runat="server" Height="5" />
                            <ext:Label runat="server" Text="Tu foto de perfil actual hace parte de la información requerida para ingresar a la empresa." />
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" ID="PCAMARA">
                        
                        <Content>
                            <div>
                                <div id="webcam">
                                </div>
                            </div>
                        </Content>
                    </ext:Panel>
                    <ext:Panel runat="server" ID="PFOTO" Layout="CenterLayout" Hidden="true">
                        <Items>
                            <ext:Image runat="server" ID="IFOTO" Width="420" Height="343" />
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
        <FooterBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button runat="server" ID="BFOTO" Text="Hacer una Foto" UI="Warning">
                        <Listeners>
                            <Click Handler="base64_toimage()" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button runat="server" ID="BCAMBIAR" Text="Repetir Foto" UI="Info" Hidden="true">
                        <Listeners>
                            <Click Handler=" App.PCAMARA.show();
                                             App.PFOTO.hide();
                                             App.BFOTO.show();
                                             App.BCAMBIAR.hide();
                                             App.BGUARDAR.hide();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button runat="server" ID="BGUARDAR" Text="Guardar" Hidden="true">
                        <Listeners>
                            <Click Fn="GuardarFotoCambio" />
                        </Listeners>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </FooterBar>
    </ext:FormPanel>
</body>
</html>
