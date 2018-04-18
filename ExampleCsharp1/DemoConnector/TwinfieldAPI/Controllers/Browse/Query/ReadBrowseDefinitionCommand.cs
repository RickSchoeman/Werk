using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Controllers.Browse.Query
{
	class ReadBrowseDefinitionCommand
	{
		public string Office { get; set; }
		public string Code { get; set; }

		internal XmlDocument ToXml()
		{
			var command = new XmlDocument();
			var readElement = command.AppendNewElement("read");
			readElement.AppendNewElement("type").InnerText = "browse";
			readElement.AppendNewElement("office").InnerText = Office;
			readElement.AppendNewElement("code").InnerText = Code;
			return command;
		}
	}
}