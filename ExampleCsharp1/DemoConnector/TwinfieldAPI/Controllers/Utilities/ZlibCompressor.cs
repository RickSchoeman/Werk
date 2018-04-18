using System.IO;
using System.Text;
using System.Xml;
using Ionic.Zlib;

namespace DemoConnector.TwinfieldAPI.Controllers.Utilities
{
	public class Zlib
	{
		private static readonly Encoding encoding = new UTF8Encoding(false);
 
		public static byte[] CompressXml(XmlDocument document)
		{
			using (var input = new MemoryStream())
			{
				WriteXmlToStream(document, input);
				input.Position = 0;
				return CompressStream(input);
			}
		}

		public static XmlDocument DecompressXml(byte[] bytes)
		{
			using (var input = new MemoryStream(bytes))
			using (var output = new MemoryStream())
			{
				DecompressToStream(input, output);
				output.Position = 0;
				return StreamToXmlDocument(output);
			}
		}

		private static void WriteXmlToStream(XmlDocument document, Stream input)
		{
			using (var w = CreateXmlWriter(input))
				document.WriteTo(w);
		}

		private static XmlWriter CreateXmlWriter(Stream input)
		{
			return XmlWriter.Create(input, new XmlWriterSettings { Encoding = encoding });
		}

		private static byte[] CompressStream(Stream input)
		{
			using (var output = new MemoryStream())
			{
				CompressToStream(input, output);
				return output.ToArray();
			}
		}

		private static void CompressToStream(Stream input, Stream output)
		{
			using (var zlib = new ZlibStream(output, CompressionMode.Compress))
				input.CopyTo(zlib);
		}

		private static void DecompressToStream(Stream input, Stream output)
		{
			using (var zlib = new ZlibStream(input, CompressionMode.Decompress))
				zlib.CopyTo(output);
		}

		private static XmlDocument StreamToXmlDocument(Stream input)
		{
			var doc = new XmlDocument();
			doc.Load(input);
			return doc;
		}
	}
}
