using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Relations;

namespace DemoConnector.TwinfieldAPI.Data.CostCenters
{
    public class CostCenter : Relation
    {
        internal static CostCenter FromXml(XmlElement element)
        {
            bool inuse = false;
            Relations.Behaviour behaviour = Behaviour.Normal;


            if (element.SelectInnerText("inuse") == "true")
            {
                inuse = true;
            }

            if (element.SelectInnerText("behaviour") == Relations.Behaviour.System.ToString().ToLower())
            {
                behaviour = Behaviour.System;
            }

            if (element.SelectInnerText("behaviour") == Behaviour.Template.ToString().ToLower())
            {
                behaviour = Behaviour.Template;
            }
            
            return new CostCenter
            {
                Office = element.SelectInnerText("office"),
                Type = element.SelectInnerText("type"),
                Code = element.SelectInnerText("code"),
                Uid = element.SelectInnerText("uid"),
                Name = element.SelectInnerText("name"),
                Inuse = inuse,
                Behaviour = behaviour,
                Touched = int.Parse(element.SelectInnerText("touched")),
                Website = element.SelectInnerText("website"),
                Cocnumber = element.SelectInnerText("cocnumber"),
                Vatnumber = element.SelectInnerText("vatnumber"),
                Editdimensionname = element.SelectInnerText("editdimensionname"),
            };
        }

        public CostCenter()
        {
            Type = "KPL";
        }
    }
}