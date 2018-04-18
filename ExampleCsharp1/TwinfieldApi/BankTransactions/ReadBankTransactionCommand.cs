using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.BankTransactions
{
    public class ReadBankTransactionCommand
    {
        public string Office { get; set; }
        public string BankTransactionNumber { get; set; }
        public string BankTransactionCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "transaction";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = BankTransactionCode;
            readElement.AppendNewElement("number").InnerText = BankTransactionNumber;
            return command;
        }
    }
}
