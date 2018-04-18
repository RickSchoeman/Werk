using System;
using System.Linq;
using System.Xml;
using TwinfieldApi.Utilities;
using Header = TwinfieldApi.TwinfieldProcessXmlService.Header;

namespace TwinfieldApi.Services
{
	public class ProcessXmlService
	{
		private readonly Session session;
		private readonly IClientFactory clientFactory;

		public ProcessXmlService(Session session)
			: this(session, new ClientFactory())
		{ }

		public ProcessXmlService(Session session, IClientFactory clientFactory)
		{
			this.session = session;
			this.clientFactory = clientFactory;
		}

		public bool Compressed { get; set; }

		public XmlElement Process(XmlDocument input)
		{
			var client = clientFactory.CreateProcessXmlClient(session.ClusterUrl);
			var header = new TwinfieldProcessXmlService.Header { SessionID = session.SessionId };
			var result = Process(client, header, input);
			if (!result.IsSuccess())
				throw new ProcessXmlException(result);
			return result;
		}

		private XmlElement Process(IProcessXmlSoapClient client, TwinfieldProcessXmlService.Header header, XmlDocument input)
		{
			return Compressed
				? ProcessCompressed(client, header, input)
				: ProcessUncompressed(client, header, input);
		}

		private static XmlElement ProcessUncompressed(IProcessXmlSoapClient client, TwinfieldProcessXmlService.Header header, XmlDocument input)
		{
			return client.ProcessXmlDocument(header, input) as XmlElement;
		}

		private static XmlElement ProcessCompressed(IProcessXmlSoapClient client, TwinfieldProcessXmlService.Header header, XmlDocument input)
		{
			byte[] compressedInput = Zlib.CompressXml(input);
			byte[] compressedOutput = client.ProcessXmlCompressed(header, compressedInput);
			XmlDocument document = Zlib.DecompressXml(compressedOutput);
			return document == null ? null : document.DocumentElement;
		}
	}

	internal class ProcessXmlException : Exception
	{
		private readonly XmlElement element;

		public ProcessXmlException(XmlElement element)
		{
			this.element = element;
		}

		public ProcessXmlException(XmlDocument document)
		{
			if (document != null)
				element = document.DocumentElement;
		}

		public override string Message
		{
			get
			{
				if (element == null)
					return "Process XML didn't return any XML.";
				var messages = element.GetMessages();
				if (!messages.Any())
					return "Process XML returned XML that contains an unknown error.";
				return String.Join(" ", messages.ToArray());
			}
		}
	}
}
