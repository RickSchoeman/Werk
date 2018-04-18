using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Controllers.Browse.Query
{
	public class BrowseDefinition
	{
		internal static BrowseDefinition FromXml(XmlElement element)
		{
			return new BrowseDefinition
			{
				Office = element.SelectInnerText("office"),
				Code = element.SelectInnerText("code"),
				Name = element.SelectInnerText("name"),
				QueryColumns = QueryColumnList.FromXml(element.SelectSingleElement("columns"))
			};
		}

		public string Office { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public QueryColumnList QueryColumns { get; set; }

		internal XmlDocument ToXml()
		{
			return new XmlDocument();
		}
	}
}