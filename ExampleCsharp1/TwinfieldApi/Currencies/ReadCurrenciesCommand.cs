using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Currencies
{
    public class ReadCurrenciesCommand
    {
        public string Office { get; set; }
        public string CurrenciesType { get; set; }
        public string CurrenciesCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("currency");
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = CurrenciesCode;
            return command;
        }
    }
}
