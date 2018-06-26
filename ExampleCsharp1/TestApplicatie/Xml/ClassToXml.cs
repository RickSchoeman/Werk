using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TestApplicatie.Xml
{
    public class ClassToXml<T> where T : class
    {
        public string WriteXml(T obj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            Directory.CreateDirectory(@"../../Xml/Results/xml");
            var filename = "XmlResult_" + typeof(T) + "_" + DateTime.Now.ToFileTime() + ".xml";
            var file = File.Create("../../Xml/Results/xml/XmlResult_" + typeof(T) + "_"  + DateTime.Now.ToFileTime() + ".xml");
            ser.Serialize(file, obj);
            file.Close();
            return filename;
        }
    }
}
