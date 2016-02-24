using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PDFA3_Example.xml {
    [Serializable]
    [DesignerCategory("code")]
    public class TicketType {
        private string _category;

        private string _amount;

        private string _priceNet;

        private string _vat;

        private string _priceGross;

        private string _value;

        [XmlAttribute("category")]
        public string Category {
            get { return _category; }
            set { _category = value; }
        }

        [XmlAttribute("amount")]
        public string Amount {
            get { return _amount; }
            set { _amount = value; }
        }

        [XmlAttribute("priceNet")]
        public string PriceNet {
            get { return _priceNet; }
            set { _priceNet = value; }
        }

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

        [XmlTextAttribute]
        public string Value {
            get { return _value; }
            set { _value = value; }
        }
    }
}
