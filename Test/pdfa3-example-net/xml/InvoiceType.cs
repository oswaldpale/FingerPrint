using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PDFA3_Example.xml {
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot("invoice", Namespace = "", IsNullable = false)]
    public class InvoiceType {
        private TicketsType _tickets;

        private TotalType _total;

        private string _number;

        private string _name;

        [XmlElement("tickets")]
        public TicketsType Tickets {
            get { return _tickets; }
            set { _tickets = value; }
        }

        [XmlElement("total")]
        public TotalType Total {
            get { return _total; }
            set { _total = value; }
        }

        [XmlAttribute("number")]
        public string Number {
            get { return _number; }
            set { _number = value; }
        }

        [XmlAttribute("name")]
        public string Name {
            get { return _name; }
            set { _name = value; }
        }
    }
}

