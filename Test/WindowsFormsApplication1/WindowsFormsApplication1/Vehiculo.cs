using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Vehiculo
    {
        public int Tag { get; set; }
        public string Color { get; set; }
        public int Modelo { get; set; }
        public string Marca { get; set; }
        public int TipoVehiculo { get; set; }
        public Vehiculo() { }

        public Vehiculo(int pTag, string pPlaca, string pColor, int pModelo, string pMarca, int pTipoVehiculo)
        {
            this.Tag = pTag;
            this.Color = pColor;
            this.Modelo = pModelo;
            this.Marca = pMarca;
            this.TipoVehiculo = pTipoVehiculo;
            
        }
    }
}
