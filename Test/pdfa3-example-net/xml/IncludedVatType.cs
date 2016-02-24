using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PDFA3_Example.xml {
    [Serializable]
    [DesignerCategory("code")]
    public class IncludedVatType {
        private string _vat;

        private string _priceGross;

        private string _value;

        [XmlAttribute("vat")]
        public string Vat {
            get { return _vat; }
            set { _vat = value; }
        }

        [XmlAttribute("priceGross")]
        public string PriceGross {
            get { return _priceGross; }
            set { _priceGross = value; }
        }

        [XmlText]
        public string Value {
            get { return _value; }
            set { _value = value; }
        }
    }
}
