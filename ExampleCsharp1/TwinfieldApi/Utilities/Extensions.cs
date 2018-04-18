using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;

namespace TwinfieldApi.Utilities
{
	public static class Extensions
	{
		public static XmlDocument ToXmlDocument(this string input)
		{
			var document = new XmlDocument();
			document.LoadXml(input);
			return document;
		}

		public static XmlElement AppendNewElement(this XmlDocument document, string name)
		{
			return (XmlElement)document.AppendChild(document.CreateElement(name));
		}

		public static XmlElement AppendNewElement(this XmlElement element, string name)
		{
			Debug.Assert(element.OwnerDocument != null, "element.OwnerDocument != null");
			return (XmlElement)element.AppendChild(element.OwnerDocument.CreateElement(name));
		}

		public static XmlElement SelectSingleElement(this XmlElement element, string xpath)
		{
			return (XmlElement)element.SelectSingleNode(xpath);
		}

		public static string SelectInnerText(this XmlNode node, string xpath)
		{
			var target = node.SelectSingleNode(xpath);
			return target == null ? String.Empty : target.InnerText;
		}

		public static bool IsSuccess(this XmlDocument document)
		{
			return document != null && document.DocumentElement.IsSuccess();
		}

		public static bool IsSuccess(this XmlElement element)
		{
			return element != null && element.GetAttribute("result") == "1";
		}

		public static List<string> GetMessages(this XmlElement element)
		{
			if (element == null)
				return null;

			var messageAttributes = element.SelectNodes(".//@msg");
			return (from XmlAttribute m in messageAttributes select m.InnerText).ToList();
		}
	}
}
