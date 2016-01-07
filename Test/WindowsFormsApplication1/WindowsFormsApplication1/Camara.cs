using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Camara
    {
        public byte[] Foto { get; set; }
        public Camara() { }
        public Camara(byte[] PFoto)
        {
            this.Foto = PFoto;
        }
        public byte[] ConvertirImagen(Image imagen){
            MemoryStream ms = new MemoryStream();
            imagen.Save(ms, ImageFormat.Jpeg);
                byte[] imgArr = ms.ToArray();
                return(imgArr);
        }
    }
    
}
