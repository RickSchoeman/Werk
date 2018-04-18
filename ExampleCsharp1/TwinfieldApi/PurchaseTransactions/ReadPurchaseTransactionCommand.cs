using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.PurchaseTransactions
{
    public class ReadPurchaseTransactionCommand
    {
        public string Office { get; set; }
        public string PurchaseTransactionNumber { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "transaction";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = "INK";
            readElement.AppendNewElement("number").InnerText = PurchaseTransactionNumber;
            return command;
        }
    }
}
