using System.Xml.Serialization;
using DemoConnector.Middleware;

namespace DemoConnector.XmlTest
{
    [XmlInclude(typeof(CustomerResponse))]
    public class BankTest
    {
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public string BicCode { get; set; }
        public string Iban { get; set; }

    }
}
