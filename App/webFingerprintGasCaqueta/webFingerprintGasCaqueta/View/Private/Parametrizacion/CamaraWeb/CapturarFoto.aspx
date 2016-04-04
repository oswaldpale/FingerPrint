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
                uploadImage: 'upload.gif',
                onPictureAsBase64: base64_tofield_and_image
            });
        });
        function base64_tofield() {
            $('#formfield').val($.scriptcam.getFrameAsBase64());
        };
        function base64_toimage() {
            $('#image').attr("src", "data:image/png;base64," + $.scriptcam.getFrameAsBase64());
        };
        function base64_tofield_and_image(b64) {
            $('#formfield').val(b64);
            $('#image').attr("src", "data:image/png;base64," + b64);
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
    <ext:FormPanel runat="server" Width="750" Height="400" UI="Primary" Frame="true" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" Width="700">
                <Content>
                    <div style="width: 100px; float: left; padding: 15px">
                        <div id="webcam">
                        </div>
                    </div>
                    <div style="width: 250px; float: right;">
                            <img id="image" style="width:250px; height: 244px; padding: 15px" />
                    </div>
                </Content>
            </ext:Panel>
        </Items>
        <Buttons>
            <ext:Button runat="server">
                <Listeners>
                    <Click Handler="base64_toimage()" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:FormPanel>
</body>
</html>
