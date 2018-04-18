using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.SalesInvoice
{
    public class SalesInvoice
    {
        internal static SalesInvoice FromXml(XmlElement element)
        {
            var lines = new List<Line>();
            XmlNodeList elemListLine = element.GetElementsByTagName("line");
            for (int i = 0; i < elemListLine.Count; i++)
            {
                if (!elemListLine[i].SelectInnerText("article").Equals(null) || !elemListLine[i].SelectInnerText("article").Equals("") || elemListLine[i].SelectInnerText("article") != null || elemListLine[i].SelectInnerText("article") != "")
                {
                    var line = new Line
                    {
                        Article = elemListLine[i].SelectInnerText("article"),
                        Subarticle = elemListLine[i].SelectInnerText("subarticle"),
                        Quantity = elemListLine[i].SelectInnerText("quantity"),
                        Units = elemListLine[i].SelectInnerText("units"),
                        Unitspriceexcl = elemListLine[i].SelectInnerText("unitspriceexcl"),
                        Unitspriceinc = elemListLine[i].SelectInnerText("unitspriceinc"),
                        Vatcode = elemListLine[i].SelectInnerText("vatcode"),
                        Allowdiscountorpremium = elemListLine[i].SelectInnerText("allowdiscountorpremium"),
                        Description = elemListLine[i].SelectInnerText("description"),
                        Performancedate = elemListLine[i].SelectInnerText("performancedate"),
                        Performancetype = elemListLine[i].SelectInnerText("performancetype"),
                        Freetext1 = elemListLine[i].SelectInnerText("freetext1"),
                        Freetext2 = elemListLine[i].SelectInnerText("freetext2"),
                        Freetext3 = elemListLine[i].SelectInnerText("freetext3"),
                        Dim1 = elemListLine[i].SelectInnerText("dim1"),
                        Valueexcl = elemListLine[i].SelectInnerText("valueexcl"),
                        Vatvalue = elemListLine[i].SelectInnerText("vatvalue"),
                        Valueinc = elemListLine[i].SelectInnerText("valueinc")
                    };
                    lines.Add(line);
                }
            }
            var vatlines = new List<Vatline>();
            XmlNodeList elemListVatLine = element.GetElementsByTagName("vatline");
            for (int i = 0; i < elemListVatLine.Count; i++)
            {
                if (!elemListVatLine[i].SelectInnerText("vatcode").Equals(null) || !elemListVatLine[i].SelectInnerText("vatcode").Equals("") || elemListVatLine[i].SelectInnerText("vatcode") != null || elemListVatLine[i].SelectInnerText("vatcode") != "")
                {
                    var vatLine = new Vatline
                    {
                        Vatcode = elemListVatLine[i].SelectInnerText("vatcode"),
                        Vatvalue = elemListVatLine[i].SelectInnerText("vatvalue"),
                        Performancetype = elemListVatLine[i].SelectInnerText("performancetype"),
                        Performancedate = elemListVatLine[i].SelectInnerText("performancedate")
                    };
                    vatlines.Add(vatLine);
                }
            }

            return new SalesInvoice
            {
                Header = new Header
                {
                    Office = element.SelectInnerText("header/office"),
                    Invoicetype = element.SelectInnerText("header/invoicetype"),
                    Invoicedate = element.SelectInnerText("header/invoicedate"),
                    Duedate = element.SelectInnerText("header/duedate"),
                    Bank = element.SelectInnerText("header/bank"),
                    Customer = element.SelectInnerText("header/customer"),
                    Period = element.SelectInnerText("header/period"),
                    Currency = element.SelectInnerText("header/currency"),
                    Status = element.SelectInnerText("header/status"),
                    Paymentmethod = element.SelectInnerText("header/paymentmethod"),
                    Invoiceaddressnumber = element.SelectInnerText("header/invoiceaddressnumber"),
                    Deliveraddressnumber = element.SelectInnerText("header/deliveraddressnumber"),
                    Headertext = element.SelectInnerText("header/headertext"),
                    Footertext = element.SelectInnerText("header/footertext"),
                    Invoicenumber = element.SelectInnerText("header/invoicenumber")
                },
                Lines = new Lines
                {
                    Line = lines
                },
                Totals = new Totals
                {
                    Valueexcl = element.SelectInnerText("totals/valueexcl"),
                    Valueinc = element.SelectInnerText("totals/valueinc")
                },
                Vatlines = new Vatlines
                {
                    Vatline = vatlines
                },
                Financials = new Financials
                {
                    Code = element.SelectInnerText("financials/code"),
                    Number = element.SelectInnerText("financials/number")
                }
            };
        }
        public Header Header { get; set; }
        public Lines Lines { get; set; }
        public Totals Totals { get; set; }
        public Vatlines Vatlines { get; set; }
        public Financials Financials { get; set; }
        
    }

    public class Header
    {
        public string Office { get; set; }
        public string Invoicetype { get; set; }
        public string Invoicedate { get; set; }
        public string Duedate { get; set; }
        public string Bank { get; set; }
        public string Customer { get; set; }
        public string Period { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string Paymentmethod { get; set; }
        public string Invoiceaddressnumber { get; set; }
        public string Deliveraddressnumber { get; set; }
        public string Headertext { get; set; }
        public string Footertext { get; set; }
        public string Invoicenumber { get; set; }
    }
    
    
    
    public class Line
    {
        public string Article { get; set; }
        public string Subarticle { get; set; }
        public string Quantity { get; set; }
        public string Units { get; set; }
        public string Unitspriceexcl { get; set; }
        public string Unitspriceinc { get; set; }
        public string Vatcode { get; set; }
        public string Allowdiscountorpremium { get; set; }
        public string Description { get; set; }
        public string Performancedate { get; set; }
        public string Performancetype { get; set; }
        public string Freetext1 { get; set; }
        public string Freetext2 { get; set; }
        public string Freetext3 { get; set; }
        public string Dim1 { get; set; }
        public string Valueexcl { get; set; }
        public string Vatvalue { get; set; }
        public string Valueinc { get; set; }
        public string Id { get; set; }
    }
    
    public class Lines
    {
        public List<Line> Line { get; set; }
    }
    
    public class Totals
    {
        public string Valueexcl { get; set; }
        public string Valueinc { get; set; }
    }
    
    public class Vatline
    {
        public string Vatcode { get; set; }
        public string Vatvalue { get; set; }
        public string Performancetype { get; set; }
        public string Performancedate { get; set; }
    }
    
    public class Vatlines
    {
        public List<Vatline> Vatline { get; set; }
    }

    public class Financials
    {
        public string Code { get; set; }
        public string Number { get; set; }
    }

}
