using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing.Imaging;
using System.IO;

namespace webFingerprintGasCaqueta.View.Private.Parametrizacion.LectorBiometrico
{
    public partial class Imagen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ConvertImagen"] != null)
            {
                string BitmapString = (string)Session["ConvertImagen"];
                this.CargarImagen(StringToBitMap(BitmapString));
            }
           
        }
        public void CargarImagen(Bitmap DataImage) {
            Bitmap bit = DataImage;
            Response.ContentType = "image/png";//Responder Img JPG
            bit.Save(Response.OutputStream, ImageFormat.Png);
        }

        public Bitmap StringToBitMap(string encodedString)
        {
            try
            {
                byte[] encodeByte = Convert.FromBase64String(encodedString);
                System.Drawing.Image img1 = byteArrayToImage(encodeByte);
                Bitmap bitmap = (Bitmap)img1;
                return bitmap;
            }
            catch (Exception e)
            {
               
                return null;
            }
        }
        //convert bytearray to image
        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return System.Drawing.Image.FromStream(mStream);
            }
        }
    }
}