using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnector.Xml
{
    public class XmlCustomer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public XmlBank Bank { get; set; }
        public XmlPostalAddresses Addresses { get; set; }
        public XmlPhoneNumbers PhoneNumbers { get; set; }
        public XmlMailAddresses EMailAddresses { get; set; }
        public string VATNumber { get; set; }
        public string Comment { get; set; }
        public string LocalBusinessNumber { get; set; }
        public bool ImportAllowed { get; set; }
        public string RegistrationNumber { get; set; }
        public string Website { get; set; }
    }
}
