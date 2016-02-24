using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PDFA3_Example.xml {
    [Serializable]
    [DesignerCategory("code")]
    public class SubtotalType {
        private InvoiceAmountNetType _invoiceAmountNet;

        private IncludedVatType _includedVat;

        private string _priceGross;

        [XmlElement("invoiceAmountNet")]
        public InvoiceAmountNetType InvoiceAmountNet {
            get { return _invoiceAmountNet; }
            set { _invoiceAmountNet = value; }
        }

        [XmlElement("includedVat")]
        public IncludedVatType IncludedVat {
            get { return _includedVat; }
            set { _includedVat = value; }
        }

        [XmlAttribute("priceGross")]
        public string PriceGross {
            get { return _priceGross; }
            set { _priceGross = value; }
        }
    }
}
