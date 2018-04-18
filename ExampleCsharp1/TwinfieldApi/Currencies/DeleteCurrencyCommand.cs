using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Currencies
{
    public class DeleteCurrencyCommand
    {
        public Currency Currency { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("currency");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = Currency.Office;
            element.AppendNewElement("code").InnerText = Currency.Code;
            return command;
        }
    }
}
