using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Persona
    {
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }
        public byte[] Foto { get; set; }
        public byte[] Huella1 { get; set; }
        public byte[] Huella2 { get; set; }
        public int vinculacion { get; set; }
        public Persona() { }

        public Persona(Int64 pId, string pNombre, string pPrimerApellido, string pSegundoApellido, string pTelefono, byte[] pFoto, byte[] pHuella1, byte[] pHuella2, int pVinculacion)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.PrimerApellido = pPrimerApellido;
            this.SegundoApellido = pSegundoApellido;
            this.Telefono = pTelefono;
            this.Foto = pFoto;
            this.Huella1 = pHuella1;
            this.Huella2 = pHuella2;
            this.vinculacion = pVinculacion;
        }
    }
}
