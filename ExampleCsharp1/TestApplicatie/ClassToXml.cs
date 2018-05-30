using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Data.Customers;

namespace TestApplicatie
{
    public class ClassToXml<T> where T : class
    {
        

        public void GenerateXml(T obj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            var xml = string.Empty;
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    ser.Serialize(writer, obj);
                    xml = sww.ToString();
                }
            }
            Console.WriteLine(xml);
        }

        public void WriteXml(T obj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            var folder = Directory.CreateDirectory(@"./Xml");
            var file = File.Create("./Xml/XmlResult.xml");
            ser.Serialize(file, obj);
            file.Close();
        }
        
    }
}
