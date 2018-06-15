using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DemoConnector.TwinfieldAPI.Handlers
{
    public class ClassToXml<T> where T : class
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));

        public string GenerateXml(T obj)
        {
            var xml = string.Empty;
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    ser.Serialize(writer, obj);
                    xml = sww.ToString();
                }
            }

            return xml;
        }

        public void WriteXml(T obj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            var folder = Directory.CreateDirectory(@"../../Xml/Results");
            var file = File.Create("../../Xml/Results/XmlResult_" + typeof(T) + "_"  + DateTime.Now.ToFileTime() + ".xml");
            ser.Serialize(file, obj);
            file.Close();
        }
    }
}
