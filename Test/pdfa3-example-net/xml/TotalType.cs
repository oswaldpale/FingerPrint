using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PDFA3_Example.xml {
    [Serializable]
    [DesignerCategory("code")]
    public class TotalType {
        private SubtotalType _subtotal;

        private string _invoiceAmount;

        [XmlElement("subtotal")]
        public SubtotalType Subtotal {
            get { return _subtotal; }
            set { _subtotal = value; }
        }

        [XmlAttribute("invoiceAmount")]
        public string InvoiceAmount {
            get { return _invoiceAmount; }
            set { _invoiceAmount = value; }
        }
    }
}
