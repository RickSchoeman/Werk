using System;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.Articles
{
    class ReadArticleCommand
    {
        public String Office { get; set; }
        public String HeaderCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "article";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = HeaderCode;
            return command;
        }
    }
}
