using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnector.Xml
{
    public class XmlMailAddresses
    {
        public XmlEmailAddres General { get; set; }
        public XmlEmailAddres Offer { get; set; }
        public XmlEmailAddres Confirmation { get; set; }
        public XmlEmailAddres Invoice { get; set; }
        public XmlEmailAddres InvoiceReminder { get; set; }
    }

    public class XmlEmailAddres
    {
        public string To { get; set; }
        public string CC { get; set; }
        public bool IsEmpty { get; set; }
    }
}
