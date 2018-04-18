﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TwinfieldApi.Dimensions;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.DimensionTypes
{
    public class DimensionType
    {
        internal static DimensionType FromXml(XmlElement element)
        {
            return new DimensionType
            {
                Office = element.SelectInnerText("office"),
                Code = element.SelectInnerText("code"),
                Mask = element.SelectInnerText("mask"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                address = new Address
                {
                    Label1 = element.SelectInnerText("address/label1"),
                    Label2 = element.SelectInnerText("address/label2"),
                    Label3 = element.SelectInnerText("address/label3"),
                    Label4 = element.SelectInnerText("address/label4"),
                    Label5 = element.SelectInnerText("address/label5"),
                    Label6 = element.SelectInnerText("address/label6")
                },
                levels = new Levels
                {
                    Financials = element.SelectInnerText("levels/financials"),
                    Time = element.SelectInnerText("levels/time"),
                    Fixedassets = element.SelectInnerText("levels/fixedassets"),
                    Invoices = element.SelectInnerText("levels/invoices")
                }
                
            };
        }

        public string Office { get; set; }
        public string Code { get; set; }
        public string Mask { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public Address address { get; set; }
        public Levels levels { get; set; }
        
        

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var dimensionType = document.AppendNewElement("dimeniontype");
            
            return document;
        }
    }

    public class Address
    {
        public string Label1 { get; set; }
        public string Label2 { get; set; }
        public string Label3 { get; set; }
        public string Label4 { get; set; }
        public string Label5 { get; set; }
        public string Label6 { get; set; }
    }

    public class Levels
    {
        public string Financials { get; set; }
        public string Time { get; set; }
        public string Fixedassets { get; set; }
        public string Invoices { get; set; }
    }
}
