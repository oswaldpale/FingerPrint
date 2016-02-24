using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PDFA3_Example.xml {
    [Serializable]
    [DesignerCategory("code")]
    public class TicketsType {
        private List<TicketType> _ticket;

        private string _subtotal;

        [XmlElement("ticket")]
        public List<TicketType> Ticket {
            get { return _ticket; }
            set { _ticket = value; }
        }

        [XmlAttribute("subtotal")]
        public string Subtotal {
            get { return _subtotal; }
            set { _subtotal = value; }
        }
    }
}
