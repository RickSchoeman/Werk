using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Projects
{

        public class Project
        {

            internal static Project FromXml(XmlElement element)
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
                        quantities.Add(quantity);
                    }
                }

                return new Project
                {
                    Office = element.SelectInnerText("office"),
                    Type = element.SelectInnerText("type"),
                    Code = element.SelectInnerText("code"),
                    Name = element.SelectInnerText("name"),
                    Shortname = element.SelectInnerText("shortname"),
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
                        Validfrom = element.SelectInnerText("projects/validform"),
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
                var dimension = document.AppendNewElement("dimension");
                dimension.AppendNewElement("office").InnerText = Office;
                dimension.AppendNewElement("type").InnerText = Type;
                dimension.AppendNewElement("code").InnerText = Code;
                dimension.AppendNewElement("name").InnerText = Name;
                dimension.AppendNewElement("shortname").InnerText = Shortname;
                dimension.AppendNewElement("projects/invoicedescription").InnerText = Projects.Invoicedescription;
                dimension.AppendNewElement("projects/authoriser").InnerText = Projects.Authoriser;
                dimension.AppendNewElement("projects/customer").InnerText = Projects.Customer;
                dimension.AppendNewElement("projects/billable").InnerText = Projects.Billable;
                dimension.AppendNewElement("projects/rate").InnerText = Projects.Rate;
                for (int i = 0; i < Projects.Quantities.Quantity.Count; i++)
                {
                    if (!Projects.Quantities.Quantity[i].Equals(null) || Projects.Quantities.Quantity[i] != null || !Projects.Quantities.Quantity[i].Label.Equals("") || Projects.Quantities.Quantity[i].Label != "")
                    {
                        var quantity = Projects.Quantities.Quantity[i];
                        dimension.AppendNewElement("projects/quantities/quantity[@id='" + i + "']/label").InnerText =
                            quantity.Label;
                        dimension.AppendNewElement("projects/quantities/quantity[@id='" + i + "']/rate").InnerText =
                            quantity.Rate;
                        dimension.AppendNewElement("projects/quantities/quantity[@id='" + i + "']/billable").InnerText =
                            quantity.Billable;
                        dimension.AppendNewElement("projects/quantities/quantity[@id='" + i + "']/mandatory").InnerText =
                            quantity.Mandatory;
                    }
                }
                dimension.AppendNewElement("projects/validfrom").InnerText = Projects.Validfrom;
                dimension.AppendNewElement("projects/validtill").InnerText = Projects.Validtill;
                dimension.AppendNewElement("uid").InnerText = Uid;
                dimension.AppendNewElement("inuse").InnerText = Inuse;
                dimension.AppendNewElement("behaviour").InnerText = Behaviour;
                dimension.AppendNewElement("touched").InnerText = Touched;
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

