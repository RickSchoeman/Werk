using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace TestApplicatie.Xml
{
    public class ClassToJson<T> where T : class 
    {
        public string WriteJson(T obj)
        {
            Directory.CreateDirectory(@"../../Xml/Results/json");
            var filename = @"JsonResult_" + typeof(T) + "_" + DateTime.Now.ToFileTime() + ".json";
            using (StreamWriter file = File.CreateText(@"../../Xml/Results/json/JsonResult_" + typeof(T) + "_" + DateTime.Now.ToFileTime() + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }

            return filename;
        }
    }
}
