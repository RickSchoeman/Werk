using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.BankTransactions
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
