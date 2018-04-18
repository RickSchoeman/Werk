using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.Activities
{
    public class Activity
    {

        internal static Activity FromXml(XmlElement element)
        {
            var quantities = new List<Quantity>();
            XmlNodeList elemList = element.GetElementsByTagName("quantity");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (!elemList[i].SelectInnerText("label").Equals(null) || elemList[i].SelectInnerText("label") != null || !elemList[i].SelectInnerText("label").Equals("") || elemList[i].SelectInnerText("label") != "")
                {
                    var quantity = new Quantity
                    {
                        Label = elemList[i].SelectInnerText("label"),
                        Rate = elemList[i].SelectInnerText("rate"),
                        Billable = elemList[i].SelectInnerText("billable"),
                        Mandatory = elemList[i].SelectInnerText("mandatory")
                    };
                }
            }

            return new Activity
            {
                Office = element.SelectInnerText("office"),
                Type = element.SelectInnerText("type"),
                Code = element.SelectInnerText("code"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shotname"),
                Projects = new Projects
                {
                    Invoicedescription = element.SelectInnerText("projects/invoicedescription"),
                    Authoriser = element.SelectInnerText("projects/authoriser"),
                    Customer = element.SelectInnerText("projects/customer"),
                    Billable = element.SelectInnerText("projects/billable"),
                    Rate = element.SelectInnerText("projects/rate"),
                    Quantities = new Quantities
                    {
                        Quantity = quantities
                    },
                    Validfrom = element.SelectInnerText("projects/validfom"),
                    Validtill = element.SelectInnerText("projects/validtill")
                },
                Uid = element.SelectInnerText("uid"),
                Inuse = element.SelectInnerText("inuse"),
                Behaviour = element.SelectInnerText("behaviour"),
                Touched = element.SelectInnerText("touched"),
                Financials = new Financials
                {
                    Vatcode = element.SelectInnerText("financials/vatcode")
                }

            };
        }
        public string Office { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public Projects Projects { get; set; }
        public string Uid { get; set; }
        public string Inuse { get; set; }
        public string Behaviour { get; set; }
        public string Touched { get; set; }
        public Financials Financials { get; set; }

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var activity = document.AppendNewElement("activity");
            activity.AppendNewElement("office").InnerText = Office;
            activity.AppendNewElement("type").InnerText = Type;
            activity.AppendNewElement("code").InnerText = Code;
            activity.AppendNewElement("name").InnerText = Name;
            activity.AppendNewElement("shortname").InnerText = Shortname;
            activity.AppendNewElement("projects/invoicedescription").InnerText = Projects.Invoicedescription;
            activity.AppendNewElement("projects/authoriser").InnerText = Projects.Authoriser;
            activity.AppendNewElement("projects/customer").InnerText = Projects.Customer;
            activity.AppendNewElement("projects/billable").InnerText = Projects.Billable;
            activity.AppendNewElement("projects/rate").InnerText = Projects.Rate;
            for (int i = 0; i < Projects.Quantities.Quantity.Count; i++)
            {
                if (!Projects.Quantities.Quantity[i].Equals(null) || Projects.Quantities.Quantity[i] != null || !Projects.Quantities.Quantity[i].Label.Equals("") || Projects.Quantities.Quantity[i].Label != "")
                {
                    var quantity = Projects.Quantities.Quantity[i];
                    activity.AppendNewElement("projects/quantities/quantity[@id='" + i + "']/label").InnerText =
                        quantity.Label;
                    activity.AppendNewElement("projects/quantities/quantity[@id='" + i + "']/rate").InnerText =
                        quantity.Rate;
                    activity.AppendNewElement("projects/quantities/quantity[@id='" + i + "']/billable").InnerText =
                        quantity.Billable;
                    activity.AppendNewElement("projects/quantities/quantity[@id='" + i + "']/mandatory").InnerText =
                        quantity.Mandatory;
                }
            }
            activity.AppendNewElement("projects/validfrom").InnerText = Projects.Validfrom;
            activity.AppendNewElement("projects/validtill").InnerText = Projects.Validtill;
            activity.AppendNewElement("uid").InnerText = Uid;
            activity.AppendNewElement("inuse").InnerText = Inuse;
            activity.AppendNewElement("behavior").InnerText = Behaviour;
            activity.AppendNewElement("touched").InnerText = Touched;
            activity.AppendNewElement("financials/vatcode").InnerText = Financials.Vatcode;
            return document;
        }
    }
    
    public class Quantity
    {
        public string Label { get; set; }
        public string Rate { get; set; }
        public string Billable { get; set; }
        public string Mandatory { get; set; }
    }
    
    public class Quantities
    {
        public List<Quantity> Quantity { get; set; }
    }
    
    public class Projects
    {
        public string Invoicedescription { get; set; }
        public string Authoriser { get; set; }
        public string Customer { get; set; }
        public string Billable { get; set; }
        public string Rate { get; set; }
        public Quantities Quantities { get; set; }
        public string Validfrom { get; set; }
        public string Validtill { get; set; }
    }
    
    public class Financials
    {
        public string Vatcode { get; set; }
    }
    
    

}
